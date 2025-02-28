using System.ComponentModel.DataAnnotations;

namespace Lab8Bai3.Models // Đảm bảo namespace khớp với project
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StartLocation { get; set; }

        [Required]
        public string EndLocation { get; set; }
    }
}
