using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModles
{
   public class RegisterViewModel
   {
        [Required, MaxLengthAttribute(256)]
        public string Username { get; set; }
        [Required, DataTypeAttribute(DataType.Password)]
        public string Password { get; set; }
        [DataTypeAttribute(DataType.Password), CompareAttribute(nameof(Password))]
        public string ConfirmPassword { get; set; }

   }
}