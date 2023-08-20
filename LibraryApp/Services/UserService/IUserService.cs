using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();

        Task<User> GetUserById(int id);

        //Task<User> AddUser(User user);

        Task<User> AddUser(UserDto user);

        Task<User> UpdateUser(int id, User user);

        Task<User> DeleteUser(int id);

        Task<List<User>> Search(string searchString);

        Task<string> ForgotPassword(string email);
        Task<string> ResetPassword(ResetPassword request);
    }
}
