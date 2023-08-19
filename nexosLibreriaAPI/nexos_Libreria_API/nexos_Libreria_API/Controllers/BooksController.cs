using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
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
        private LibreriaContext _context;
        private IBooks _book;
        public BooksController
            (
                LibreriaContext context
                , IBooks book
            )
        {
            _context = context;
            _book = book;
        }

        [HttpGet]
        public Task<Libros> Get()
        {
            return _book.Get();
        }



        [HttpGet]
        public Task<Libros> GetById(int id) {
            return _book.GetById(id);
            
        }
        
        [HttpPost]
        [Route("saveBook")]
        public  IActionResult AddBook(BookDto book)
        {
            if (book != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest(Message.EmptyData);
            }
            //[HttpPost]
            //public async Task<IActionResult> Add(Libros libros) {
            //    //var listaLibros = new List<Libros>();
            //    //listaLibros.Add(libros);
            //    //var crearlibro = await _libros.
            //    //return await Ok();
            //}
        }


        //mapeo manual
        [HttpPost]
        [Route("Other")]
        public  ActionResult Other([FromBody] BookDto book)
        {
            _book.Other(book);
            return  Ok();
        }



        //[HttpPost(ApiRoutes.BpmAdmin.CreateProcess)]
        //public async Task<IActionResult> CreateProcess([FromBody] AdminProcessDto request)
        //{
        //    var errors = _validatorRunProcess.Validate(request);
        //    if (errors != null)
        //        throw new EpxValidationException(errors);

        //    await _processService.CreateProcess(request);
        //    return Ok();
        //}
    }
}
