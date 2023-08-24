using LibraryApp.Data.Model;
using LibraryApp.Services.DocumentService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {

        private readonly DataContext _context;

        public DocumentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task<Document> GetDocumentById(int id)
        {
            var subject = await _context.Documents.FindAsync(id);

            return subject;
        }

        public async Task<Document> AddDocument(Document document)
        {

            var existSubject = await _context.Documents.FirstOrDefaultAsync(x => x.Name == document.Name);

            if (existSubject != null)
            {
                throw new Exception("Subject already exist");
            }

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateDocument(int id, Document document)
        {
            var subjectUpdate = await _context.Documents.FindAsync(id);

            subjectUpdate.Name = document.Name;

            await _context.SaveChangesAsync();

            return subjectUpdate;
        }

        public async Task<Document> DeleteDocument(int id)
        {

            var document = await _context.Documents.FindAsync(id);

            _context.Documents.Remove(document);

            await _context.SaveChangesAsync();

            return document;
        }

        public async Task<List<Document>> Search(string searchString)
        {
            var subject = from s in _context.Documents
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                subject = subject.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await subject.ToListAsync();
        }

        public async Task<Document> Approve(int id)
        {
            // Phê duyệt tài liệu
            var document = _context.Documents.FirstOrDefault(d => d.DocumentId == id);

            document.IsApproved = true;
            document.Status = "Approved";

            await _context.SaveChangesAsync();

            return document;
        }
    }
}
