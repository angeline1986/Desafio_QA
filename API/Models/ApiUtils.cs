using DocumentFormat.OpenXml.Drawing.Charts;
using System.Collections.Generic;

namespace API.Services
{
    public class ResponseToken
    {
        public string message { get; set; }
        public string authorization { get; set; }
    }

    public class ResponseUser
    {
        public string message { get; set; }
        public string _id { get; set; }
    }


    public class ResponseDadosUser
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string administrador { get; set; }
        public string _id { get; set; }
    }

    public class ResponseProduct
    {
        public string message { get; set; }
        public string _id { get; set; }
    }

    public class ResponseDadosProduct
    {
        public string nome { get; set; }
        public string preco { get; set; }
        public string descricao { get; set; }
        public string quantidade { get; set; }
        public string _id { get; set; }
    }

}