namespace TFProjectAPI.Global.Models
{
    public class Music : DomObj
    {
		public int    ID        { get; set; }
		public string Band      { get; set; }
		public string Title     { get; set; }
		public int    YEAR      { get; set; }
		public string TRACKS    { get; set; }
		public int    NbCDs     { get; set; }
		public int    NbDvds    { get; set; }
		public int    NbLps     { get; set; }
		public int    MTypeId   { get; set; }
		public string TypeStr   { get; set; } /* NON DB Field Just 4 Display */
		public int    FormatId  { get; set; } 
		public string FormatStr { get; set; } /* NON DB Field Just 4 Display */
		public string SerialNbr { get; set; }
        public string Ctry { get; set; }
        public Music() {}
	}
}
