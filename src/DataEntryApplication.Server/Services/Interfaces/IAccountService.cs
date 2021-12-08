using System.Threading.Tasks;
using DataEntryApplication.Shared;

namespace DataEntryApplication.Server.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResult> Login(LoginModel loginModel);
    }
}
