using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.DocumentService
{
    public interface IDocumentService
    {
        Task<List<Document>> GetDocuments();

        Task<Document> GetDocumentById(int id);

        Task<Document> AddDocument(Document document);

        Task<Document> UpdateDocument(int id, Document document);

        Task<Document> DeleteDocument(int id);
        Task<List<Document>> Search(string searchString);
        Task<Document> Approve(int id);

        Task<Document> UnApprove(int id);
    }
}
