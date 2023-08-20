using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Services.AuthService
{
    public interface IAuthService
    {
        //Task<User> Login(LoginRequest request);

        Task<string> Login(LoginRequest request);
    }
}
