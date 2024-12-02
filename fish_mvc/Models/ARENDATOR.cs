using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace fish_mvc.Models
{
    public class ARENDATOR
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Имя:")]
        public string Name { get; set; }

        [Required]
        [Phone]
        [DisplayName("Телефон:")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Дата:")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Место:")]
        public string Place { get; set; }
    }
}
