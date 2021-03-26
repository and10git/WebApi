using System.Collections.Generic;
using static WebApiM.Modules.OptionsService;

namespace WebApiM.Modules
{
    public interface IOptionService
    {

        public IList<string> OrderOptions();

        public List<string> OrdererText(string TextToOrder, OptionOrders OrderOption);

        public TextStatistics GetTextStatistics(string textToAnalize);
    }
}