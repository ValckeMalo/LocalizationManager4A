using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
	public struct LocalizationItem
	{
		public string Key { get; set; }
		public List<string> Languages { get; set; }

		public LocalizationItem()
		{
			Languages = new List<string>();
		}
	}
}
