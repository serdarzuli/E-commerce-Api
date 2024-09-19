using ETicaretApi.Application.Abstractions.Tokens;
using ETicaretApi.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Infrastructure.Services.Tokens
{
    //concerete classtir.
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public Token CreateAccessToken(int minute)
        {
            Token token = new Token();

            //SecurityKeynin simetrigini aliyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            //olusturulacak token ayarlarini veriyoruz.
            JwtSecurityToken securityToken = new(

                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            //Token olusturucu sinifindan tokenu olusturalim
            JwtSecurityTokenHandler securityTokenHandler = new();  //instace(object) olusturduk ve weite token methoduna erisebildik
            token.AccessToken = securityTokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();

            return token;


        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            //using RandomNumberGenerator random = RandomNumberGenerator.Create(){ } eski kullanimi
            using RandomNumberGenerator random = RandomNumberGenerator.Create(); //using nedir? using hangi {} scoupein icerisindeyse, o scouptan cikana kadar random nesenesini braindiracaktir ciktiktan sonra onu dispose edecektir.
            //RandomNumberGenerator implementine gittigmiz zaman Idisposible oldugunu gorebillriiz
            random.GetBytes(number);
            return Convert.ToBase64String(number); // okunabilir degere donduruyoruz

        }
    }
}
