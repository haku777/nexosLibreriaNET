using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexos_Libreria_MVC.Services.Services
{
    public abstract class ApiPath
    {
        public string UrlApi;
        public ApiPath() 
        { 
            UrlApi = string.Empty;
        }
    }
}