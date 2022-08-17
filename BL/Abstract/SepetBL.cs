using Dal.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public class SepetBL
    {
        SepetDal sepetDal;

        public SepetBL()
        {
            sepetDal = new SepetDal();
        }


        public async Task<IEnumerable<Sepet>> HepsiSepetGetir()
        {
            try
            {
                return sepetDal.GetAllAsync().Result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SepetGetir(int Id)
        {
            try
            {
                await sepetDal.GetAsync(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task SepetEkle(Sepet entity)
        {
            try
            {
                await sepetDal.CreateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SepetSil(int Id)
        {
            try
            {
                await sepetDal.DeleteAsync(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SepetGuncelle(Sepet entity)
        {
            try
            {
                await sepetDal.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
