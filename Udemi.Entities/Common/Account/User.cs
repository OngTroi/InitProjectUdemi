using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemi.Entities.Common.Account
{
    public class User
    {
		public string Email { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public int Gender { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Phone { get; set; }
		public string UserType { get; set; }
	}
}
