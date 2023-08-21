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

        public void UpdateAutor(AutorsUpdateDto Autor)
        {
            var mapAutor = _mapper.Map<Autores>(Autor);
            var result = _context.Autores.Update(mapAutor);
            var findAutor = _context.Autores.FirstOrDefault(a => a.Id == mapAutor.Id);
            if (findAutor != null)
            {
                _context.Autores.Update(findAutor);
                _context.SaveChangesAsync();
            }
        }


        public void DeleteAutor(AutorsDto autor) 
        {
            var mapAutor = _mapper.Map<Autores>(autor);
            var findAutor = _context.Autores.FirstOrDefault(a=>a.Id == mapAutor.Id);
            if(findAutor != null)
            {
                _context.Autores.Remove(findAutor);
                _context.SaveChangesAsync();
            }
        }
    }
}
