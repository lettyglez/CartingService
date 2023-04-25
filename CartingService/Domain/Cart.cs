using System;
using System.Collections.Generic;


namespace CartingService.Domain
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<Item>();
        }

        public Guid IdCart { get; set; }

        public List<Item> Items { get; set; }

        
    }
    
}
