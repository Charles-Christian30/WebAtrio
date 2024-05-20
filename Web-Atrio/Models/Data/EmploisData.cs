using System.ComponentModel.DataAnnotations;

namespace Web_Atrio.Models.Data
{
    public class EmploisData
    {
        [Key]
        public int EmploisId { get; set; }
        [StringLength(100)]
        public string? Company { get; set; }
        [StringLength(100)]
        public string? Post { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateDebut { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateFin { get; set; }
        public int? PersonneId { get; set; }
        public PersonneData? Personne { get; set; }

    }
}
