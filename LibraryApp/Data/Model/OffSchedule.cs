using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Data.Model
{
    public class OffSchedule
    {
        [Key]
        public int OffScheduleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
