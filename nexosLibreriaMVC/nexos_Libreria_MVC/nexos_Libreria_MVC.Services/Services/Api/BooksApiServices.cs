using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using nexos_Libreria_MVC.Common.Dto;
using nexos_Libreria_MVC.Services.Services.Interfaces;

namespace nexos_Libreria_MVC.Services.Services.Api
{
    public class BooksApiServices : IBooks
    {

        private readonly HttpClient _httpClient;
        private readonly IapiPath _apiPath;

        public BooksApiServices(IapiPath apiPath) {
            
            _apiPath = apiPath;

            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("httpsss://localhost:7127/");
        }

        public async Task<IList<BookDto>> Get()
        {
            string path = _apiPath.GetApiPath();
            HttpResponseMessage response = await _httpClient.GetAsync(path + "/api/Books/GetBooks");
            
            List<BookDto> books = new List<BookDto>();
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<BookDto>>(jsonData);
                return data;
            }
            else
            {
                //throw new Exception("xd");
                return books;
            }
        }



        //Books
        //GET /api/Books/GetBooks
        //GET /api/Books/GetBookById
        //POST /api/Books/AddBook
        //PUT /api/Books/UpdateBook
        //DELETE /api/Books/DeleteBook
    }
}
