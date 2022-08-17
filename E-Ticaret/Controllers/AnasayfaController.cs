using E_Ticaret.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret.Controllers
{
    public class AnasayfaController : Controller
    {
        UrunModel urunModel;
        public AnasayfaController()
        {
            urunModel = new();
        }
        public IActionResult Index()
        {
            urunModel.GetirHepsi();
            return View(urunModel);
        }
    }
}
