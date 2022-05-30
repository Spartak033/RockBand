using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RockBand.Entities
{
    public class Sugestions
    {
        public int Id { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 20)]
        public string Suggestion { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
     



    }
}
