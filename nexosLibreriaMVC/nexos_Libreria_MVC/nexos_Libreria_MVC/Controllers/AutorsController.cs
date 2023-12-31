﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using nexos_Libreria_MVC.Models;

namespace nexos_Libreria_MVC.Controllers
{
    public class AutorsController : Controller
    {
        private readonly HttpClient _httpClient;
        public AutorsController()
        {
            _httpClient = new HttpClient();
        }


        public async Task<IActionResult> Index()
        {

            //en lugar de de hacer el llamado al api desde aqui se hace mejor en una interfaz
            // al services etc
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7127/api/Autors/GetAutors");





            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Autors>>(jsonData);
                return View(data);
            }
            return View();
        }
    }
}
