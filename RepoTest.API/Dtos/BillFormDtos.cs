/*
    Object Transfer For Bill 
    Data Form For Bill
*/  
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepoTest.API.Dtos
{
    public class BillFormDtos
    {
        [Required(ErrorMessage = "You Must Add ClienName Id")]
        public string ClienName {get; set;}

        public List<BillItemFromDtos> BillItemsDtos {get; set;}

    }

    public class BillItemFromDtos{
        [Required(ErrorMessage = "You Must Add Item Name")]
        public int Price {get; set;}
        public ItemFormDtos ItemFormDtos {get; set;}
    }

    public class ItemFormDtos{
        [Required(ErrorMessage = "You Must Add Item Name")]
        [MinLength(4, ErrorMessage = "it must be Length more than 4")]
        public string Name {get; set;}
    }
}