using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace LibraryApp.Data.Model
{
    public class AcademicYear
    {
        [Key]
        public int AcademicYearId { get; set; }

        [Required]
        public string? AcademicYearCode { get; set; }

        [Required]
        public string? Name { get; set; }

        //public ICollection<Class> Classes { get; set; }
    }
}
