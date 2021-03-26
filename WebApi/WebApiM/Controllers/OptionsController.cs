using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiM.Modules;
using static WebApiM.Modules.OptionsService;

namespace WebApiM.Controllers
{
    [ApiController]

    public class OrderedTextController : ControllerBase
    {
        private OptionsService _optionsService = new OptionsService();        

        [Route("api/OrderOptions")]
        [HttpGet]
        public IList<string> OrderOptions()
        {
            return _optionsService.OrderOptions();
        }

        [Route("api/OrdererText")]
        [HttpGet]
        public IList<string> OrdererText(string textToOrder, string orderOptionParam)
        {       
            var optionOrdersParam= OptionOrders.AlphabeticAs;

            if (OptionOrders.AlphabeticAs.ToString().Equals(orderOptionParam))
                optionOrdersParam  = OptionOrders.AlphabeticAs;

            if (OptionOrders.AlphabeticDesc.ToString().Equals(orderOptionParam))
                optionOrdersParam = OptionOrders.AlphabeticDesc;

            if (OptionOrders.LengthAsc.ToString().Equals(orderOptionParam))
                optionOrdersParam = OptionOrders.LengthAsc;

            return _optionsService.OrdererText(textToOrder, optionOrdersParam);
        }

        [Route("api/Statictis")]
        [HttpGet]
        public string Statictis(string textToAnalyze)
        {
            var res = _optionsService.GetTextStatistics(textToAnalyze);
            string json = JsonConvert.SerializeObject(res).ToString().Trim();
            return json;

        }
    }
}
