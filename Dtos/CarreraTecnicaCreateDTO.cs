using System.ComponentModel.DataAnnotations;

namespace WebApiKalum.Dtos
{
    public class CarreraTecnicaCreateDTO
    {
        public string CarreraId { get; set; }
        
        
        [StringLength(128,MinimumLength = 5, ErrorMessage = "La cantidad de caracteres es {2} y maxima es {1} para el campo")]
        public string Nombre { get; set; }
       
    }


}