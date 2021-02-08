using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemi.Services.Interfaces;
using Udemi.Services;
using Udemi.Entities.Common.Account;
using Udemi.Entities;
using System.Data.SqlClient;

namespace Udemi.Services.Repository
{
    public class TokenRepository : BaseServices<DataSet>, IToken
    {
        public TokenRepository(IDatabaseService databaseService) : base(databaseService)
        {
        }

        public Token GetToken(string token)
        {
            string sql = @"Select A.TokenID, A.Email, A.ExpiredTime, A.User_Type
                           From Token_Manager A
                           Where A.UserEmail = @Token";
            var dt = ExecuteDataTable(sql, CommandType.Text, new SqlParameter("@Token", token));
            if (dt.Rows.Count==0)
                return new Token();
            return new Token
            {
                Email = dt.Rows[0]["TokenID"].ToString(),
                TokenId = dt.Rows[0]["Email"].ToString(),
                expiredin = (DateTime)dt.Rows[0]["ExpiredTime"],
                User_Type = dt.Rows[0]["User_Type"].ToString()
            };
        }

        public DataTable GetTokenByUser(string email)
        {
            string sql = @"Select A.TokenID, A.Email, A.ExpiredTime
                           From Token_Manager A
                           Where A.Email = @Email";
            var dt = ExecuteDataTable(sql, CommandType.Text, 
                new SqlParameter("@Email", email));
            return dt;
        }

        public bool SaveToken(Token token)
        {
            string sql = @"Udemi_Token_SaveToken";
            var dt = ExecuteDataTable(sql, CommandType.StoredProcedure, 
                new SqlParameter("@Email", token.Email), 
                new SqlParameter("@Token", token.TokenId),
                new SqlParameter("@ExpiredDate", token.expiredin)
                );
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateToken(string token)
        {
            string sql = @"Select A.TokenID, A.Email, A.ExpiredTime
                           From Token_Manager A
                           Where A.UserEmail = @Token";
            var dt = ExecuteDataTable(sql, CommandType.Text, new SqlParameter("@Token", token));
            if ((DateTime)dt.Rows[0]["ExpiredTime"] < DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
