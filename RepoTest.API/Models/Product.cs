using System.ComponentModel.DataAnnotations;

namespace RepoTest.API.Models
{
    public class Product
    {
        [Key]
        public int Id {get; set;}
        [Required, MaxLength(10, ErrorMessage = "max Length is 10"), MinLength(3, ErrorMessage = "min length is 3")]
        public string Name {get; set;}
        public int Price {get; set;}
    }
}