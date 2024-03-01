using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VillaMagica_API.Datos;
using VillaMagica_API.Modelos;
using VillaMagica_API.Modelos.DTO;


namespace VillaMagica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {

            this._logger = logger;
            this._db = db;

        }
        //[HttpGet]
        //public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        //{
        //    _logger.LogInformation("obtener las villas");
        //    return Ok(VillaStore.villalist);
        //}
       [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("obtener las villas");
            return Ok(_db.Villas.ToList());
        }

        //[HttpGet("id", Name = "GetVilla")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(statusCode: 400)]
        //[ProducesResponseType(statusCode: 404)]

        //public ActionResult<VillaDTO> GetVillaByID(int id)
        //{
        //    if (id == 0)
        //    {
        //        _logger.LogError("error con el id" + id);
        //        return BadRequest();
        //    }
        //    var villa = VillaStore.villalist.FirstOrDefault(v => v.Id == id);
        //    if (villa == null)
        //    {
        //        return NotFound();

        //    }
        //    return Ok(villa);
        //}
        [HttpGet("id", Name = "GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 404)]

        public ActionResult<VillaDTO> GetVillaByID(int id)
        {
            if (id == 0)
            {
                _logger.LogError("error con el id" + id);
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(v => v.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            return Ok(villa);
        }



        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public ActionResult<VillaDTO> CrearVilla([FromBody] VillaDTO villa)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);

        //    }

        //    if (VillaStore.villalist.FirstOrDefault(v => v.Nombre.ToLower() == villa.Nombre.ToLower()) != null)
        //    {
        //        ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe");
        //        return BadRequest(ModelState);
        //    }



        //    if (villa == null)
        //    {
        //        return BadRequest(villa);

        //    }
        //    if (villa.Id > 0)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);

        //    }
        //    villa.Id = VillaStore.villalist.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
        //    VillaStore.villalist.Add(villa);
        //    return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);

        //}
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CrearVilla([FromBody] VillaDTO villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (_db.Villas.FirstOrDefault(v => v.Nombre.ToLower() == villa.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }



            if (villa == null)
            {
                return BadRequest(villa);

            }
            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

            Villa modelo = new()
            {
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagenUrl = villa.ImagenUrl,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad,
            };

            _db.Villas.Add(modelo);
            _db.SaveChanges();


            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);

        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult DeleteVilla(int id)
        //{
        //    if (id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var villa = VillaStore.villalist.FirstOrDefault(x => x.Id == id);
        //    if (villa == null)
        //    {
        //        return NotFound();

        //    }
        //    VillaStore.villalist.Remove(villa);
        //    return NoContent();

        //}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();

        }


        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        //{
        //    if (villaDTO == null || id != villaDTO.Id)
        //    {
        //        return BadRequest();

        //    }

        //    VillaStore.villalist.FirstOrDefault(x => x.Id == id).Nombre = villaDTO.Nombre;
        //    VillaStore.villalist.FirstOrDefault(x => x.Id == id).Ocupantes = villaDTO.Ocupantes;
        //    VillaStore.villalist.FirstOrDefault(x => x.Id == id).MetrosCuadrados = villaDTO.MetrosCuadrados;

        //    return NoContent();

        //}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villa)
        {
            if (villa == null || id != villa.Id)
            {
                return BadRequest();

            }
            Villa modelo = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagenUrl = villa.ImagenUrl,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad,
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();


            return NoContent();

        }

        //[HttpPatch("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult UpdatePatchVilla(int id, JsonPatchDocument<VillaDTO> patchDto)
        //{
        //    if (patchDto == null || id == 0)
        //    {
        //        return BadRequest();

        //    }

        //    var vila = VillaStore.villalist.FirstOrDefault(x => x.Id == id);
        //    patchDto.ApplyTo(vila, ModelState);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);

        //    }

        //    return NoContent();

        //}

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatchVilla(int id, JsonPatchDocument<VillaDTO> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();

            }

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(x => x.Id == id);
            VillaDTO modelo = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagenUrl = villa.ImagenUrl,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetrosCuadrados,
                Amenidad = villa.Amenidad,
            };
            if (villa == null) return BadRequest();

            patchDto.ApplyTo(modelo, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            Villa modelo2 = new()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                Detalle = modelo.Detalle,
                ImagenUrl = modelo.ImagenUrl,
                Ocupantes = modelo.Ocupantes,
                Tarifa = modelo.Tarifa,
                MetrosCuadrados = modelo.MetrosCuadrados,
                Amenidad = modelo.Amenidad,

            };
            _db.Villas.Update(modelo2);
            _db.SaveChanges();


            return NoContent();

        }




    }
}
