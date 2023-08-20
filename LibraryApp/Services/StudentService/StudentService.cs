using LibraryApp.Data.Model;
using LibraryApp.Services.StudentService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using NuGet.DependencyResolver;
using System.Security.Cryptography;

namespace LibraryApp.Services.StudentService
{
    public class StudentService: IStudentService
    {

        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return student;
        }

        public async Task<Student> AddStudent(Student student, int classId)
        {
            var existStudent = await _context.Users.FirstOrDefaultAsync(x => x.Email == student.Email );
            var @class = await _context.Classes.FindAsync(classId);

            if (existStudent != null)
            {
                throw new Exception("Email already exist");
            }

            if (@class != null)
            {
                var classStudent = new ClassStudent
                {
                    Student = student,
                    Class = @class
                };

                _context.ClassStudents.Add(classStudent);
            }

            // Generate password hash and salt
            CreatePasswordHash(student.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Name = student.FullName,
                Email = student.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "Student",
                ImageUrl = student.ImageUrl
            };
            _context.Users.Add(user);

            student.SetPassword(passwordHash, passwordSalt);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }  

        private void CreatePasswordHash(string password, out byte[] passwordHash, out Byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }    

        public async Task<Student> RegisterStudent(Student student)
        {
            var existStudent = await _context.Users.FirstOrDefaultAsync(x => x.Email == student.Email);
      
            if (existStudent != null)
            {
                throw new Exception("Email already exist");
            }

            // Generate password hash and salt
            CreatePasswordHash(student.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Name = student.FullName,
                Email = student.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "Student",
                ImageUrl = student.ImageUrl
            };
            _context.Users.Add(user);

            student.SetPassword(passwordHash, passwordSalt);

            _context.Students.Add(student);

            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var studentUpdate = await _context.Students.FindAsync(id);
            studentUpdate.LastName = student.LastName;
            studentUpdate.FullName = student.FullName;
            studentUpdate.Email = student.Email;
            studentUpdate.Address = student.Address;
            studentUpdate.Phone = student.Phone;
            studentUpdate.Dob = student.Dob;
            studentUpdate.Gender = student.Gender;
            studentUpdate.ParentName = student.ParentName;
            studentUpdate.Password = student.Password;
            studentUpdate.ImageUrl = studentUpdate.ImageUrl;

            if (!string.IsNullOrEmpty(student.Password) && !string.IsNullOrEmpty(student.FullName) && !string.IsNullOrEmpty(student.Email))
            {
                // Generate password hash and salt
                CreatePasswordHash(student.Password, out byte[] passwordHash, out byte[] passwordSalt);

                // Update the student's password
                studentUpdate.SetPassword(passwordHash, passwordSalt);

                // Update the associated user's password hash
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == studentUpdate.Email);
                if (user != null)
                {
                    user.Name = studentUpdate.FullName;
                    user.ImageUrl = studentUpdate.ImageUrl;
                    user.Email = studentUpdate.Email;
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }
            }

            await _context.SaveChangesAsync();
            return studentUpdate;
        }

        public async Task<Student> DeleteStudent(int id)
        {

            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<ICollection<Class>> GetClassesByStudent(int studentId)
        {
            var classes = await _context.Students
                .Where(s => s.StdId == studentId)
                .SelectMany(s => s.ClassStudents)
                .Select(cs => cs.Class)
                .ToListAsync();

            return classes;
        }

        public async Task<bool> RegisterStudentForClass(int studentId, int classId)
        {
            var student = await _context.Students.FindAsync(studentId);
            var @class = await _context.Classes.FindAsync(classId);

            var check = await _context.ClassStudents.FirstOrDefaultAsync(x => x.StudentId == studentId && x.ClassId == classId);

            if (student == null || @class == null)
            {
                return false;
            }
            else if (check != null)
            {
                return false;
            }
            var classStudent = new ClassStudent
            {
                StudentId = studentId,
                ClassId = classId
            };

            _context.ClassStudents.Add(classStudent);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UnregisterStudentFromClass(int studentId, int classId)
        {
            var classStudent = await _context.ClassStudents
                .FirstOrDefaultAsync(cs => cs.StudentId == studentId && cs.ClassId == classId);

            if (classStudent != null)
            {
                _context.ClassStudents.Remove(classStudent);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<ICollection<Schedule>> GetStudentSchedule(int id)
        {
            var schedule = await _context.ClassStudents
                                .Where(cs => cs.StudentId == id)
                                .Select(cs => cs.Class)
                                .SelectMany(c => c.Schedules)
                                .ToListAsync();
            return schedule;
        }

        public async Task<List<Student>> Search(string searchString)
        {
            var students = from s in _context.Students
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FullName.ToLower().Contains(searchString.ToLower())
                                           || s.LastName.ToLower().Contains(searchString.ToLower())
                                           || s.Email.ToLower().Contains(searchString.ToLower())
                                           || s.StdCode.ToLower().Contains(searchString.ToLower())
                                           || s.Phone.Contains(searchString));
            }

            return await students.ToListAsync();
        }
    }
}
