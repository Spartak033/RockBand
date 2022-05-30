using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockBand.Entities
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        [StringLength (200,MinimumLength =50)]
        public string NewsName { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 50)]
        string NewsPhotos { get; set; }
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
