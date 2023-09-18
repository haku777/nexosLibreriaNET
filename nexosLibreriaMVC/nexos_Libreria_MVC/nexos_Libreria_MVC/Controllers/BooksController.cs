using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using nexos_Libreria_MVC.Models;
using nexos_Libreria_MVC.Services.Services.Interfaces;
using nexos_Libreria_MVC.Common.Dto;

namespace nexos_Libreria_MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooks _book;

        public BooksController(
            ILogger<BooksController> logger,
            IBooks book
            )
        {
            _logger = logger;
            _book = book;
        }

        public async Task<IActionResult> Index()
        {

                ViewBag.Process = "Wtf";
                var getBooks = await _book.Get();
                return View(getBooks);

        }

        public async Task<IActionResult> AddBook()
        {
            return View();
        }
    }
}