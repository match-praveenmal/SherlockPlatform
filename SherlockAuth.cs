using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockPlatform
{
    public record SherlockAuth
    {
        public string Token {get;set;}
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

    }
}
