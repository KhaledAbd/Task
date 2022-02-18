using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoTest.API.Models
{
    public class BillItem
    {
        [Key]
        public int Id {get; set;}

        public int Price {get; set;}

        [ForeignKey("ItemNavigation")]
        public int ItemId {get; set;}

        [ForeignKey("BillNavigation")]
        public int BillId {get; set;}

        public virtual Item ItemNavigation {get; set;}

        public virtual Bill BillNavigation {get; set;}
    }
}