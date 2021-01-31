using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.Entities.Common.Account
{
    public class OTP
    {
        public string Email { get; set; }
        public string Value { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
