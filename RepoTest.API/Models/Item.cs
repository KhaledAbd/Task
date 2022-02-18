
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepoTest.API.Models
{
    public class Item
    {
        [Key]
        public int Id {get; set;}

        public string Name {get; set;}

        public virtual ICollection<BillItem> BillItems {get; set;}

    }
}