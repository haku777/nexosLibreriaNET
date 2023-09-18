using Microsoft.Extensions.Configuration;
using nexos_Libreria_MVC.Services.Services.Interfaces;

namespace nexos_Libreria_MVC.Services.Services
{
    public class ApiPath : IapiPath
    {
        private readonly IConfiguration _configuration;

        public ApiPath(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetApiPath()
        {
            return _configuration.GetSection("ApiConfiguration")["ApiPath"]??"";
        }
    }
}