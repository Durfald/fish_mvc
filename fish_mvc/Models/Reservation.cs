using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace fish_mvc.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public required ARENDATOR Arendator { get; set; }
    }
}
