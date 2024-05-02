using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EncryptedData.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string JsonData { get; set; } // Will try to save it without EF Core OWNS methods 
        //public JsonProduct JsonData2 { get; set; }

    }


    public class JsonProduct
    {
        public string Name { get; set; }
        public string Description { get; set; } 

    }

}
