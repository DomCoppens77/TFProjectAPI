namespace TFProjectAPI.Global.Models
{
    public class Shop
    {
        public int    Id              { get; set; }
        public string Name            { get; set; }
		public string Address1        { get; set; }
		public string Address2        { get; set; }
		public string ZIP             { get; set; }
		public string City            { get; set; }
		public string Country         { get; set; }
		public string Phone           { get; set; }
		public string Email           { get; set; }
		public string WebSite         { get; set; }
		public string LocalisationURL { get; set; }
		public  bool  Closed          { get; set; }
	}
}
