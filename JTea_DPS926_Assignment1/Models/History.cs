using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace JTea_DPS926_Assignment1
{
    public class History : Product, INotifyPropertyChanged
    {
        // property change event implementation
        public event PropertyChangedEventHandler HistoryPropertyChanged;

        // backing fields
        private DateTime _purchaseDate;

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

                if (HistoryPropertyChanged != null)
                {
                    HistoryPropertyChanged(this, new PropertyChangedEventArgs(nameof(purchaseDate)));
                }
            }
        }

        // historical record constructor (4 required parameters)
        public History(string name, int quantity, double totalPrice, DateTime purchaseDate) : base(name, quantity, totalPrice)
        {
            this.purchaseDate = purchaseDate;
        }
    }
}
