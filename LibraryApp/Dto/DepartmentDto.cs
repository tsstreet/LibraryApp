using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Dto
{
    public class DepartmentDto
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
