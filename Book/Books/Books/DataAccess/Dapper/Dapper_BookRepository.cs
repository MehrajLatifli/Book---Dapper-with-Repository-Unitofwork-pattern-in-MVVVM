using Books.Domain.Abstractions;
using Books.Domain.Additional_Classes;
using Books.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Dapper
{
    public class Dapper_BookRepository : IBookRepository
    {
        public void AddData(Book data)
        {
            using (var connection = new SqlConnection($"{App.ConnectionString}"))
            {
                connection.Open();

                connection.Execute($@"insert into BookDapper.dbo.Books(BookDapper.dbo.Books.BookName, BookDapper.dbo.Books.BookPrice, BookDapper.dbo.Books.BookQuantity)
                                   values (@BookName, @BookPrice, @BookQuantity)", new { BookName = data.BookName, BookPrice = data.BookPrice, BookQuantity=data.BookQuantity });
            }


 
        }

        public void DeletaData(Book data)
        {
            using (var connection = new SqlConnection($"{App.ConnectionString}"))
            {
                connection.Open();

                if (data != null)
                {
                    connection.Execute(@"Delete From BookDapper.dbo.Books where BookDapper.dbo.Books.IdBook=@PId", new { PId = data.IdBook });
                }
            }
        }

        public ObservableCollection<Book> GetAllData()
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection($"{App.ConnectionString}"))
            {
                connection.Open();

                books = connection.Query<Book>("select BookDapper.dbo.Books.IdBook, BookDapper.dbo.Books.BookName, BookDapper.dbo.Books.BookPrice, BookQuantity from BookDapper.dbo.Books").ToList();
            }
                return ObservableCollectionHelper.ToObservableCollection(books);
        }

        public Book GetData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Book data)
        {
            using (var connection = new SqlConnection($"{App.ConnectionString}"))
            {
                connection.Open();

                if (data != null)
                {
                    connection.Execute(@"
                    update BookDapper.dbo.Books
                    set 
                    BookDapper.dbo.Books.BookName = @_BookName,
                    BookDapper.dbo.Books.BookPrice = @_BookPrice,
                    BookDapper.dbo.Books.BookQuantity = @_BookQuantity
                    where
                    BookDapper.dbo.Books.IdBook = @_IdBook", new { _IdBook = data.IdBook, _BookName=data.BookName, _BookPrice=data.BookPrice, _BookQuantity =data.BookQuantity, });
                }
            }
        }
    }
}
