using Microsoft.AspNetCore.Mvc;
using Nexos_Libreria_API.Common.Dto.Autors;

namespace Nexos_Libreria_API.Services.Services.Interfaces
{
    public interface IAutors
    {
        Task<List<AutorsDto>> Get();
        Task<AutorsDto> GetById(int Id);
        Task UpdateAutor(AutorsUpdateDto Autor);
        Task<AutorsDto> AddAutor(AutorsCreateDto Autor);
        void DeleteAutor(AutorsDto Autor);
    }

}
