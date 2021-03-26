using NUnit.Framework;
using RestSharp;

namespace TestApi
{
    public class AlphabeticDescTest
    {

        [Test]
        public void Test_OrdererText_true()
        {
            string frase = "hola como estas";
            string opcionCombo = "AlphabeticDesc";            

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);      
            Assert.IsTrue(response.Content.Equals("[\"hola\",\"estas\",\"como\"]"));
        }

        [Test]
        public void Test_OrdererText_false()
        {
            string frase = "hola como estas";
            string opcionCombo = "AlphabeticDesc";

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            Assert.IsFalse(response.Content.Equals("[\"hola\",\"como\",\"estas\"]"));
        }

        [Test]
        public void Test_OrdererText_null()
        {
            string frase = null;
            string opcionCombo = "AlphabeticDesc";

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            Assert.IsFalse(response.Content.Equals("[\"hola\",\"como\",\"estas\"]"));
        }
    }
}