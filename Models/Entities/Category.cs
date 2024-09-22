using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace dropship.Models.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId {get; set;} 
            
        [Required]
        [StringLength(100),NotNull]
        public required string CategoryName {get; set;}
        public ICollection<ProductCategory> ProductCategories {get; set;}

    }
}