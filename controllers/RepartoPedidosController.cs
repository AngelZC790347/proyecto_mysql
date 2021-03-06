using services;
using models;


namespace controllers
{
    enum ESTADOS_REPARTO:byte{
        RECIBIDO,
        EN_CAMINO,
        ENTREGADO,
        CANCELADO
    };
    class RepartoPedidosController
    {
        public DetallePedidosController ? pedido;
        public Repartidor repartidorAsignado;
        public Cliente cliente;
        public String direccionCliente;
        public ESTADOS_REPARTO estadoPedido;

        public RepartoPedidosController(Cliente cliente,DetallePedidosController pedido,string direccionCliente){
            this.cliente = cliente;
            this.pedido = pedido;
            this.direccionCliente = direccionCliente;
            this.estadoPedido = ESTADOS_REPARTO.RECIBIDO;
            this.repartidorAsignado=new RepartidorController().agignarRepartidor();
        }
        public void entregarPedido(){
            this.estadoPedido = ESTADOS_REPARTO.ENTREGADO;
            dumpDataToService();
        }
        public void dumpDataToService(){
            new RepartoPedidosService().insertOrUpdateRegistroReparto(this.pedido.id,this.repartidorAsignado.dni,this.cliente.dni,direccionCliente,(byte)estadoPedido);
        }
        public void enviarPedido(){
            this.estadoPedido = ESTADOS_REPARTO.EN_CAMINO; 
            dumpDataToService();
            float monto = 0;
            pedido.pedidos.ForEach((p)=>monto+= (p.cantidad*p.producto.costo));
            System.Console.WriteLine(monto);
            new FacturaService().insertOrUpdateRegistroFactura(pedido.id,cliente.dni,monto);
        }
        public void cancelarPedido(){
            this.estadoPedido = ESTADOS_REPARTO.CANCELADO;
            dumpDataToService();
        }
    }
}