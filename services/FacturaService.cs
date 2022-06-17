namespace services
{
    class FacturaService : RestApiConectorService
    {
        public FacturaService() : base("factura_pedidos"){}
        public string obtenerEntidadPorId(ulong id)
        {
            return  this.dispatchQuery($"select estado from {this.table_name} where id = {id}");
        }
        public void insertOrUpdateRegistroFactura(ulong id_pedido,uint id_cliente,float monto){
            this.dispatchQuery($"insert into {this.table_name} (id_pedido,id_cliente,id,monto) values ({id_pedido},{id_cliente},{id_pedido+id_cliente},{monto})");   
        } 
    }
}