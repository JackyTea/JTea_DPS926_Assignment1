using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace JTea_DPS926_Assignment1
{
    public class Product : INotifyPropertyChanged
    {
        // property change event implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // backing fields
        private string _name;

        private int _quantity;

        private double _price;

        // name of the product
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == _name)
                {
                    return;
                }

                _name = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(name)));
                }
            }
        }

        // amount of available stock for a product
        public int quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (value == _quantity)
                {
                    return;
                }

                _quantity = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(quantity)));
                }
            }
        }

        // the asking price for a product sold
        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value == _price)
                {
                    return;
                }

                _price = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(price)));
                }
            }
        }

        // product constructor (3 params required)
        public Product(string name, int quantity, double price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }
    }
}