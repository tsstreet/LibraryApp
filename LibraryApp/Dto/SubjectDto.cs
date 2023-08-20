using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Dto
{
    public class SubjectDto
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        public string? SubjectCode { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int FalcutyId { get; set; }

    }
}
