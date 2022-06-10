using models;

namespace services
{
    interface IPorductosPlatillosServices
    {
        protected Task<List<ProductoPlatillos>>obtenerPlatillos();       
    }
}