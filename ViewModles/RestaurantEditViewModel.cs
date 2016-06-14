using System.ComponentModel.DataAnnotations;
using OdeToFood.Entities;

namespace OdeToFood.ViewModels
{
   public class RestaurantEditViewModel
   {   
        public int Id { get; set; } 

        [Required, MaxLength(80)]
        [Display(Name="Restaurant Name")]       
        public string Name { get; set; }
        public CuisineType CuisineType { get; set; }        

   }
}