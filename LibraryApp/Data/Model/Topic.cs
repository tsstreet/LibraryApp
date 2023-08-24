using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Topic
    {
        [Key]
        public int TopicId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
