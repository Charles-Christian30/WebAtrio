using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Web_Atrio.Models.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web_Atrio.Models.Dto
{
    public class PersonneDtoResponse
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateNaissance { get; set; }
        public ICollection<EmploisDto>? EmploisData { get; set; }
    }
}
