using System.ComponentModel.DataAnnotations;

namespace Web_Atrio.Models.Dto
{
    public class PersonneDtoRequest
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateNaissance { get; set; }
    }
}
