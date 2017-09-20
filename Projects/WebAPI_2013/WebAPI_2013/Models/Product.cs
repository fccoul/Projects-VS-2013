using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_2013.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public Int32 Quantite { get; set; }
    }
}