using DataEntryApplication.Shared;
using System.Threading.Tasks;

namespace DataEntryApplication.Client.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegisterResult> Register(RegisterModel registerModel);
    }
}
