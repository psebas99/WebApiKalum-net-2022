using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;


namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/KalumManagement/ExamenAdmision")]
    public class ExamenAdmisionController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<ExamenAdmisionController> Logger;
        public ExamenAdmisionController(KalumDbContext _DbContext, ILogger<ExamenAdmisionController> _Logger)
        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamenAdmision>>> Get()
        {
            List<ExamenAdmision> examenAdmisiones = null;
            Logger.LogDebug("Inciciando proceso de consulta de examenes de admisiones.");
            //tarea1
            examenAdmisiones = await DbContext.ExamenAdmision.Include(c => c.Aspirantes).ToListAsync();
            //tarea2
            if (examenAdmisiones == null || examenAdmisiones.Count == 0)
            {
                Logger.LogWarning("No existe carreras técnicas");
                return new NoContentResult();
            }
            Logger.LogInformation("Se ejecuta la petición de forma exitosa");
            return Ok(examenAdmisiones);

        }
        [HttpGet("{id}", Name = "GetExamenAdmision")]
        public async Task<ActionResult<ExamenAdmision>> GetExamenAdmision(string id)
        {
            Logger.LogDebug("Inicando el proceso de busqueda con el id" + id);
            var examen = await DbContext.ExamenAdmision.FirstOrDefaultAsync(ct => ct.ExamenId == id);
            if (examen == null)
            {
                Logger.LogWarning("No existe examen admision con el id" + id);
                return new NoContentResult();
            }
            Logger.LogInformation("Finalizando el proceso de busqueda de forma exitosa");
            return Ok(examen);
        }

    }
}