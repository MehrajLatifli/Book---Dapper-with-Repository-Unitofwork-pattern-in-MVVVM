using Books.Commands;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Books.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainWindow MainWindows { get; set; }

        public RelayCommand OnlyNumberCommand1 { get; set; }

        public RelayCommand OnlyNumberCommand2 { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public RelayCommand LoadedCommand { get; set; }

        private ObservableCollection<Book> allBooks;

        public ObservableCollection<Book> AllBooks
        {
            get { return allBooks; }
            set { allBooks = value; OnPropertyChanged(); }
        }


        private Book _Book;

        public Book Book
        {
            get { return _Book; }
            set { _Book = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            AllBooks = App.DB.BookRepository.GetAllData();

            LoadedCommand = new RelayCommand((sender) =>
            {
                MainWindows.Booklistview.ItemsSource = AllBooks;

                AllBooks = App.DB.BookRepository.GetAllData();

            });

            OnlyNumberCommand1 = new RelayCommand((sender) =>
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(MainWindows.BookPriceTxt.Text, @"[^0-9.]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    MainWindows.BookPriceTxt.Text = MainWindows.BookPriceTxt.Text.Remove(MainWindows.BookPriceTxt.Text.Length - 1);
                }

            });

            OnlyNumberCommand2 = new RelayCommand((sender) =>
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(MainWindows.BookQuantityTxt.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    MainWindows.BookQuantityTxt.Text = MainWindows.BookQuantityTxt.Text.Remove(MainWindows.BookQuantityTxt.Text.Length - 1);
                }

            });


            AddCommand = new RelayCommand((sender) =>
            {
                if (MainWindows.BookNameTxt.Text != string.Empty && MainWindows.BookQuantityTxt.Text != string.Empty && MainWindows.BookQuantityTxt.Text != string.Empty)
                {
                    Book = new Book();

                    Book.BookName = MainWindows.BookNameTxt.Text;
                    Book.BookPrice = decimal.Parse(MainWindows.BookPriceTxt.Text);
                    Book.BookQuantity = long.Parse(MainWindows.BookQuantityTxt.Text);


                    App.DB.BookRepository.AddData(Book);


                    AllBooks = App.DB.BookRepository.GetAllData();
                }


            });


            DeleteCommand = new RelayCommand((sender) =>
            {
        

                App.DB.BookRepository.DeletaData(Book);


                AllBooks = App.DB.BookRepository.GetAllData();

                Book = new Book();

            });


            UpdateCommand = new RelayCommand((sender) =>
            {
                var s = new Book();
                 s = MainWindows.Booklistview.SelectedItem as Book;


                if (MainWindows.BookNameTxt.Text != string.Empty && MainWindows.BookQuantityTxt.Text != string.Empty && MainWindows.BookQuantityTxt.Text != string.Empty)
                {
                    s.BookName = MainWindows.BookNameTxt.Text;
                    s.BookPrice = decimal.Parse(MainWindows.BookPriceTxt.Text);
                    s.BookQuantity = long.Parse(MainWindows.BookQuantityTxt.Text);

                    App.DB.BookRepository.UpdateData(s);

                    AllBooks = App.DB.BookRepository.GetAllData();


                    Book = new Book();
                }

            });

        }

  
    }
}
