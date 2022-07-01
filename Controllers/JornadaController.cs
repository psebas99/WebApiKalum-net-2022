using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;


namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/KalumManagement/Jornada")]
    public class JornadaController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<JornadaController> Logger;
        public JornadaController(KalumDbContext _DbContext, ILogger<JornadaController> _Logger)
        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JornadaController>>> Get()
        {
            List<Jornada> jornada = null;
            Logger.LogDebug("Inciciando proceso de consulta de jornadas.");
            //tarea1
            jornada = await DbContext.Jornada.Include(c => c.Aspirantes).Include(c => c.Inscripciones).ToListAsync();
            //tarea2
            if (jornada == null || jornada.Count == 0)
            {
                Logger.LogWarning("No existe jornadas");
                return new NoContentResult();
            }
            Logger.LogInformation("Se ejecuta la petición de forma exitosa");
            return Ok(jornada);
        }

        [HttpGet("{id}", Name = "GetJornada")]
        public async Task<ActionResult<Jornada>> GetJornada(string id)
        {
            Logger.LogDebug("Inicando el proceso de busqueda con el id" + id);
            var jornadas = await DbContext.Jornada.FirstOrDefaultAsync(ct => ct.JornadaId == id);
            if (jornadas == null)
            {
                Logger.LogWarning("No existe la carrera técnica con el id" + id);
                return new NoContentResult();
            }
            Logger.LogInformation("Finalizando el proceso de busqueda de forma exitosa");
            return Ok(jornadas);
        }





    }
}