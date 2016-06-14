using System;
using System.Collections.Generic;
using OdeToFood.Entities;
using System.Linq;


namespace OdeToFood.Services
{

    public interface IRestaurantData
   {
       IEnumerable<Restaurant> GetAll();
       Restaurant Get(int id);
       void Add(Restaurant newResturant);
       int Commit();
   }

    public class SqlRestaurantData : IRestaurantData
    {

        private OdeToFoodDbContext _context;

        public SqlRestaurantData(OdeToFoodDbContext context)               
        {
            _context = context;
        }

        public void Add(Restaurant newResturant)
        {
            _context.Add(newResturant);
            
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Restaurant Get(int id)
        {
             return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        
       public InMemoryRestaurantData()
       {
           _restaurants = new List<Restaurant>{
               new Restaurant { Id = 1, Name = "Travis" },
               new Restaurant { Id = 2, Name = "Macdonalds"},
               new Restaurant { Id = 3, Name = "Rays Hot Dogs"}
           };           
       }

        public void Add(Restaurant newResturant)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}