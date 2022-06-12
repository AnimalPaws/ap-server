using Microsoft.AspNetCore.Mvc;

namespace ap_server.Controllers
{
    public class AnnouncementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
