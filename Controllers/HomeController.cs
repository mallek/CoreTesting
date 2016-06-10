using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        
        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = _greeter.GetGreeting();
            return View(model);
        }
        
        
        public ViewResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            return View(model);
        }
        
        
        
        
        public ObjectResult ReturnJsonObject()
        {
            var model = new Restaurant { Id = 1, Name = "Mallek's Place" };
            return new ObjectResult(model);
        }
    }
}