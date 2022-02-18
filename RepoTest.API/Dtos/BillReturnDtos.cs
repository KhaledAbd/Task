/*
    Object Transfer For Bill 
    Data Return For Application side
*/

using System;
using System.Collections.Generic;

namespace RepoTest.API.Dtos
{
    public class BillReturnDtos
    {
        public int Id {get; set;}

        public DateTime CreatedAt {get; set;}

        public string ClienName {get; set;}

        public ICollection<BillItemReturnDtos> BillItemReturnDtos {get; set;}

    }

    public class BillItemReturnDtos {
        public int Id {get; set;}

        public int Price {get; set;}
        public ItemReturnDtos ItemReturnDtos {get; set;}
 
    }

    public class ItemReturnDtos {
        public int Id {get; set;}

        public string Name {get; set;}
    }
}