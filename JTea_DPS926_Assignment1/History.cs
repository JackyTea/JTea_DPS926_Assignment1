using System;
using System.Collections.Generic;
using System.Text;

namespace JTea_DPS926_Assignment1
{
    class History
    {
        // name of the item sold (e.g. Pants, Shoes, Hat)
        public string name { get; set; }

        // quantity bought
        public int quantity { get; set; }

        // money spent buying products
        public double totalPrice { get; set; }

        // date of purchase
        public DateTime purchaseDate { get; set; }

        // item constructor (3 params required)
        public History(string name, int quantity, double totalPrice, DateTime purchaseDate)
        {
            this.name = name;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
            this.purchaseDate = purchaseDate;
        }
    }
}
