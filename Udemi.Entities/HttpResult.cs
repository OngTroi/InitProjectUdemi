using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.Entities
{
    public class HttpResult
    {
        public Enum.Enums.MessageCode MessageCode { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }

        public HttpResult()
        { 
        }

        public HttpResult(Enum.Enums.MessageCode msgcode, string message)
        {
            MessageCode = msgcode;
            Message = message;
        }
    }
}
