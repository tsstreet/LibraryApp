using LibraryApp.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class SubjectDto
    {
        [Required]
        public string? SubjectCode { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmit { get; set; }

        [Required]
        public string? DocumentStatus { get; set; }

        [Required]
        public string? NumOfWaiting { get; set; }

    }
}
