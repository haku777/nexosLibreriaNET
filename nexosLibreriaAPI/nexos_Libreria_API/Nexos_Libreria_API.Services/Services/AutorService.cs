using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nexos_Libreria_API.Common.Dto.Autors;
using Nexos_Libreria_API.DataAccess;
using Nexos_Libreria_API.DataAccess.Entity;
using Nexos_Libreria_API.Services.Services.Interfaces;

namespace Nexos_Libreria_API.Services.Services
{
    public class AutorService : IAutors
    {
        private readonly LibreriaContext _context;
        private readonly IMapper _mapper;
        public AutorService(LibreriaContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<AutorsDto>> Get()
        {
            var autors = await _context.Autores.ToListAsync();
            
            List<AutorsDto> listAutors = new List<AutorsDto>();

            foreach (Autores autor in autors) {
                   AutorsDto autorItem = _mapper.Map<AutorsDto>(autor);

                listAutors.Add(autorItem);
            }

            return listAutors;
        }


        public async Task<AutorsDto> GetById(int Id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a=>a.Id == Id);
            AutorsDto mapAutor = _mapper.Map<AutorsDto>(autor);
            return mapAutor;
        }

        public async Task<AutorsDto> AddAutor(AutorsCreateDto book)
        {
            var newBook = _mapper.Map<Autores>(book);
            var result = await _context.Autores.AddAsync(newBook);
            await _context.SaveChangesAsync();
            AutorsDto newBookAdded = await GetById(result.Entity.Id);
            return newBookAdded;
        }
  
        public async Task UpdateAutor(AutorsUpdateDto Autor)
        {
            var xd = _context.Autores.FirstOrDefault(a=>a.Id == Autor.Id);
            if (xd != null) {
                xd.Nombre_completo = Autor.Nombre_completo;
                xd.Fecha_nacimiento = Autor.Fecha_nacimiento;
                xd.Ciudad_procedencia = Autor.Ciudad_procedencia;
                xd.Correo_electronico = Autor.Correo_electronico;
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAutor(AutorsDto autor) 
        {
            var findAutor = _context.Autores.FirstOrDefault(a=>a.Id == autor.Id);
            if(findAutor != null)
            {
                _context.Autores.Remove(findAutor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
