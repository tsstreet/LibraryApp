using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Model
{
    public class GradeType
    {
        [Key]
        public int GradeTypeId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Weight { get; set; }
    }
}
