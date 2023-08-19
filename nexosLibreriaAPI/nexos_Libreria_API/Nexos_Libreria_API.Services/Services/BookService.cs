using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nexos_Libreria_API.Services.Interfaces;
using Nexos_Libreria_API.Common.Dto;
using Nexos_Libreria_API.DataAccess;
using Nexos_Libreria_API.DataAccess.Entity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Nexos_Libreria_API.Services.Services
{
    public class BookService : IBooks
    {
        private LibreriaContext _context;
        internal DbSet<Libros> _dbLibros;
        public IMapper _mapper;
        public BookService(LibreriaContext context, IMapper mapper, DbSet<Libros> dbLibros) {
            _context = context;
            _dbLibros = dbLibros;
            _mapper = mapper;
        }

        //public async IList<BookDto> Get()
        //{
        //    Libros books = Libros.ToList();
        //    return _mapper.Map<BookService>(books);
        //}

        //public Task<BookDto> GetById(int Id)
        //{

        //    var result = _context.Libros.Where(x => x.Id == Id).FirstOrDefault();
        //    var map = _mapper.Map<Libros>(result);
        //    if (map != null)
        //    {
        //        return map;
        //    }
        //    else
        //    {
        //        return new BookDto();
        //    }
        //}

        //public async Task<BookDto> AddBook(BookDto book)
        //{
        //    await _dbLibros.AddAsync(book);
        //    var bookM = _mapper.Map<Libros>(book);
        //    return _context.Libros.Add(bookM);
        //}


        //public async Task updateBook(BookDto book)
        //{
        //    await _context.SaveChanges();
        //}


        public void Other(BookDto book)
        {
            var mapBook = new Libros
            {
                Titulo = book.Titulo,
                Fecha = book.Fecha,
                Genero = book.Genero,
                Numero_de_paginas = book.Numero_de_paginas,
            };
            _context.Libros.Add(mapBook);
        }

        public IList<BookDto> Get()
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> AddBook(BookDto libros)
        {
            throw new NotImplementedException();
        }
    }
}
