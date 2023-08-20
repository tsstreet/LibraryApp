using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string? ClassCode { get; set; }

        public AcademicYear? AcademicYear { get; set; }

        [Required]       
        public int AcademicYearId { get; set; }

        public Department? Department { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string? ClassName { get; set; }

        [Required]
        public int NumOfStd { get; set; }

        [Required]
        public decimal Tuition { get; set; }

        public string? Description { get; set; }
        
        public string? ImageUrl { get; set; }

        public bool Active { get; set; } = false;

        public ICollection<ClassStudent> ClassStudents { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

    }
}
