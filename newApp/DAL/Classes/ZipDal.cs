using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class ZipDal: IZipDal
    {
        private APLABDatabaseEntities _db;

        public ZipDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }
        
        public List<ZipModelDC> GetZips()
        {
            List<ZipModelDC> list = new List<ZipModelDC>();
            foreach (Zip zip in _db.Zips)
            {
                list.Add(MapToZipModelDC(zip));
            }
            return list;
        }

        public ZipModelDC GetZipById(int id)
        {
            Zip obj = _db.Zips.FirstOrDefault(x => x.ZipId == id);


            if (obj == null)
            {
                throw new ArgumentException(Messages.ZipExceptionGetById);
            }
            else
            { 
                return MapToZipModelDC(obj);
            }
            
        }

        public void AddZip(ZipModelDC obj)
        {

            if (obj == null)
            {
                throw new ArgumentException(Messages.ZipExceptionAdd);
            }
            _db.Zips.Add(MapToZip(obj));
            _db.SaveChanges();
        }

        public void UpdateZip(int id, ZipModelDC obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            Zip zip = _db.Zips.FirstOrDefault(x => x.ZipId == id);

            if (zip == null)
            {
                throw new ArgumentException(Messages.ZipExceptionUpdateById);
            }

            zip = MapAndSaveZipModelDCToZip(zip, obj);
            _db.SaveChanges();
        }

        public void DeleteZip(int id)
        {
            Zip zip = _db.Zips.FirstOrDefault(x => x.ZipId == id);

            if (zip == null)
            {
                throw new ArgumentException(Messages.ZipExceptionDelete);
            }

            foreach (var i in _db.Zips)
            {
                if (i.ZipId == id)
                {
                    _db.Zips.Remove(i);
                }
            }

            _db.SaveChanges();
        }
    }
}
