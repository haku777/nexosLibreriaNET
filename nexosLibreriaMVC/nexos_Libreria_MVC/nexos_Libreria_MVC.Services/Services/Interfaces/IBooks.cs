using nexos_Libreria_MVC.Common.Dto;

namespace nexos_Libreria_MVC.Services.Services.Interfaces
{
    public interface IBooks
    {
        public Task<IList<BookDto>> Get();
    }
}
