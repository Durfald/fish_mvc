using System.ComponentModel.DataAnnotations;

namespace fish_mvc.Models
{
    public class Marker
    {

        [Key]
        public int Id { get; set; }

        //[Required]
        //public required string Info { get; set; }

        [Required]
        public string Size { get; set; } = string.Empty;

        [Required]
        public required string Type { get; set; }

        public required float X { get; set; }

        public required float Y { get; set; }

        public required int TotalPlaces { get; set; }

        public int FreePlaces { get; set; }
    }
}