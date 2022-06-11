u
namespace services
{
    class ProductoPlatillosService:IPorductosPlatillosServices
    {
        protected async Task<List<ProductoPlatillos>> IPorductosPlatillosServices.obtenerPlatillos()
        {
            const String query = "select * from producto_platillos";

        }
    }
}