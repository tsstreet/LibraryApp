using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Dto
{
    public class SubjectGradeDto
    {
        [Key]
        public int Id { get; set; }
     
        [Required]
        public int AcademicYearId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int GradeTypeId { get; set; }

        public int NumOfGradeColumn { get; set; }

        public int NumOfRequireGradeColumn { get; set; }

    }
}
