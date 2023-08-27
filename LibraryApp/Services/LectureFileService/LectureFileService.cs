using LibraryApp.Data.Model;
using LibraryApp.Services.SubjectService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Services.LectureFileService
{
    public class LectureFileService : ILectureFileService
    {
        private static IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _context;

        private readonly IConfiguration _configuration;


        public LectureFileService(DataContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

            _configuration = configuration;
        }

        public async Task<List<LectureFile>> GetLectureFiles()
        {
            return await _context.LectureFiles.ToListAsync();
        }

        public async Task<LectureFile> GetLectureFileById(int id)
        {
            var subject = await _context.LectureFiles.FindAsync(id);

            return subject;
        }

        //public async Task<Subject> AddSubject(Subject subject)
        //{

        //    var existSubject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == subject.Name);

        //    if (existSubject != null)
        //    {
        //        throw new Exception("Subject already exist");
        //    }

        //    _context.Subjects.Add(subject);
        //    await _context.SaveChangesAsync();
        //    return subject;
        //}

        //public async Task<Subject> UpdateSubject(int id, Subject subject)
        //{
        //    var subjectUpdate = await _context.Subjects.FindAsync(id);

        //    subjectUpdate.SubjectCode = subject.SubjectCode;
        //    subjectUpdate.Name = subject.Name;
        //    subjectUpdate.Description = subject.Description;

        //    await _context.SaveChangesAsync();

        //    return subjectUpdate;
        //}

        public async Task<LectureFile> DeleteLectureFile(int id)
        {

            var subject = await _context.LectureFiles.FindAsync(id);

            _context.LectureFiles.Remove(subject);

            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<List<LectureFile>> Search(string searchString)
        {
            var subject = from s in _context.LectureFiles
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                subject = subject.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await subject.ToListAsync();
        }

        //public async Task<string> Upload([FromForm] Lecture file)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
        //        {
        //            Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
        //        }

        //        using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + file.Name))
        //        {
        //            file.File.CopyTo(fileStream);
        //            fileStream.Flush();
        //            return "\\Images\\" + file.File.Name;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}

        //private int maxAllowedFiles = int.MaxValue;
        //private long maxFileSize = long.MaxValue;
        //private List<string> fileName = new();
        //public async Task<string> UploadFile(InputFileChangeEventArgs e)
        //{
        //    using var content = new MultipartFormDataContent();

        //    foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
        //    {
        //        var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
        //        fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

        //        fileName.Add(file.Name);

        //        content.Add(
        //            content: fileContent,
        //            name: "\"files\"",
        //            fileName: file.Name);
        //    }

        //    return "content";
        //}

        public async Task<List<LectureFile>> CreateLectureFile(LectureFile lectureFile)
        {

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath + "\\Files\\"); // Change "uploads" to the desired upload directory

                // Create the uploads directory if it doesn't exist
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

            if (lectureFile.File != null && lectureFile.File.Length > 0)
            {
                string filePath = Path.Combine(uploadPath, lectureFile.File.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await lectureFile.File.CopyToAsync(fileStream);
                }

                // Update lectureFile properties with file details
                lectureFile.Name = lectureFile.File.FileName;
                lectureFile.Size = FormatFileSize(lectureFile.File.Length);
                lectureFile.FileType = DetectFileType(lectureFile.File);
            }

            _context.LectureFiles.Add(lectureFile);
            await _context.SaveChangesAsync();

            return new List<LectureFile> { lectureFile };
        }

    

        private string FormatFileSize(long bytes)
        {
            const int scale = 1024;
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            var order = 0;
            double size = bytes;

            while (size >= scale && order < sizes.Length - 1)
            {
                size /= scale;
                order++;
            }

            return $"{Math.Round(size, 2)} {sizes[order]}";
        }

        private string DetectFileType(IFormFile file)
        {
            var fileExtensions = new Dictionary<string, string>
            {
                { ".doc", "Word" },
                { ".docx", "Word" },
                { ".ppt", "PowerPoint" },
                { ".pptx", "PowerPoint" },
                { ".xls", "Excel" },
                { ".xlsx", "Excel" }
            };

            var extension = Path.GetExtension(file.FileName);
            var fileType = fileExtensions.FirstOrDefault(x => x.Key.Equals(extension, StringComparison.OrdinalIgnoreCase)).Value;

            return fileType ?? "Unknown";
        }

        //private string GetCurrentUser()
        //{
        //    var httpContext = _httpContextAccessor.HttpContext;
        //    if (httpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
        //    {
        //        var token = authorizationHeader.ToString().Replace("Bearer ", "");
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)),
        //            ValidateIssuer = false,
        //            ValidateAudience = false
        //        };

        //        try
        //        {
        //            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
        //            var usernameClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);
        //            var currentUser = usernameClaim?.Value;

        //            return currentUser;
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle token validation errors here
        //            // For example, you could log the error or return a default user
        //        }
        //    }

        //    // Return a default user or handle the case when the token is not provided
        //    return "Anonymous";
        //}
    }
}
