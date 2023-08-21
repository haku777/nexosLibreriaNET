using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nexos_Libreria_API.Common.Dto;
using nexos_Libreria_API.Services.Interfaces;
using Nexos_Libreria_API.Services.Services.Interfaces;
using Nexos_Libreria_API.Common.Dto.Autors;
using Nexos_Libreria_API.DataAccess.Entity;

namespace nexos_Libreria_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IMapper _mapper;
        private readonly int maxBooks = 5;
        private IBooks _book;
        private IAutors _autor;
        public BooksController
            (
                ILogger<BooksController> logger
                ,IMapper mapper
                ,IBooks book
                ,IAutors autor
            )
        {
            _logger = logger;
            _mapper = mapper;
            _book = book;
            _autor = autor;
        }


        [HttpGet]
        [Route("GetBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BookDto>>> GetBooks()
        {
            _logger.LogInformation("Obtener los libros");
            var result = await _book.Get();
            return Ok(result);
        }


        [HttpGet]
        [Route("GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> GetBookById(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var result = await _book.GetById(Id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [Route("AddBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BookDto>> AddBook([FromBody] BookCreateDto book)
        {
            var getListbooks = await _book.Get();
            if (getListbooks.Count() == maxBooks)
            {
                ModelState.AddModelError("LimiteLibros", "No es posible registrar el libro, se alcanzó el máximo permitido");
                return BadRequest(ModelState);
            }
            if (getListbooks.Where(b => b.Titulo.ToLower() == book.Titulo.ToLower()).FirstOrDefault() != null)
            {
                ModelState.AddModelError("LibroExiste", "El libro ya existe");
                return BadRequest(ModelState);
            }
            try
            {
                AutorsDto autor =await _autor.GetById(book.Id_Autor);
                if (autor == null)
                {
                    ModelState.AddModelError("AutorNoValido", "El autor no existe");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex){
                return BadRequest(ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (book == null)
                return BadRequest(book);

            var newBook = await _book.AddBook(book);
            //return CreatedAtRoute("GetBookById", new { id = newBook.Id }, newBook);
            return newBook;
        }


        [HttpPut]
        [Route("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> updateBook(int Id, [FromBody] BookUpdateDto book)
        {
            if (book == null || Id != book.Id)
                return BadRequest();

            if (await _autor.GetById(book.Id) != null) { 
                ModelState.AddModelError("AutorNoValido","El Autor no existe");
                return BadRequest();
            }
            _book.UpdateBook(book);
            return NoContent();
        }

        //solo para pruebas
        [HttpDelete]
        [Route("DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBook(int Id)
        {
            if (Id == 0)
                return BadRequest();

            var book = await _book.GetById(Id);
            if (book == null)
                return NotFound();

            _book.DeleteBook(book);

            return NoContent();
        }

        ////mapeo manual
        //[HttpPost]
        //[Route("Other")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public  ActionResult Other([FromBody] BookDto book)
        //{
        //    _book.Other(book);
        //    return  Ok();
        //}

        //_context.Libros.Add(book);
        //async await
    }
}
