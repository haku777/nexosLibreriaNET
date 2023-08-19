using Microsoft.Extensions.Configuration;
using nexos_Libreria_MVC.Common.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexos_Libreria_MVC.Services.Services.Api
{
    internal class BooksApiServices
    {
        public string ApiPath = "https://localhost:7127";
        public BooksApiServices() {

            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //public string api_Path= builder.GetSection("ApiConfiguration:ApiPath").Value;
        }


        //public async IList<BookDto> Get(string path) {
        
        
        //return await xd
        //}
    }
}
