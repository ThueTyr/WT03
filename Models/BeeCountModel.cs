using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WT03.Models
{
    public class BeeCountModel
    {
        public long BeeCountModelId { get; set; }

        public long IdOfAuthor { get; set; }
        [Required]
        [MaxLength(18)]
        public string BeeHiveName { get; set; }

        [Required]
        public DateTime CountTime { get; set; }
        [Required]
        public int NumberOfMidgets { get; set; }
        [Required]
        public int ObservationDays { get; set; }
        
        public string Comments { get; set; }

        public UserData Author { get; set; }
    }
}
