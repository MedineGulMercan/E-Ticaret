using Dal.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public class KategoriBL
    {
        KategoriDal kategoriDal;
        public KategoriBL()
        {
            kategoriDal = new KategoriDal();
        }
        public async Task<IEnumerable<Kategori>> KategoriGetirHepsi()
        {
            try
            {
                return kategoriDal.GetAllAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        // public async Task<Kategori> KategoriGetir(int Id)
        // {
        //     try
        //     {
        //         return kategoriDal.GetAsync(Id).Result;
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // }

        //public async Task KategoriEkle(Kategori entity)
        // {

        //     try
        //     {
        //         await kategoriDal.CreateAsync(entity);
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // }
        // public async Task KategoriSİl(int Id)
        // {
        //     try
        //     {
        //         await kategoriDal.DeleteAsync(Id);
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // }

        // public async Task KategoriGuncelle(Kategori entity)
        // {
        //     try
        //     {
        //         await kategoriDal.UpdateAsync(entity);
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // }

    }
}
