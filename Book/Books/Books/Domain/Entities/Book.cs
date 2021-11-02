using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Entities
{
    public class Book : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public Book()
        {

        }

        public int _IdBook;

        public int IdBook
        {
            get { return _IdBook; }
            set { _IdBook = value; OnpropertyChanged(); }
        }

        public string _BookName;

        public string BookName
        {
            get { return _BookName; }
            set { _BookName = value; OnpropertyChanged(); }
        }

        public decimal _BookPrice;

        public decimal BookPrice
        {
            get { return _BookPrice; }
            set { _BookPrice = value; OnpropertyChanged(); }
        }

        public long _BookQuantity;

        public long BookQuantity
        {
            get { return _BookQuantity; }
            set { _BookQuantity = value; OnpropertyChanged(); }
        }

     

        public override string ToString()
        {
            return $" {BookName}  {BookPrice}  {BookQuantity} ";
        }
    }
}
