using Microsoft.AspNetCore.Mvc;
using OdeToFood.Modles;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ObjectResult Index()
        {
            var model = new Restaurant { Id = 1, Name = "Mallek's Place" };
            return new ObjectResult(model);
        }
    }
}