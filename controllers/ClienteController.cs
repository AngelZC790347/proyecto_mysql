using models;
using services;
namespace controllers
{
    class ClienteController:Cliente
    {
        private DetallePedidosController pedidosHandler;
        public ClienteController(uint dni,String nombre,String apellido):base(dni,nombre,apellido){
            this.pedidosHandler = new DetallePedidosController();
        }
        public void  agregarPedido(ushort id,byte cantidad){
           this.pedidosHandler.agregarModificarPedidosaEnviar(new Pedido(new ProductoPlatillosController().obtenerProductoDelId(id),cantidad));     
        }
        public string solicitarMenu(){
            string menu="";
            ProductoPlatillosController.obtenerMenu().ForEach((p)=>menu+=p.detallar());
            return menu;
        }

        public void confirmarPedido(){
            this.pedidosHandler.dumpInfoToaService();
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