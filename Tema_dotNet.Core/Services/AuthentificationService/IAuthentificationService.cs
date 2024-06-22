using Tema_dotNet.Database.Entities;

namespace Tema_dotNet.Core.Services
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
    }
}