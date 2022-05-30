using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RockBand.Entities
{
    public class AlbumSingle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Descrption { get; set; }
        [Required]
         public string Video { get; set; }

        private DateTime _DateRegister = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime DataZDateRegister
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
