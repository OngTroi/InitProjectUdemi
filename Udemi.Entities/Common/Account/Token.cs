using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.Entities.Common.Account
{
    public class Token
    {
        public string TokenId { get; set; }
        public string RefreshToken { get; set; }
        public string Email { get; set; }
        public DateTime expiredin { get; set; }
    }
}
