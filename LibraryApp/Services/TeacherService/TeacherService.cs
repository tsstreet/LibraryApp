using LibraryApp.Data.Model;
using LibraryApp.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LibraryApp.Services.TeacherService
{
    public class TeacherService: ITeacherService
    {

        private readonly DataContext _context;

        public TeacherService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            return teacher;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            var existTeacher = await _context.Users.FirstOrDefaultAsync(x => x.Email == teacher.Email);

            if (existTeacher != null)
            {
                throw new Exception("Email already exist");
            }

            // Generate password hash and salt
            CreatePasswordHash(teacher.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Name = teacher.FullName,
                Email = teacher.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "Teacher",
                ImageUrl = teacher.ImageUrl
            };
            _context.Users.Add(user);

            teacher.SetPassword(passwordHash, passwordSalt);

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out Byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<Teacher> UpdateTeacher(int id, Teacher teacher)
        {
           
            var teacherUpdate = await _context.Teachers.FindAsync(id);
            teacherUpdate.LastName = teacher.LastName;
            teacherUpdate.FullName = teacher.FullName;
            teacherUpdate.Email = teacher.Email;
            teacherUpdate.Address = teacher.Address;
            teacherUpdate.Phone = teacher.Phone;
            teacherUpdate.Dob = teacher.Dob;
            teacherUpdate.Gender = teacher.Gender;
           
            teacherUpdate.ImageUrl = teacher.ImageUrl;


            if (!string.IsNullOrEmpty(teacher.Password) && !string.IsNullOrEmpty(teacher.FullName) && !string.IsNullOrEmpty(teacher.Email))
            {
                // Generate password hash and salt
                CreatePasswordHash(teacher.Password, out byte[] passwordHash, out byte[] passwordSalt);
                teacherUpdate.SetPassword(passwordHash, passwordSalt);


                // Update the associated user's properties
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == teacherUpdate.Email);
                if (user != null)
                {
                    user.Name = teacherUpdate.FullName;
                    user.ImageUrl = teacherUpdate.ImageUrl;
                    user.Email = teacherUpdate.Email;
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }
            }

            await _context.SaveChangesAsync();

            return teacherUpdate;
        }

        public async Task<Teacher> DeleteTeacher(int id)
        {

            var teacher = await _context.Teachers.FindAsync(id);

            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();

            return teacher;
        }

        public async Task<ICollection<Schedule>> GetScheduleByTeacher(int id)
        {
            var schedule = await _context.Teachers.Where(x => x.TeacherId == id).Select(c => c.Schedules).FirstOrDefaultAsync();

            return schedule.ToList();
        }

        

        public async Task<List<Teacher>> Search(string searchString)
        {
            var teacher = from s in _context.Teachers
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                teacher = teacher.Where(s => s.FullName.ToLower().Contains(searchString.ToLower())
                                           || s.LastName.ToLower().Contains(searchString.ToLower())
                                           || s.Email.ToLower().Contains(searchString.ToLower())
                                           || s.TeacherCode.ToLower().Contains(searchString.ToLower())
                                           || s.Phone.Contains(searchString));
            }

            return await teacher.ToListAsync();
        }
    }
}
