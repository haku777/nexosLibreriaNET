using AutoMapper;
using Nexos_Libreria_API.Common.Dto;
using Nexos_Libreria_API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Nexos_Libreria_API.DataAccess.Entity;
using nexos_Libreria_API.Services.Interfaces;

namespace Nexos_Libreria_API.Services.Services
{
    public class BookService : IBooks
    {
        private LibreriaContext _context;
        public IMapper _mapper;
        public BookService(LibreriaContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public  async Task<List<BookDto>> Get()
        {
            var books =  await _context.Libros.ToListAsync();
            List<BookDto> booksList = new List<BookDto>();
            foreach (var book in books) {
                var bookItem = _mapper.Map<BookDto>(book);
                booksList.Add(bookItem);
            }

            return booksList;
        }


        public async Task<BookDto> GetById(int Id)
        {
            var book = await _context.Libros.FirstOrDefaultAsync(b => b.Id == Id);
            BookDto mapBook = _mapper.Map<BookDto>(book);
            return mapBook;
        }

        public async Task<BookDto> AddBook(BookCreateDto book)
        {

            Libros newBook = _mapper.Map<Libros>(book);
            var result = await _context.Libros.AddAsync(newBook);
            await _context.SaveChangesAsync();
            BookDto newBookAdded = await GetById(result.Entity.Id);
            return newBookAdded;
        }

        public async Task UpdateBook(BookUpdateDto book)
        {
            var existingBook = _context.Libros.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Titulo = book.Titulo;
                existingBook.Fecha = book.Fecha;
                existingBook.Genero = book.Genero;
                existingBook.Numero_de_paginas = book.N_paginas;
                existingBook.Id_Autor = book.Id_Autor;
                await _context.SaveChangesAsync();
            }
        }

        public void DeleteBook(BookDto book) {
            var findBook = _context.Libros.FirstOrDefault(a => a.Id == book.Id);
            if (findBook != null)
            {
                _context.Libros.Remove(findBook);
                _context.SaveChanges();
            }
        }

        //mapeo manual
        //public void Other(BookDto book)
        //{
        //    var mapBook = new Libros
        //    {
        //        Titulo = book.Titulo,
        //        Fecha = book.Fecha,
        //        Genero = book.Genero,
        //        Numero_de_paginas = book.Numero_de_paginas,
        //    };
        //    _context.Libros.Add(mapBook);
        //}
    }
}
