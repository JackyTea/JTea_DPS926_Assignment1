using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace JTea_DPS926_Assignment1
{
    public class History : INotifyPropertyChanged
    {
        // property changed member
        public event PropertyChangedEventHandler PropertyChanged;

        // backing field members
        private string _name;

        private int _quantity;

        private double _totalPrice;

        private DateTime _purchaseDate;

        // name of the item sold (e.g. Pants, Shoes, Hat)
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


        // quantity bought
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

        // money spent buying products
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

        // date of purchase
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

        // history constructor (3 params required)
        public History(string name, int quantity, double totalPrice, DateTime purchaseDate)
        {
            this.name = name;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
            this.purchaseDate = purchaseDate;
        }
    }
}
