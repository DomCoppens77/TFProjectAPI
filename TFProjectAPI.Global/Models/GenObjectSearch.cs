using System;
using System.Collections.Generic;
using System.Text;

namespace TFProjectAPI.Global.Models
{
    public class GenObjectSearch
    {
        public int Id { get; set; }
        public float PRICE_EUR { get; set; }
        public int TypeId { get; set; }
        public string GenTypeName { get; set; }
        public string EAN { get; set; }
        public string EAN_EXT { get; set; }
        public string EAN_FULL { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string OBJTEXT { get; set; }
    }
}
