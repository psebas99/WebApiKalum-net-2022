using System.ComponentModel.DataAnnotations;

namespace WebApiKalum.Entities
{
    public class CarreraTecnica
    {
        [Required (ErrorMessage = "El campo{0} es requerido")]
        public string CarreraId {get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido") ]
        [StringLength(128,MinimumLength = 5, ErrorMessage = "La cantidad de caracteres es {2} y maxima es {1} para el campo")]
        
        public string Nombre {get; set; }
        public virtual List<Aspirante> Aspirantes {get; set; }
        public virtual List<Inscripcion> Inscripciones { get; set; }
        public virtual List <InversionCarreraTecnica> InversionCarreraTecnica { get; set; }
        
    }
}