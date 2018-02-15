using DAL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public class ZipLogic : IZip
    {
        private readonly ZipDal _zips;

        public ZipLogic(ZipDal zips)
        {
            _zips = zips;
        }
        public List<ZipModelDC> GetZips()
        {
            return _zips.GetZips();
        }

        public ZipModelDC GetZipById(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.ZipExceptionGetById);
            return _zips.GetZipById(id);
        }

        public void AddZip(ZipModelDC obj)
        {
            foreach (ZipModelDC zip in _zips.GetZips())
            {
                if (zip.zipId == obj.zipId)
                {
                    throw new ArgumentException(Messages.ZipExceptionAdd);
                }
            }
            this._zips.AddZip(obj);
        }

        public void UpdateZip(int id, ZipModelDC obj)
        {
            if (id < 0)
                throw new ArgumentException(Messages.ZipExceptionUpdateById);
            this._zips.UpdateZip(id, obj);
        }

        public void DeleteZip(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.ZipExceptionDelete);
            foreach (ZipModelDC zip in _zips.GetZips())
            {
                if (zip.zipId == id)
                {
                    _zips.DeleteZip(id);
                }
            }
        }
    }
}
