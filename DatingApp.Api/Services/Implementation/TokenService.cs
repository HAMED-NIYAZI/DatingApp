using DatingApp.Api.Services.Interface;
using Domain.Entities.User;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingApp.Api.Services.Implementation
{
    public class TokenService : ITokenService
    {

        #region ctor
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {
            //توکن کی استرینگ را از اپ ستینگ میگیریم  و با سمتریک سکیوریتی کی ازش  کی باینی میسازیم
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        #endregion

        #region TokenService

        public string CreateToken(User user)
        {
            var claim = new List<Claim> //لیستی از کلایم ها ست کردیم
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.NameId,user.UserName)
            };


            //با کی ای که در کانستراکتور ساخته ایم و الگوریتم یک کردنشیال ساختیم
            var creds=new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            //یک سکیوریتی توکن دیسکریپتور ساختیم
            var tokenDescriptor = new SecurityTokenDescriptor()
            { 
            Subject = new ClaimsIdentity(claim), //کلایم را به موضوع زدیم
            Expires = DateTime.Now.AddDays(7),//تعداد روز های اعتبار توکن
            SigningCredentials = creds //کردنشیال بالا را در ساین این کردنشیال زدیم
            };
            var tokenHandler = new JwtSecurityTokenHandler();//یک توکن هندلر ساختیم
            var token=tokenHandler.CreateToken(tokenDescriptor);// توکن را می سازیم

            return tokenHandler.WriteToken(token);//با استفاده ار توکن هندلر توکن جدید را نوشته و برمیگردانیم

        }

        #endregion
    }
}
