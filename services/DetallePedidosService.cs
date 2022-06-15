namespace services
{
    class DetallePedidosService : RestApiConectorService,IDetallePedidos
    {
        public DetallePedidosService(): base("detalle_pedidos"){}

        public void insertarRegistroPedido(ulong id, string infoJsonFormat)
        {
            System.Console.WriteLine(infoJsonFormat);
            this.dispatchQuery($"insert into {this.table_name} (id , information) values ({id},JSON_ARRAY({infoJsonFormat}))");
        }

        public string obtenerEntidadPorId(ulong id)
        {
            return  this.dispatchQuery($"select * from {this.table_name} where id = {id}");
        }
    }
}