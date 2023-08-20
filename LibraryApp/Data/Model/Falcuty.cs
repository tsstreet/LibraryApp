using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Data.Model
{
    public class Falcuty
    {
        [Key]
        public int FalcutyId { get; set; }

        [Required]
        public string? Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
