using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This will return the FAQ page
        }
    }
}
