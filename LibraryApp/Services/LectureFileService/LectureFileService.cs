using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using LibraryApp.Services.SubjectService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.IO.Compression;
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

        public async Task<string> RenameLectureFile(int id, string reName)
        {
            var lectureFile = await _context.LectureFiles.FindAsync(id);

            var fileExtension = Path.GetExtension(lectureFile.Name);

            var newFileName = $"{reName}{fileExtension}";

            lectureFile.Name = newFileName;

            await _context.SaveChangesAsync();

            return reName;
        }

        public async Task<LectureFile> DeleteLectureFile(int id)
        {

            var lectureFile = await _context.LectureFiles.FindAsync(id);

            if (lectureFile != null)
            {
                 var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", lectureFile.Name);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.LectureFiles.Remove(lectureFile);
                await _context.SaveChangesAsync();
            }

            return lectureFile;
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

        //public async Task<string> CreateLectureFile(LectureFile lectureFile)
        //{
        //    if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\Files\\"))
        //    {
        //        Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\Files\\");
        //    }

        //    if (lectureFile.File != null && lectureFile.File.Length > 0)
        //    {
        //        var uploadFolderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files"); 

        //        if (!Directory.Exists(uploadFolderPath))
        //            Directory.CreateDirectory(uploadFolderPath);

        //        var fileName = Path.GetFileName(lectureFile.File.FileName);


        //        var filePath = Path.Combine(uploadFolderPath, fileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await lectureFile.File.CopyToAsync(fileStream);
        //        }

        //        lectureFile.Name = fileName;
        //        lectureFile.Size = FormatFileSize(lectureFile.File.Length);
        //        lectureFile.FileType = DetectFileType(lectureFile.File);
        //    }

        //    _context.LectureFiles.Add(lectureFile);
        //    await _context.SaveChangesAsync();

        //    return "Ok";
        //}

        public async Task<string> CreateLectureFile(LectureFile lectureFile)
        {
            if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\Files\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\Files\\");
            }

            if (lectureFile.File != null && lectureFile.File.Count > 0)
            {
                var uploadFolderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files");

                if (!Directory.Exists(uploadFolderPath))
                    Directory.CreateDirectory(uploadFolderPath);

                var lectureFiles = new List<LectureFile>();

                foreach (var file in lectureFile.File)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(uploadFolderPath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var newLectureFile = new LectureFile
                    {
                        SubjectId = lectureFile.SubjectId,
                        Name = fileName, 
                        Size = FormatFileSize(file.Length),
                        FileType = DetectFileType(file),
                        SubmitDate = lectureFile.SubmitDate
                    };

                    lectureFiles.Add(newLectureFile);
                }

                _context.LectureFiles.AddRange(lectureFiles);
                await _context.SaveChangesAsync();
            }

            return "OK";
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

        public async Task<FileDownloadResult> DownloadFile(int lectureFileId)
        {
            var lectureFile = await _context.LectureFiles.FindAsync(lectureFileId);

            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", lectureFile.Name);

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return new FileDownloadResult
            {
                FileBytes = fileBytes,
                FileName = lectureFile.Name
            };
        }

    }
}
