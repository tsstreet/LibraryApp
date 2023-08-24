using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LibraryApp.Services.UserService
{
    public class UserService: IUserService
    {

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        //public async Task<User> AddUser(User user)
        //{
        //    var existUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

        //    if (existUser != null)
        //    {
        //        throw new Exception("Email already exist");
        //    }

        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return user;
        //}

        public async Task<User> AddUser(UserDto userDto)
        {
            var existUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == userDto.Email);

            if (existUser != null)
            {
                throw new InvalidOperationException("Email already exists");
            }

            // Generate password hash and salt
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Create a new User object
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = userDto.Role,
                ImageUrl = userDto.ImageUrl
            };            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out Byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<User> UpdateUser(int id, User user)
        {
           
            var userUpdate = await _context.Users.FindAsync(id);
            userUpdate.Name = user.Name;
            userUpdate.Email = user.Email;
            userUpdate.Role = user.Role;
            userUpdate.ImageUrl = user.ImageUrl;

            await _context.SaveChangesAsync();

            return userUpdate;
        }

        public async Task<User> DeleteUser(int id)
        {

            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }  
        public async Task<List<User>> Search(string searchString)
        {
            var user = from s in _context.Users
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.Name.ToLower().Contains(searchString.ToLower())); 
            }

            return await user.ToListAsync();
        }

        public async Task<string> ForgotPassword(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return user.PasswordResetToken;
        }

        public async Task<string> ResetPassword(ResetPassword request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == request.Token);

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;

            await _context.SaveChangesAsync();

            return "Password Reset";

        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
