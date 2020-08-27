using System;
using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.CurrX
{
    public class Currency_Exchange
    {
		[Required]
		public DateTime DateFrom { get; set; }
		
		[Required]
		public DateTime DateTo { get; set; }
		
		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string CurrFrom { get; set; }
		
		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string CurrTo { get; set; }
		public float Rate { get; set; }
	}
}
