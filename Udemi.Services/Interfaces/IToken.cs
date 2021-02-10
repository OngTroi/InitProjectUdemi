using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Entities;
using Udemi.Entities.Common.Account;

namespace Udemi.Services.Interfaces
{
    public interface IToken
    {
        /// <summary>
        /// Xác thực token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool ValidateToken(string token);

        /// <summary>
        /// Lưu token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        DataTable SaveToken(Token token);

        /// <summary>
        /// Lấy thông tin token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Token GetToken(string token);

        DataTable GetTokenByUser(string email);
    }
}
