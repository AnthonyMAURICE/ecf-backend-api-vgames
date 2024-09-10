using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecf.Vgames.Models
{
    public class GizmondosDTO
    {
        public int Id { get; set; }

        public int PublisherId { get; set; }

        public string? Name { get; set; }

        public int Year { get; set; }

        public string? Dev { get; set; }

        public Publishers? Publisher { get; set; }
    }
}
