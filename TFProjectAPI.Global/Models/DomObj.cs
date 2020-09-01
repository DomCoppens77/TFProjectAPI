using System;

namespace TFProjectAPI.Global.Models
{
    public abstract class DomObj
    {
		public int      Id       { get; set; }
		public float    Price    { get; set; }
		public string   Curr     { get; set; }
		public int      ShopId   { get; set; }
		public string   ShopName { get; set; }
		public DateTime? Date     { get; set; }
		public int      TypeId   { get; set; }
		public bool     Signed   { get; set; }
		public string   SignedBy { get; set; }
		public string   EAN      { get; set; }
		public string   EAN_EXT  { get; set; }
		public string   Comment1 { get; set; }
		public string   Comment2 { get; set; }
		public bool     Onwed    { get; set; }

	}
}
