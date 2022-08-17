using BL.Abstract;
using Dal.Concrete;
using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.Controllers
{
    public class LoginController : Controller
    {

        KullanicilarModel kullanicilarModel;
        KullanicilarBL kullanicilarBL;
        KullanicilarDal kullanicilarDal;
        public LoginController()
        {
            kullanicilarBL = new KullanicilarBL();
            kullanicilarModel = new KullanicilarModel();
            kullanicilarDal = new KullanicilarDal();
        }
        const string SessionName = "_Name";
        const string SessionId = "_Id";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (ModelState.IsValid)
            {
                var login = kullanicilarDal.GetAllAsync().Result.Where(x => x.KullaniciAdi.Equals(userName) && x.Sifre.Equals(password)).FirstOrDefault();
                if (login != null)
                {
                    int Id = kullanicilarDal.GetAllAsync().Result.FirstOrDefault(x => x.KullaniciAdi == userName).Id;
                    HttpContext.Session.SetString(SessionName, userName);
                    HttpContext.Session.SetInt32(SessionId, Id);

                    return RedirectToAction("Kullanicilar", "Kullanicilar");
                }
                //kullanicilarDal.GetAllAsync().Result.FirstOrDefault(x=>x.KullaniciAdi==HttpContext.Session.GetString("_Name")).MagazaId
             }

            return View();
        }
    }
}
