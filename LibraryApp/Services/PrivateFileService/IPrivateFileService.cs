using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.PrivateFileService
{
    public interface IPrivateFileService
    {
        Task<List<PrivateFile>> GetPrivateFiles();

        Task<PrivateFile> GetPrivateFileById(int id);


        Task<PrivateFile> DeletePrivateFile(int id);
        Task<List<PrivateFile>> Search(string searchString);

        Task<string> UploadPrivateFile(PrivateFile privateFile);

        Task<FileDownloadResult> DownloadFile(int privateFileId);

        Task<string> RenamePrivateFile(int id, string reName);
    }
}
