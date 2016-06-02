using System;
using System.Collections.Generic;
using OdeToFood.Modles;

namespace OdeToFood.Services
{
    
   public interface IRestaurantData
   {
       IEnumerable<Restaurant> GetAll();
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
       
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}