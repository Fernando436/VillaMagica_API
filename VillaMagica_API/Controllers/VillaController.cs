using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using VillaMagica_API.Datos;
using VillaMagica_API.Modelos;
using VillaMagica_API.Modelos.DTO;


namespace VillaMagica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]
       public   ActionResult<IEnumerable<VillaDTO>>  GetVillas()
        {
             return   Ok(VillaStore.villalist);
        }

        [HttpGet("id",Name ="GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(statusCode:400)]
        [ProducesResponseType(statusCode: 404)]

        public  ActionResult<VillaDTO>  GetVillaByID(int id) 
        {
            if (id==0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villalist.FirstOrDefault(v => v.Id == id);
            if (villa==null)
            {
                return NotFound();

            }
            return Ok(villa);
        }

        [HttpPost]


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  ActionResult<VillaDTO> CrearVilla([FromBody] VillaDTO villa ) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (VillaStore.villalist.FirstOrDefault(v =>v.Nombre.ToLower() == villa.Nombre.ToLower()) !=null)
            {
                ModelState.AddModelError("NombreExiste", "La villa con ese nombre ya existe");
                return BadRequest(ModelState);
            }



            if (villa==null)
            {
                return BadRequest(villa);

            }
            if (villa.Id>0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            villa.Id = VillaStore.villalist.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
            VillaStore.villalist.Add(villa); 
            return CreatedAtRoute("GetVilla",new { id = villa.Id  },villa);
        
        } 

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public IActionResult DeleteVilla(int id) 
        {
            if (id==0)
            {
                return BadRequest();
            }
            var villa =VillaStore.villalist.FirstOrDefault(x => x.Id == id);
            if (villa == null)
            {
                return NotFound();
                
            }
            VillaStore.villalist.Remove(villa);
            return NoContent();

        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id,[FromBody] VillaDTO villaDTO) 
        {
            if (villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();

            }

            VillaStore.villalist.FirstOrDefault(x => x.Id == id).Nombre = villaDTO.Nombre;
            VillaStore.villalist.FirstOrDefault(x => x.Id == id).Ocupantes = villaDTO.Ocupantes;
            VillaStore.villalist.FirstOrDefault(x => x.Id == id).MetrosCuadrados = villaDTO.MetrosCuadrados;

            return NoContent();

        }




    }
}
