using Microsoft.AspNetCore.Mvc;

namespace MetaQuotes.IPSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home page with empty html
        /// </summary>
        /// <returns>Page with menu and scripts</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
