using Microsoft.Extensions.Configuration;
using nexos_Libreria_MVC.Common.Dto;
using nexos_Libreria_MVC.Services.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using static System.Reflection.Metadata.BlobBuilder;

namespace nexos_Libreria_MVC.Services.Services.Api
{
    public class AutorsApiServices
    {

        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly IapiPath _apiPath;

        public AutorsApiServices(IConfiguration configuration, IapiPath apiPath) {
            
            _configuration = configuration;
            _apiPath = apiPath;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7127/");
        }

        //autors
        //GET /api/Autors/GetAutors
        //GET /api/Autors/GetAutorById
        //POST /api/Autors/AddAutor
        //PUT /api/Autors/UpdateAutor
        //DELETE /api/Autors/DeleteAutor

        public async Task<IList<BookDto>> Get()
        {
            string path = _apiPath.GetApiPath();
            HttpResponseMessage response = await _httpClient.GetAsync(path + "/api/Books/GetBooks");
            
            if (response.IsSuccessStatusCode)
            {
                //var jsonData = await response.Content.ReadAsStringAsync();
                //var data = JsonConvert.DeserializeObject<List<BookDto>>(jsonData);
                //return data;

                IList<BookDto> books = new List<BookDto>();
                return books;
            }
            else
            {
                throw new Exception("xd");
            }
        }
    }
}
