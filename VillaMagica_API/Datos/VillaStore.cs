using VillaMagica_API.Modelos.DTO;

namespace VillaMagica_API.Datos
{
    public  static class VillaStore
    {
        public static List<VillaDTO> villalist = new List<VillaDTO>
        {
            new VillaDTO {Id=1,Nombre="Vista a la picina"},
            new VillaDTO{Id=2,Nombre="Vista a la playa"}
        };
    }
}
