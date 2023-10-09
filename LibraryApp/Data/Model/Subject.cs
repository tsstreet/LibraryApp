using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string? SubjectCode { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateSubmit { get; set; }

        [Required]
        public string? DocumentStatus { get; set; }

        [Required]
        public string? NumOfWaiting { get; set; }

        public ICollection<Topic> Topics { get; set; }

    }
}
