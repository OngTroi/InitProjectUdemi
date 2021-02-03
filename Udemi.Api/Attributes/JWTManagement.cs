using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;

namespace Udemi.Api.Attributes
{
    public class JWTManagement
    {
        // Define const Key this should be private secret key  stored in some safe place
        private static readonly string key = @"401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b372742
           9090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";


        public static string GenerateToken(string username, DateTime expiredTime )
        {
            // Create Security key  using private key above:
            // not that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // so you have to make sure that your private key has a proper length
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            //  Finally create a Token
            var header = new JwtHeader(credentials);

            //Some PayLoad that contain information about the  customer
            var payload = new JwtPayload
           {
               { username, expiredTime.ToString() },
               { "scope", "http://dummy.com/"},
           };

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            var tokenString = handler.WriteToken(secToken);

            return tokenString;
        }
        

    }
}