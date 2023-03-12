using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RestSharp.Serialization.Json;
using NUnit.Framework;

namespace API.Services
{
    public class VirtualStoreProductService
    {

        string urlBaseApi = "https://serverest.dev/";

        public string CreateProduct(Table table, string tokenProduct)
        {
            var tableProduct = table.CreateSet<ResponseDadosProduct>();
            string productId = "";

            var restProduct = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/produtos", Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", tokenProduct);
            restRequest.RequestFormat = DataFormat.Json;

            foreach (ResponseDadosProduct item in tableProduct)
            {
                restRequest.AddJsonBody(new { nome = item.nome, preco = item.preco, descricao = item.descricao, quantidade = item.quantidade });
                IRestResponse response = restProduct.Execute(restRequest);
                var content = response.Content;

                var responseObj = JsonConvert.DeserializeObject<ResponseProduct>(content);
                productId = responseObj._id.ToString();
            }

            Console.WriteLine("Created product Id: " + productId);
            return productId;
        }

        public void CheckNewProduct(string idNewProduct)
        {
            string name;
            string price;
            string description;
            string amount;

            var restCheckClient = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/produtos/" + idNewProduct, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse restResponse = restCheckClient.Execute(restRequest);
            ResponseDadosProduct responseDadosUser = new JsonDeserializer().Deserialize<ResponseDadosProduct>(restResponse);

            name = responseDadosUser.nome;
            price = responseDadosUser.preco;
            description = responseDadosUser.descricao;
            amount = responseDadosUser.quantidade;

            Console.WriteLine("Registered product data: " + idNewProduct + ", " + name + ", " + price + ", "
                + description + ", " + amount);

            Assert.AreEqual(name, "Dell Vostro 5170");
            Assert.AreEqual(price, "5405");
            Assert.AreEqual(description, "Notebook");
            Assert.AreEqual(amount, "5");

        }

        public void DeleteProduct(string idDeleteProduct, string tokenProduct)
        {
            string msg = "";

            var restCheckProduct = new RestClient(urlBaseApi);
            var restRequest = new RestRequest("/produtos/" + idDeleteProduct, Method.DELETE) { RequestFormat = DataFormat.Json };
            restRequest.AddHeader("Authorization", tokenProduct); 
            IRestResponse restResponse = restCheckProduct.Execute(restRequest);

            var content = restResponse.Content;

            var responseObj = JsonConvert.DeserializeObject<ResponseProduct>(content);
            msg = responseObj.message.ToString();

            Console.WriteLine("Returned message: " + msg);
            Assert.AreEqual(msg, "Registro excluído com sucesso");
        }

    }
}
