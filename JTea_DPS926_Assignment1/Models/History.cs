using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace JTea_DPS926_Assignment1
{
    public class History : INotifyPropertyChanged
    {
        // property change event implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // backing fields
        private string _name;

        private int _quantity;

        private double _totalPrice;

        private DateTime _purchaseDate;

        // name of the product bought
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

        // amount of product purchased for a transaction
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

        // money spent on transaction (quantity bought * price of product)
        public double totalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                if (value == _totalPrice)
                {
                    return;
                }

                _totalPrice = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(totalPrice)));
                }
            }
        }

        // date and time of transaction (DateTime.now)
        public DateTime purchaseDate
        {
            get
            {
                return _purchaseDate;
            }
            set
            {
                if (value == _purchaseDate)
                {
                    return;
                }

                _purchaseDate = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(purchaseDate)));
                }
            }
        }

        // historical record constructor (4 required parameters)
        public History(string name, int quantity, double totalPrice, DateTime purchaseDate)
        {
            this.name = name;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
            this.purchaseDate = purchaseDate;
        }
    }
}
