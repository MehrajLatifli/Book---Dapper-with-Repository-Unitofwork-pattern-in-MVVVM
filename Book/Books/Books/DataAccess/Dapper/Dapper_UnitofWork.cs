using Books.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Dapper
{
    public class Dapper_UnitofWork : IUnitOfWork
    {
        public IBookRepository BookRepository => new Dapper_BookRepository();

    }
}
