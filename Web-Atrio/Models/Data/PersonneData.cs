using System.ComponentModel.DataAnnotations;

namespace Web_Atrio.Models.Data
{
    public class PersonneData
    {
        [Key]
        public int PersonneId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; } = string.Empty;
        [StringLength(100)]
        public string Prenom { get; set; } = string.Empty ;
        public DateTime DateNaissance { get; set; }
        public ICollection<EmploisData>? EmploisData { get; set; }
    }
}
