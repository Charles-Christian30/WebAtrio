using System;
using System.ComponentModel.DataAnnotations;
using Web_Atrio.Models.Data;

namespace Web_Atrio.Models.Dto
{
    public class EmploisDto
    {
        public string Company { get; set; }
        public string? Post { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateFin { get; set; } 
        public int? PersonneId { get; set; }
    }
}
