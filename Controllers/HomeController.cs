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
        
        
        public IActionResult Details(int id)
        {            
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel input)
        {
            var restautant = _restaurantData.Get(id);
            if(restautant != null && ModelState.IsValid)
            {
                restautant.Name = input.Name;
                restautant.CuisineType = input.CuisineType;
                _restaurantData.Commit();
                return RedirectToAction("Details", new {id = restautant.Id});
            }
            return View(restautant);
        }

        [HttpGet]
        public ViewResult Create()
        {            
            return View();
        } 

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var restautant = new Restaurant();
                restautant.Name = model.Name;
                restautant.CuisineType = model.CuisineType;
                _restaurantData.Add(restautant);
                _restaurantData.Commit();

                return RedirectToAction("Details", new {id = restautant.Id });

            }

            return View();
        }      
        
        
        
        public ObjectResult ReturnJsonObject()
        {
            var model = new Restaurant { Id = 1, Name = "Mallek's Place" };
            return new ObjectResult(model);
        }
    }
}