using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace API.Services
{
    public class VirtualStoreUserService
    {
        string urlBaseApi = "https://serverest.dev/";

        public string CreateUser(Table table)
        {
            var tableUser = table.CreateSet<ResponseDadosUser>();
            string userId = "";

            var restClient = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/usuarios", Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;

            foreach (ResponseDadosUser item in tableUser)
            {
                restRequest.AddJsonBody(new { nome = item.nome, email = item.email, password = item.password, administrador = item.administrador });
                IRestResponse response = restClient.Execute(restRequest);
                var content = response.Content;
                
                var responseObj = JsonConvert.DeserializeObject<ResponseUser>(content);
                userId = responseObj._id.ToString();
            }

            Console.WriteLine("Created user Id: " + userId);
            return userId;
        }

        public void CheckNewUser(string idNewUser)
        {
            string name;
            string email;
            string passwd;
            string admin;

            var restCheckClient = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/usuarios/" + idNewUser, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse restResponse = restCheckClient.Execute(restRequest);
            ResponseDadosUser responseDadosUser = new JsonDeserializer().Deserialize<ResponseDadosUser>(restResponse);

            name = responseDadosUser.nome;
            email = responseDadosUser.email;
            passwd = responseDadosUser.password;
            admin = responseDadosUser.administrador;

            Console.WriteLine("Registered user data: "+idNewUser+", " + name+", "+email+", "
                +passwd+", "+admin);

            Assert.AreEqual(name, "Celine Dion");
            Assert.AreEqual(email, "celine@gmail.com");
            Assert.AreEqual(passwd, "titanic");
            Assert.AreEqual(admin, "true");
        }

        public string GerToken(string user, string passwd)
        {
            var restLogin = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/login", Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddJsonBody(new { email = user, password = passwd });

            IRestResponse response = restLogin.Execute(restRequest);
            var content = response.Content;
            var responseObj = JsonConvert.DeserializeObject<ResponseToken>(content);
            var token = responseObj.authorization;

            return token;
        }

        public void DeleteUser(string idDeleteUser)
        {
            string msg = "";

            var restCheckClient = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/usuarios/" + idDeleteUser, Method.DELETE) { RequestFormat = DataFormat.Json };
            IRestResponse restResponse = restCheckClient.Execute(restRequest);
            
            var content = restResponse.Content;

            var responseObj = JsonConvert.DeserializeObject<ResponseUser>(content);
            msg = responseObj.message.ToString();

            Console.WriteLine("Returned message: " + msg);
            Assert.AreEqual(msg, "Registro excluído com sucesso");
        }
    }
}
