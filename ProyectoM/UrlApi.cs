using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoM
{
    class UrlApi :IUrlApi
    {
        private string _urlApi = "https://localhost:44393"; 

        public string getUrlApi()
        {
            return _urlApi;
        }
    }
}
