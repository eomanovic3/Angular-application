using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IZip
    {
        List<ZipModelDC> GetZips();

        ZipModelDC GetZipById(int id);

        void AddZip(ZipModelDC obj);

        void UpdateZip(int id, ZipModelDC obj);

        void DeleteZip(int id);

    }
}
