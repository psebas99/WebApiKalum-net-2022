using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiKalum.Entities;
using WebApiKalum.Dtos;


namespace WebApiKalum.Controllers
{
    [ApiController]
    [Route("v1/KalumManagement/CarreraTecnica")]
    public class CarreraTecnicaController : ControllerBase
    {
        private readonly KalumDbContext DbContext;
        private readonly ILogger<CarreraTecnicaController> Logger;
        private readonly IMapper Mapper;
        public CarreraTecnicaController(KalumDbContext _DbContext, ILogger<CarreraTecnicaController> _Logger, IMapper _Mapper)

        {
            this.DbContext = _DbContext;
            this.Logger = _Logger;
            this.Mapper = _Mapper;
        }

      /*  [HttpGet]
        public async Task<ActionResult<IEnumerable<CarreraTecnica>>> Get()
        {
            List<CarreraTecnica> carrerasTecnicas = null;
            Logger.LogDebug("Iniciando proceso de consulta de ccarreras tecnicad rm la base de datos");
            //tarea1
            carrerasTecnicas = await DbContext.CarreraTecnica.ToListAsync();
            //tarea2
            if (carrerasTecnicas == null || carrerasTecnicas.Count == 0)
            {
                Logger.LogWarning("No existe carreras técnicas");
                return new NoContentResult();
            }
            List<CarreraTecnicaAspiranteList> carreras = Mapper.Map<List<CarreraTecnicaList>>(carrerasTecnicas);
            Logger.LogInformation("Se ejecuta la petición de forma exitosa");
            return Ok(carreras);
        }*/

        [HttpGet("{id}", Name = "GetCarreraTecnica")]
        public async Task<ActionResult<CarreraTecnica>>GetCarreraTecnica(string id)
        {
            Logger.LogDebug("Inicando el proceso de busqueda con el id" + id);
            var carrera = await DbContext.CarreraTecnica.Include(c => c.Inscripciones).FirstOrDefaultAsync(ct => ct.CarreraId == id);
            if(carrera == null)
            {
                Logger.LogWarning("No existe la carrera técnica con el id" + id);
                return new NoContentResult();
            }
            Logger.LogInformation("Finalizando el proceso de busqueda de forma exitosa");
            return Ok(carrera);
        }

        [HttpPost]

        public async Task<ActionResult<CarreraTecnica>> Post([FromBody] CarreraTecnicaCreateDTO value)
        {
            Logger.LogDebug("Iniciando el proceso de agregar una carrera tecnica nueva");

            CarreraTecnica nuevo = Mapper.Map<CarreraTecnica>(value);
            nuevo.CarreraId = Guid.NewGuid().ToString().ToUpper();
            await DbContext.CarreraTecnica.AddAsync(nuevo);
            await DbContext.SaveChangesAsync();
            Logger.LogInformation("Finalizando el proceso de agregar una carrera técnica nueva");
            return new CreatedAtRouteResult("GetCarreraTecnica", new{id = nuevo.CarreraId}, value);


        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<CarreraTecnica>> Delete(string id)
        {
            Logger.LogDebug("Iniciando elproceso de eliminación del registro");
            CarreraTecnica carreraTecnica = await DbContext.CarreraTecnica.FirstOrDefaultAsync(ct => ct.CarreraId == id);
            if(carreraTecnica == null)
            {
                Logger.LogWarning("No se encontro ninguna carrera técnica con el id {id}");
                return NotFound();
            }
            else
            {
                DbContext.CarreraTecnica.Remove(carreraTecnica);
                await DbContext.SaveChangesAsync();
                Logger.LogInformation($"Se ha eliminado correctamente la carrera técnica con el id {id}");
                return carreraTecnica;
            }
        }

       [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] CarreraTecnica value)
        {
            Logger.LogDebug($"iniciando el proceso de actualizacion de la carrera técnica con el id {id}");
            CarreraTecnica carreraTecnica = await DbContext.CarreraTecnica.FirstOrDefaultAsync(ct => ct.CarreraId == id);
            if (carreraTecnica == null)
            {
                Logger.LogWarning($"No existe la carrera técnica con el Id {id}");
                return BadRequest();
            }
            carreraTecnica.Nombre = value.Nombre;
            DbContext.Entry(carreraTecnica).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            Logger.LogInformation("LOs datos han sido actualizados correctamente");
            return NoContent();

        }
         

    }
}