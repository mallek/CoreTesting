using Microsoft.AspNetCore.Mvc;
using OdeToFood.Modles;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        
        public ViewResult Index()
        {
            var model = _restaurantData.GetAll();
            return View(model);
        }
        
        
        public ObjectResult ReturnJsonObject()
        {
            var model = new Restaurant { Id = 1, Name = "Mallek's Place" };
            return new ObjectResult(model);
        }
    }
}