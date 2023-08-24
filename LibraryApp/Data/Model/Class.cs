using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? ClassCode { get; set; }

        public AcademicYear? AcademicYear { get; set; }

        [Required]
        public int AcademicYearId { get; set; }

    }
}
