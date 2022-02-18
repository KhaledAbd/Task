using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepoTest.API.Models
{
    public class Bill
    {
        [Key]
        public int Id {get; set;}

        public DateTime CreatedAt {get; set;}

        public string ClienName {get; set;}

        public virtual ICollection<BillItem> BillItems {get; set;}
    }

}
