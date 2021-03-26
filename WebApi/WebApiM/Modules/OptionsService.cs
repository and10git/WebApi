using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiM.Modules
{

	public class TextStatistics  
	{
		private int _hyphensQuantity;
		private int _wordsQuantity;
		private int _spacesQuantity;

		public TextStatistics(int hyphens, int words, int spaces)
		{
			this._hyphensQuantity = hyphens;
			this._wordsQuantity = words;
			this._spacesQuantity = spaces;
		}

		public int HyphensQuantity { get { return this._hyphensQuantity; } }
		public int WordsQuantity { get { return this._wordsQuantity; } }
		public int SpacesQuantity { get { return this._spacesQuantity; } }

	}


	public class OptionsService : IOptionService
    {
		private List<string> _orderOptions;


		public enum OptionOrders
		{
			AlphabeticAs,
			AlphabeticDesc,
			LengthAsc
		}

		public IList<string> OrderOptions()
		{
			_orderOptions = new List<string>();
			foreach (var item in Enum.GetNames(typeof(OptionOrders)).ToList())
			{
				_orderOptions.Add(item);
			}

			return _orderOptions;
		}

		public List<string> OrdererText(string TextToOrder, OptionOrders OrderOption)
		{
			if(TextToOrder == null)
            {
				return new List<string>();
			}
            else
            {
				List<string> ret = TextToOrder.ToLower().Split(" ").ToList();

				switch (OrderOption)
				{
					case OptionOrders.AlphabeticAs:
						ret.Sort();
						break;

					case OptionOrders.AlphabeticDesc:
						ret.Sort();
						ret.Reverse();
						break;

					case OptionOrders.LengthAsc:
						ret = (from c in ret orderby c.Length ascending, c ascending select c).ToList();
						break;
				}

				return ret;
			}
			
		}

		public TextStatistics GetTextStatistics(string textToAnalize)
		{
			if (textToAnalize == null)
			{
				return new TextStatistics(0, 0, 0);
			}
			else
			{
				int hyphens = textToAnalize.Count(m => m == '-');
				int spaces = textToAnalize.Count(m => m == ' ');
				int words = textToAnalize.Split(" ").Count();

				return new TextStatistics(hyphens, spaces, words);
			}
		}

	
	}

}

