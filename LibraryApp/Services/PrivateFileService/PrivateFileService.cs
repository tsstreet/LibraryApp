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

namespace LibraryApp.Services.PrivateFileService
{
    public class PrivateFileService : IPrivateFileService
    {
        private static IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _context;

        private readonly IConfiguration _configuration;


        public PrivateFileService(DataContext context, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

            _configuration = configuration;
        }

        public async Task<List<PrivateFile>> GetPrivateFiles()
        {
            return await _context.PrivateFiles.ToListAsync();
        }

        public async Task<PrivateFile> GetPrivateFileById(int id)
        {
            var file = await _context.PrivateFiles.FindAsync(id);

            return file;
        }

        public async Task<string> RenamePrivateFile(int id, string reName)
        {
            var lectureFile = await _context.LectureFiles.FindAsync(id);

            var fileExtension = Path.GetExtension(lectureFile.Name);

            var newFileName = $"{reName}{fileExtension}";

            lectureFile.Name = newFileName;

            await _context.SaveChangesAsync();

            return reName;
        }

        public async Task<PrivateFile> DeletePrivateFile(int id)
        {

            var privateFile = await _context.PrivateFiles.FindAsync(id);

            if (privateFile != null)
            {
                 var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "PrivateFiles", privateFile.Name);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.PrivateFiles.Remove(privateFile);
                await _context.SaveChangesAsync();
            }

            return privateFile;
        }

        public async Task<List<PrivateFile>> Search(string searchString)
        {
            var privateFile = from s in _context.PrivateFiles
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                privateFile = privateFile.Where(s => s.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await privateFile.ToListAsync();
        }


        public async Task<string> UploadPrivateFile(PrivateFile privateFile)
        {
            if (!Directory.Exists(_webHostEnvironment.ContentRootPath + "\\PrivateFiles\\"))
            {
                Directory.CreateDirectory(_webHostEnvironment.ContentRootPath + "\\PrivateFiles\\");
            }

            if (privateFile.File != null && privateFile.File.Count > 0)
            {
                var uploadFolderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "PrivateFiles");

                if (!Directory.Exists(uploadFolderPath))
                    Directory.CreateDirectory(uploadFolderPath);

                var privateFiles = new List<PrivateFile>();

                foreach (var file in privateFile.File)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(uploadFolderPath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    var newPrivateFile = new PrivateFile
                    {
                        Name = fileName, 
                        Size = FormatFileSize(file.Length),
                        FileType = DetectFileType(file),
                        LastEdited = privateFile.LastEdited,
                    };

                    privateFiles.Add(newPrivateFile);
                }

                _context.PrivateFiles.AddRange(privateFiles);
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


        public async Task<FileDownloadResult> DownloadFile(int privateFileId)
        {
            var privateFile = await _context.LectureFiles.FindAsync(privateFileId);

            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "PrivateFiles", privateFile.Name);

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return new FileDownloadResult
            {
                FileBytes = fileBytes,
                FileName = privateFile.Name
            };
        }

    }
}
