using VillaMagica_API.Modelos.DTO;

namespace VillaMagica_API.Datos
{
    public  static class VillaStore
    {
        public static List<VillaDTO> villalist = new List<VillaDTO>
        {
            new VillaDTO {Id=1,Nombre="Vista a la picina",Ocupantes=3,MetrosCuadrados=20},
            new VillaDTO{Id=2,Nombre="Vista a la playa",Ocupantes=5,MetrosCuadrados=10}
        };
    }
}
