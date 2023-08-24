using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Bank
    {
        [Key]
        public int BankId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? Form { get; set; }

        [Required]
        public string? Creator { get; set; }

        [Required]
        public string? Duration { get; set; }

        [Required]
        public string? Status { get; set; }
    }
}
