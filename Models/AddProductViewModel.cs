using System.ComponentModel.DataAnnotations;
using dropship.Models.Entities;

namespace dropship.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage ="Product name should not be empty")]
         public  string ProductName {get; set;}
        public double Price {get; set;}
        public int Quantity {get; set;}
        public  string Tags { get; set; }
        public List<int> SelectedCategoryIds { get; set; }
        public List<Category> Categories { get; set; }
    }
}