using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecf.Vgames.Models
{
    public class Gizmondos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PublisherId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string? Dev { get; set; }

        [ForeignKey("PublisherId")]
        [JsonIgnore]
        public Publishers? Publisher { get; set; }
    }
}
