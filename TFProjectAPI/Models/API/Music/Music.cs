using System;
using System.ComponentModel.DataAnnotations;

namespace TFProjectAPI.Models.API.Music
{
    public class Music
    {
		/* DOMOBJ*/
		public float Price { get; set; }
		[Required]
		[StringLength(3, MinimumLength = 3)]
		public string Curr { get; set; }
		
		[Required]
		public int ShopId { get; set; }
		public DateTime Date { get; set; }

		public bool Signed { get; set; }

		[StringLength(100)]
		public string SignedBy { get; set; }
		
		[StringLength(15)]
		public string EAN { get; set; }
		
		[StringLength(15)]
		public string EAN_EXT { get; set; }
		
		[StringLength(255)]
		public string Comment1 { get; set; }
		
		[StringLength(255)]
		public string Comment2 { get; set; }
		public bool Onwed { get; set; }

		/* MUSIC */
		[Required]
		[StringLength(50)]
		public string Band { get; set; }
		
		[Required]
		[StringLength(50)]
		public string Title { get; set; }
		public int YEAR { get; set; }
		
		[StringLength(100)]
		public string TRACKS { get; set; }
		public int NbCDs { get; set; }
		public int NbDvds { get; set; }
		public int NbLps { get; set; }
		
		[Required]
		public int MTypeId { get; set; }
		
		[Required]
		public int FormatId { get; set; }
		
		[StringLength(100)]
		public string SerialNbr { get; set; }

		[StringLength(2, MinimumLength = 2)]
		public string Ctry { get; set; }

	}
}
