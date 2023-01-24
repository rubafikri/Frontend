using Microsoft.AspNetCore.Mvc;

namespace PortofiloProject.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
