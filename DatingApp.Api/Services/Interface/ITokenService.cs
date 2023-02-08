using Domain.Entities.User;

namespace DatingApp.Api.Services.Interface
{
    public interface ITokenService
    {
        #region Token
        string CreateToken(User user);
        #endregion
    }
}
