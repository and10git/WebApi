using NUnit.Framework;
using RestSharp;

namespace TestApi
{
    public class AlphabeticAsTest
    {

        [Test]
        public void Test_OrdererText_true()
        {
            string frase = "hola como estas";
            string opcionCombo = "AlphabeticAs";            

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);      
            Assert.IsTrue(response.Content.Equals("[\"como\",\"estas\",\"hola\"]"));
        }

        [Test]
        public void Test_OrdererText_false()
        {
            string frase = "hola como estas";
            string opcionCombo = "AlphabeticAs";

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            Assert.IsFalse(response.Content.Equals("[\"hola\",\"estas\",\"como\"]"));
        }

        [Test]
        public void Test_OrdererText_all_null()
        {
            string frase = null;
            string opcionCombo = null;

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            Assert.IsFalse(response.Content.Equals("[\"hola\",\"estas\",\"como\"]"));
        }
    }
}