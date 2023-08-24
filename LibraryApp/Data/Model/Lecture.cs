using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Lecture
    {
        [Key]
        public int LectureId { get; set; }


        [Required]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
        
        [Required]
        
        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        public string? File { get; set; }

        [Required]
        public string? AssignClass { get; set; }

       
    }
}
