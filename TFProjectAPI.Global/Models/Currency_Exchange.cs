using System;

namespace TFProjectAPI.Global.Models
{
    public class Currency_Exchange
    {
		public int Id { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public string CurrFrom { get; set; }
		public string CurrTo { get; set; }
		public float Rate { get; set; }
	}
}
