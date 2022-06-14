namespace services
{
    class ProductoPlatillosService:RestApiConectorService,IPorductoPlatillosServices
    {
        public ProductoPlatillosService():base("producto_platillos"){}
        public String obtenerEntidadPorId(long id)
        {            
            return  this.dispatchQuery($"select * from {this.table_name} where id = {id}");
        }
    }
}