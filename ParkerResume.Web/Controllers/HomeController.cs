using System.Web.Mvc;

namespace ParkerResume.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Resume()
        {
            return View();
        }
    }
}