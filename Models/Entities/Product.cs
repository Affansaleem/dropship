using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace dropship.Models.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId {get; set;}

        [Required]
        [StringLength(100),NotNull]
        public required string ProductName {get; set;}

        [Range(0.1, double.MaxValue, ErrorMessage ="Price should be greater than 0$")]
        public double Price {get; set;}
        [Range(1, int.MaxValue, ErrorMessage ="Quantity should be atleast 1")]
        public int Quantity {get; set;}
        public required string Tags { get; set; }

        public ICollection<ProductCategory> ProductCategories {get; set;}

    }
}