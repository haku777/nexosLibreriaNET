using Nexos_Libreria_API.Common.Dto;

namespace nexos_Libreria_API.Services.Interfaces
{
    public interface IBooks
    {
        Task<List<BookDto>> Get();
        Task<BookDto> GetById(int Id);
        void UpdateBook(BookUpdateDto Book);
        Task<BookDto> AddBook(BookCreateDto Book);
        void DeleteBook(BookDto book);

        //void Other(BookDto libros);
    }
}
