using Microsoft.AspNetCore.Mvc;
using Nexos_Libreria_API.DataAccess;
using Nexos_Libreria_API.DataAccess.Entity;

namespace Nexos_Libreria_API.Controllers
{
    //[ApiController]
    //[Route("api/controller")]
    public class AutorsController : Controller
    {
        private LibreriaContext _context;
        public AutorsController(LibreriaContext contex) {
            _context = contex;
        }

        [HttpGet]
        [Route("Autors")]
        public IList<Autores> Get() => _context.Autores.Get().ToList();





    }



}
