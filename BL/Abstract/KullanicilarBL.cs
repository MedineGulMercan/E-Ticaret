using Dal.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public class KullanicilarBL
    {
        KullanicilarDal kullanicilarDal;

        public KullanicilarBL()
        {
            kullanicilarDal = new KullanicilarDal();
        }

        public async Task? KullanicilarEkleBL(Kullanicilar? entity)
        {
            try
            {
                entity.Aktifmi = true;
                entity.KullaniciAdi = entity.Ad + entity.Soyad;
                if (entity.MagazaId==0 && entity.YetkiId==0)
                {
                    entity.MagazaId = 1;
                    entity.YetkiId = 1;
                    await kullanicilarDal.CreateAsync(entity);
                }
                else
                {
                    await kullanicilarDal.CreateAsync(entity);
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task? KullanicilarGuncelleBL(Kullanicilar? entity)
        {
            try
            {
                await kullanicilarDal.UpdateAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task? KullanicilarSilBL(int Id)
        {
            try
            {
                await kullanicilarDal.DeleteAsync(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
