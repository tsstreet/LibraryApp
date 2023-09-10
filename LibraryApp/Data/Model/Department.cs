using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace LibraryApp.Data.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string? Name { get; set; }

        //public ICollection<Class> Classes { get; set; }

        //public ICollection<Subject> Subjects { get; set; }
        //public ICollection<Subject> Subjects { get; set; }
    }
}
