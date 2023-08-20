using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Model
{
    public class SubjectGrade
    {
        [Key]
        public int Id { get; set; }
     
        [Required]
        public int AcademicYearId { get; set; }
        public AcademicYear? AcademicYear { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public int GradeTypeId { get; set; }
        public GradeType GradeType { get; set; }

        public int NumOfGradeColumn { get; set; }

        public int NumOfRequireGradeColumn { get; set; }

    }
}
