using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexos_Libreria_API.Common.Dto;

namespace nexos_Libreria_API.Services.Interfaces
{
    public interface IBooks
    {
        IList<BookDto> Get();
        Task<BookDto> GetById(int Id);
        Task<BookDto> AddBook(BookDto libros);
        void Other(BookDto libros);
    }
}
