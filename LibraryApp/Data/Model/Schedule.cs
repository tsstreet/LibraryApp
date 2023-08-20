using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        public int ClassId { get; set; }
        public Class Class { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [Required]
        public string Room { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TimeStart { get; set; }

        [Required]
        //[DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime TimeEnd { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string Day { get; set; }

    }
}
