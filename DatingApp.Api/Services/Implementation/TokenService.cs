using DatingApp.Api.Services.Interface;
using Domain.Entities.User;

namespace DatingApp.Api.Services.Implementation
{
    public class TokenService : ITokenService
    {
        #region ctor
        public TokenService()
        {

        }

        #endregion

        #region TokenService

        public string CreateToken(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
