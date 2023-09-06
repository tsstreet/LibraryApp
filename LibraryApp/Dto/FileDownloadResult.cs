using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class FileDownloadResult
    {
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
    }
}
