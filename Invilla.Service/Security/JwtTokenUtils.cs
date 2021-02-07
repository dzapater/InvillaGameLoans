using Invilla.Service.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Invilla.Services.Security
{
    public class JwtTokenUtils
    {
        private static JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        

        public static bool IsValidToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken = null;
            
            var key = Encoding.ASCII.GetBytes("1234567890abcdeghijklmnopqrstuvxz!@#$%&*()_=+++"); 

            var validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890abcdeghijklmnopqrstuvxz!@#$%&*()_=+++")),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateActor = false,
                ValidateTokenReplay = true
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (SecurityTokenException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

            return validatedToken != null;
        }

        public static string GetToken(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty );

            return token;
        }

        public static string GenerateInvillaUserToken(List<Claim> claims)
        {            
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890abcdeghijklmnopqrstuvxz!@#$%&*()_=+++"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            DateTime dateCreation = DateTime.Now;
            DateTime expirationDate = dateCreation.AddHours(1);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: expirationDate,
                    notBefore: dateCreation,
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

    }


