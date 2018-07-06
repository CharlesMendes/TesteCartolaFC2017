using RestSharp;
using System;
using System.Collections.Specialized;

namespace com.charlesmendes.testeCartolaFC
{
    class Program
    {
        static void Main(string[] args)
        {
            RunRestSharp();
            //GetToken();
            //AuthLiga("corinthians");
            AuthLiga("4food-league");
        }

        static void RunRestSharp()
        {
            var client = new RestClient("http://api.cartolafc.globo.com");
            client.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.81 Safari/537.36";
            var request = new RestRequest("mercado/status", Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string

            Console.Write(content);

            Console.Read();
        }

        static void GetToken()
        {
            var client = new RestClient("https://login.globo.com/api");
            client.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.81 Safari/537.36";
            var request = new RestRequest("authentication", Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddBody("{\"email\":\"INFORMAR_EMAIL\", \"password\":\"INFORMAR_SENHA\", \"serviceId\":\"4728\"}");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Console.Write(content);

            Console.Read();
        }

        static void AuthLiga(string liga)
        {
            var client = new RestClient("https://api.cartolafc.globo.com/auth");
            client.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.81 Safari/537.36";
            var request = new RestRequest("liga/{_liga}", Method.GET);
            request.AddUrlSegment("_liga", liga);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-glb-token", "1d36fcac7e239f41e3df3421e33bc1f7074556e6537575a65734574554e6567764763774556525237576c4b6a435761316e476b453346742d4777774153326655324a304e5832755651475272714b4e543238724c746c50577535516c7a77766e5668795446673d3d3a303a636f6e7461746f2e6d656e6465732e32303132");
            request.RequestFormat = DataFormat.Json;

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            Console.Write(content);

            Console.Read();
        }
    }
}
