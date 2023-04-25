using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace CartingService.Domain
{
    public class Item
    {
        public int IdItem { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
