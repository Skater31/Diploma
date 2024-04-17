using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _applicationContext;

        public AuthService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public bool IsAuthenticated(User user)
        {
            return _applicationContext.Users.Any(u => u.Login == user.Login && u.Password == user.Password);
        }
    }
}
