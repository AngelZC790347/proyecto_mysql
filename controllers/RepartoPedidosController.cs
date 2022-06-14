using models;
enum ESTADOS_REPARTO{
   RECIBIDO,
   EN_CAMINO,
   ENTREGADO,
   CANCELADO
};

namespace controllers
{
    class RepartoPedidosController
    {
        public DetallePedidosController ? pedido;
        public Repartidor repartidorAsignado;
        public Cliente cliente;
        public   String direccionCliente;
        public ESTADOS_REPARTO estaoPedido;

        public RepartoPedidosController(Cliente cliente,DetallePedidosController pedido,string direccionCliente){
            this.cliente = cliente;
            this.pedido = pedido;
            this.direccionCliente = direccionCliente;
            this.estaoPedido = ESTADOS_REPARTO.RECIBIDO;
        }
        
    }
}