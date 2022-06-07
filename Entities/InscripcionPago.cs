namespace WebApiKalum.Entities
{
    public class InscripcionPago
    {
        public string BoletaPago { get; set; }
        public string NoExpediente { get; set; }
        public string Anio { get; set; }
        public double Monto { get; set; }
        public virtual Aspirante Aspirantes { get; set; }
    }
}