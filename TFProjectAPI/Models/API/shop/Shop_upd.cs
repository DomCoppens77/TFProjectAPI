using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using TFProjectAPI.Attributes;

namespace TFProjectAPI.Models.API.shop
{
    public class Shop_upd
    {
		[Required]
		[StringLength(50, MinimumLength = 1)]
		public string Name { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string ZIP { get; set; }
		public string City { get; set; }
		
		[Required]
		[StringLength(2, MinimumLength = 2)]
		public string Country { get; set; }
		public string Phone { get; set; }

		[RegExEMAILIfFilled]
		//[EmailAddress]
		public string Email { get; set; }
		public string WebSite { get; set; }
		public string LocalisationURL { get; set; }
		public bool Closed { get; set; }
	}
}
