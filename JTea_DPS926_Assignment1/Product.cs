using System;
using System.Collections.Generic;
using System.Text;

namespace JTea_DPS926_Assignment1
{
    public class Product
    {
        // name of the item sold (e.g. Pants, Shoes, Hat)
        public string name { get; set; }

        // quantity available in store's stock
        public int quantity { get; set; }

        // price of this item (e.g. $19.99, currency not specified)
        public double price { get; set; }

        // item constructor (3 params required)
        public Product(string name, int quantity, double price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }
}