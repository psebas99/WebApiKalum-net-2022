namespace WebApiKalum.Entities
{

    public class Aspirante
    {
        public string NoExpediente {get; set; }
        public string Apellidos {get; set; }
        public string Nombres {get; set; }
        public string Direccion {get; set; }
        public string Telefono {get; set; }
        public string Email {get; set; }
        public string Estatus {get; set; }
        public string CarreraId {get; set; }
        public string JornadaId { get;  set; }
        public string ExamenId {get; set; }
        public  virtual CarreraTecnica CarreraTecnica {get; set; }
        public  virtual  Jornada Jornada {get; set; }
        public virtual ExamenAdmision ExamenAdmision {get; set; }
        public virtual List<InscripcionPago> InscripcionPagos {get; set; }
        public virtual List<ResultadosExamenAdmision> ResultadosExamenAdmision { get; set; }

    
    }





}