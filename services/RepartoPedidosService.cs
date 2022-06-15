namespace services
{
    class RepartoPedidosService : RestApiConectorService,IRepartoPedidosService
    {
        public RepartoPedidosService():base("reparto_pedidos"){}
        public string obtenerEntidadPorId(ulong id)
        {
            return  this.dispatchQuery($"select estado from {this.table_name} where id_pedido = {id}");
        }
    }
}