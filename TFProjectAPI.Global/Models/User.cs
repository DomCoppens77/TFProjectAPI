using System;

namespace TFProjectAPI.Global.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public string SecretAnswer { get; set; }
        public bool Active { get; set; }
        public int Status { get; set; }
        public int ConnectionCount { get; set; }
        public DateTime ConnectionLast { get; set; }
        public string Avatar { get; set; }
    }
}