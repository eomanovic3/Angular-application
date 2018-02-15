using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class ZipMapper { }
    public partial class ZipDal
    {
        public ZipModelDC MapToZipModelDC(Zip a)
        {
            return new ZipModelDC()
            {
                zipId = a.ZipId,
                zipCode = a.ZipCode,
                cityId = a.CityId
            };
        }
        public Zip MapToZip(ZipModelDC a)
        {
            return new Zip()
            {
                ZipId = a.zipId,
                ZipCode = a.zipCode,
                CityId = a.cityId
            };
        }

        public ZipModelDC MapAndSaveZipToZipModelDC(ZipModelDC a, Zip b)
        {
            a.zipId = b.ZipId;
            a.zipCode = b.ZipCode;
            a.cityId = b.CityId;
            return a;
        }

        public Zip MapAndSaveZipModelDCToZip(Zip a, ZipModelDC b)
        {
            a.ZipId = b.zipId;
            a.ZipCode = b.zipCode;
            a.CityId = b.cityId;
            return a;
        }
    }
}
