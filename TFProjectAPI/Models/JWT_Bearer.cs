using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFProjectAPI.Models
{
    public class JWT_Bearer
    {
        public int id { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public string BearerJWT { get; set; }

    }
}
