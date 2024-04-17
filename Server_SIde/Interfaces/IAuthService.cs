using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IAuthService
    {
        bool IsAuthenticated(User user);
    }
}
