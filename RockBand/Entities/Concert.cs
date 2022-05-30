using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockBand.Entities
{
    public class Concert
    {
               
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 50)]
        public string Description { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Cities { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
       
        public string Venues { get; set; }

        private DateTime _DateRegister = DateTime.Now;
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateRegister
        {
            get
            {
                return _DateRegister;
            }
            set
            {
                _DateRegister = value;
            }
        }
    }
}
