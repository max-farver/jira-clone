using System.Threading.Tasks;
using Application.Auth.Authentication.DTOs;
using Domain.Users;

namespace Application.Projects
{
    public interface IAuthService
    {
        Task<AppUser> Login(string email, string password);
    }
}