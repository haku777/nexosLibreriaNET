using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using nexos_Libreria_API.Services.Interfaces;
using Nexos_Libreria_API.Common.Constants;
using Nexos_Libreria_API.Common.Dto;
using Nexos_Libreria_API.DataAccess;
using Nexos_Libreria_API.DataAccess.Entity;

namespace nexos_Libreria_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private LibreriaContext _context;
        private readonly IMapper _mapper;
        private readonly int maxBooks = 5;
        private IBooks _book;
        public BooksController
            (
                LibreriaContext context
                ,ILogger logger
                ,IMapper mapper
                ,IBooks book
            )
        {
            _context = context;
            _mapper = mapper;
            _book = book;
        }


        //inicialmente se utiliza la entidad, pero por tiempo solo se agregan las interfaces
        //para continuar el desarrollo desde un servicio utilizando las dto
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<BookDto>>> Get()
        {
            _logger.LogInformation("Obtener los libros");

            //var result = await _book.Get();
            var listBooks = await _context.Libros.ToListAsync();

            return Ok(_mapper.Map<BookDto>(listBooks));
        }


        [HttpGet("Id:int", Name ="GetById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Task<BookDto>>> GetById(int Id) {
            if(Id==0)
                   return BadRequest();

            //var result = await _book.GetById(id);
            var result = await _context.Libros.FirstOrDefaultAsync( b => b.Id == Id );
            if (result == null)
                return NotFound();
            
            return Ok(_mapper.Map<BookDto>(result));
        }
        

        [HttpPost]
        [Route("AddBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BookDto>> AddBook([FromBody] BookCreateDto book)
        {
            if (_context.Libros.Count() == maxBooks) { 
                ModelState.AddModelError("LimiteLibros", "No es posible registrar el\r\nlibro, se alcanzó el máximo permitido");
                return BadRequest(ModelState);
            }

            if (await _context.Libros.FirstOrDefaultAsync(b => b.Titulo.ToLower() == book.Titulo.ToLower()) != null) { 
                ModelState.AddModelError("LibroExiste", "El libro ya existe");
                return BadRequest(ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (book == null)
                return BadRequest(book);
            
            Libros newBook = _mapper.Map<BookCreateDto>(book);

            await _context.Libros.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetById", new { id = newBook.Id }, newBook);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> updateBook(int Id, [FromBody] BookUpdateDto book) {
            if (book == null || Id != book.Id)
                return BadRequest();

            Libros updateBook = _mapper.Map<BookUpdateDto>(book);

            _context.Libros.Update(updateBook);
            await _context.SaveChangesAsync();

            return NoContent();

        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var book = await _context.Libros.FirstOrDefaultAsync(b => b.Id == Id);
            if (book == null)
                return NotFound();

            _context.Libros.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //mapeo manual
        [HttpPost]
        [Route("Other")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  ActionResult Other([FromBody] BookDto book)
        {
            _book.Other(book);
            return  Ok();
        }

        //_context.Libros.Add(book);
        //async await
    }
}
