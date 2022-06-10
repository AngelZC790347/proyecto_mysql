using System.Data;
using System.Linq;
namespace services
{
    class ProductoPlatillosService:IPorductosPlatillosServices
    {
        protected async Task<List<ProductoPlatillos>> IPorductosPlatillosServices.obtenerPlatillos()
        {
            using (SqlConnection  connection = new ()){

            }
        }
    }
}