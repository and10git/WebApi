using NUnit.Framework;
using RestSharp;

namespace TestApi
{
    public class LengthAscTest
    {

        [Test]
        public void Test_OrdererText_true()
        {
            string frase = "holaaaaaaa comooo estas";
            string opcionCombo = "LengthAsc";            

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);      
            Assert.IsTrue(response.Content.Equals("[\"estas\",\"comooo\",\"holaaaaaaa\"]"));
        }

        [Test]
        public void Test_OrdererText_false()
        {
            string frase = "hola como estas";
            string opcionCombo = "LengthAsc";

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            Assert.IsFalse(response.Content.Equals("[\"holaaaaaaa\",\"estas\",\"comooo\"]"));
        }

        [Test]
        public void Test_OrdererText_empty()
        {
            string frase = "";
            string opcionCombo = "LengthAsc";

            var client = new RestClient("https://localhost:44393");
            var request = new RestRequest("/api/OrdererText", Method.GET);
            request.AddParameter("textToOrder", frase);
            request.AddParameter("orderOptionParam", opcionCombo);
            var response = client.Execute(request);
            Assert.IsFalse(response.Content.Equals("[\"holaaaaaaa\",\"estas\",\"comooo\"]"));
        }
    }
}