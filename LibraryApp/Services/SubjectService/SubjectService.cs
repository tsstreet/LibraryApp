using LibraryApp.Data.Model;
using LibraryApp.Services.SubjectService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.IO.Compression;
using System.Text.Json.Serialization;
using System.Text.Json;
using NuGet.Packaging;
using System.Net.Http.Headers;


namespace LibraryApp.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {

        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SubjectService(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            return subject;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {

            var existSubject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == subject.Name);

            if (existSubject != null)
            {
                throw new Exception("Subject already exist");
            }

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            var subjectUpdate = await _context.Subjects.FindAsync(id);

            subjectUpdate.SubjectCode = subject.SubjectCode;
            subjectUpdate.Name = subject.Name;
            subjectUpdate.Description = subject.Description;

            await _context.SaveChangesAsync();

            return subjectUpdate;
        }

        public async Task<Subject> DeleteSubject(int id)
        {

            var subject = await _context.Subjects.FindAsync(id);

            _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<List<Subject>> Search(string searchString)
        {
            var subject = from s in _context.Subjects
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                subject = subject.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.SubjectCode.ToLower().Contains(searchString.ToLower()));
            }

            return await subject.ToListAsync();
        }

        public async Task<ICollection<LectureFile>> GetFileBySubject(int id)
        {
            var file = await _context.Subjects.Where(x => x.SubjectId == id).Select(c => c.LectureFiles).FirstOrDefaultAsync();

            return file.ToList();
        }

        public async Task<ICollection<Topic>> GetTopicBySubject(int id)
        {
            var topic = await _context.Subjects.Where(x => x.SubjectId == id).Select(c => c.Topics).FirstOrDefaultAsync();

            return topic.ToList();
        }


        public async Task<FileStreamResult> DownloadFiles(int subjectId)
        {
            var lectureFiles = await _context.LectureFiles
                .Where(x => x.SubjectId == subjectId)
                .ToListAsync();

            var memoryStream = new MemoryStream();

            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var lectureFile in lectureFiles)
                {
                    var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", lectureFile.Name);

                    var entryName = lectureFile.Name;
                    var entry = zipArchive.CreateEntry(entryName, CompressionLevel.Optimal);

                    using (var entryStream = entry.Open())
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            await fileStream.CopyToAsync(entryStream);
                        }
                    }
                }
            }

            memoryStream.Position = 0;

            return new FileStreamResult(memoryStream, new MediaTypeHeaderValue("application/octet-stream").ToString())
            {
                FileDownloadName = $"subject_{subjectId}_files.zip"
            };
        }
    }
}

