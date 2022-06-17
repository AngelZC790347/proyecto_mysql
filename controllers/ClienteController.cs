using models;
using services;
namespace controllers
{
    class ClienteController:Cliente
    {
        RepartoPedidosController info_delivery;
        public DetallePedidosController pedidosHandler;
        public ClienteController(uint dni,String nombre,String apellido):base(dni,nombre,apellido){
            this.pedidosHandler = new DetallePedidosController();
            new ClienteService().insertOrUpdateRegistroReparto(dni,nombre,apellido);
        }
        public void  agregarPedido(ushort id,byte cantidad){
           this.pedidosHandler.agregarModificarPedidosaEnviar(new Pedido(new ProductoPlatillosController().obtenerProductoDelId(id),cantidad));     
        }
        public void confirmarEntregaPedido(){
            this.info_delivery.entregarPedido();
        }
        public string solicitarMenu(){
            string menu="";
            ProductoPlatillosController.obtenerMenu().ForEach((p)=>menu+=p.detallar());
            return menu;
        }
        public void notificarEnvioDePedido(){
            this.info_delivery.enviarPedido();
        }
        public void confirmarPedido(string direccion){
            this.pedidosHandler.dumpInfoToService();
            this.info_delivery  = new RepartoPedidosController(this,this.pedidosHandler,direccion);
            this.info_delivery.dumpDataToService();
        }
        public void cancelarPedido(){
            this.info_delivery.cancelarPedido();
        }
        public int solicitarEstadoDelPedido(){
            string response = new RepartoPedidosService().obtenerEntidadPorId(pedidosHandler.id);
            if (response == "" || response == " "|| response ==null)
            {
                throw new Exception("EL el pedido no se ha encontrado o aun no ha sido confirmado");
            }
            return int.Parse(response);           
        }
    }
}