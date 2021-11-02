using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Abstractions
{
    public interface IUnitOfWork
    {

        IBookRepository BookRepository { get; }

    }
}
