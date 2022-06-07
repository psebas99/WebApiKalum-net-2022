namespace WebApiKalum.Entities
{
    public class ResultadosExamenAdmision
    {
        public string NoExpediente { get; set; }    
        public string Anio { get; set; }
        public string Descripcion { get; set; }
        public int Nota { get; set; } 
        public virtual Aspirante Aspirantes { get; set; }
    }
}