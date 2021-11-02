using Books.DataAccess.Dapper;
using Books.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Books
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;

        public static String ConnectionString = "Data Source=DESKTOP-H3L9NOH;Initial Catalog=BookDapper;User ID=sa;Password=sa1234";
        public App()
        {
            DB = new Dapper_UnitofWork();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
            }
        }
    }
}
