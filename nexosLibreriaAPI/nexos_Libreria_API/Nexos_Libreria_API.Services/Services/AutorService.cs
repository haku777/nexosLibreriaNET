using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexos_Libreria_API.Common.Dto;
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
        //el metodo update no esta funcionando correctamente 
        //'The instance of entity type 'Autores' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked.  
        public async Task UpdateAutor(AutorsUpdateDto Autor)
        {
            var mapAutor = _mapper.Map<Autores>(Autor);
            _context.Autores.Update(mapAutor);
            await _context.SaveChangesAsync();
        }


        public void DeleteAutor(AutorsDto autor) 
        {
            var findAutor = _context.Autores.FirstOrDefault(a=>a.Id == autor.Id);
            if(findAutor != null)
            {
                _context.Autores.Remove(findAutor);
                _context.SaveChangesAsync();
            }
        }
    }
}
