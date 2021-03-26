using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserSearch.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Avatar { get; set; }
        public string Url { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Subscriptions { get; set; }
        public bool SiteAdmin { get; set; }
    }
}
