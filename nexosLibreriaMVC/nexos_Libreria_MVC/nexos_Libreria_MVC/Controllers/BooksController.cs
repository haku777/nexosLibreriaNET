using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using nexos_Libreria_MVC.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nexos_Libreria_MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILogger<BooksController> _logger;
        private readonly HttpClient _httpClient;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7127/");
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7127/api/Books/GetBooks");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Books>>(jsonData);
                return View(data);
            }
            return View();
        }

        public async Task<IActionResult> AddBook()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7127/api/Books/GetBooks");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Books>>(jsonData);
                //return View(data);
            }
            return View();
        }







    }
}