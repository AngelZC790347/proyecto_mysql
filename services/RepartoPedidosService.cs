namespace services
{
    class RepartoPedidosService : RestApiConectorService,IRepartoPedidosService
    {
        public RepartoPedidosService():base("reparto_pedidos"){}
        public string obtenerEntidadPorId(ulong id)
        {
            return  this.dispatchQuery($"select estado from {this.table_name} where id_pedido = {id}");
        }
        public void insertOrUpdateRegistroReparto(ulong id_pedido,uint id_repartidor,uint id_cliente,string direccion,byte estado){
            string tmpresponse = this.obtenerEntidadPorId(id_pedido);
            if (tmpresponse == " " || tmpresponse == "" || tmpresponse ==null)
            {
                this.dispatchQuery($"insert into {this.table_name} (id_pedido,id_repartidor,id_cliente,direccion,estado) values ({id_pedido},{id_repartidor},{id_cliente},'{direccion}',{estado})");    
            }else
            {
                this.dispatchQuery($"update {this.table_name} set direccion = '{direccion}' , estado = {estado} where id_pedido = {id_pedido}");    
            }

        }
    }
}