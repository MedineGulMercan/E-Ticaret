using Dal.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{

    public class UrunBL
    {
        UrunDal urunDal = new();
        public async Task<IEnumerable<Urun>>? UrunGetirHepsi()
        {
            try
            {
               return urunDal.GetAllAsync().Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Urun>? UrunGetir(int id)
        {
            try
            {
                return urunDal.GetAsync(id).Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task? UrunEkle(Urun entity)
        {
            try
            {
                await urunDal.CreateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task? UrunSil(int Id)
        {
            try
            {
                await urunDal.DeleteAsync(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UrunGuncelle(Urun entity)
        {
            try
            {
                await urunDal.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
