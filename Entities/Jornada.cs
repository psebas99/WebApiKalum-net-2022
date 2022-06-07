namespace WebApiKalum.Entities
{

public class Jornada
    {   
        public string JornadaId { get; set; }

        public string NombreCorto {get; set; }
        public string Descripcion {get; set; }

        //RELACION DE JORNADA A ASPIRANTE
        public virtual List<Aspirante> Aspirantes { get; set; }

        public virtual List<Inscripcion> Inscripciones { get; set; }


    }
}
