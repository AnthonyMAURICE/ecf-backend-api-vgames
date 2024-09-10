﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ecf.Vgames.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [JsonIgnore]
        public List<Gizmondo>? GizmondoList { get; set; }
    }
}
