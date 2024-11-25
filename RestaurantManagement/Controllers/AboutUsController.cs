using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View(); // This will return the About Us page
        }
    }
}
