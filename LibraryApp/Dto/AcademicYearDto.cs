using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Dto
{
    public class AcademicYearDto
    {
        [Key]
        public int AcademicYearId { get; set; }

        [Required]
        public string? AcademicYearCode { get; set; }

        [Required]
        public string? Name { get; set; }   
    }

}
