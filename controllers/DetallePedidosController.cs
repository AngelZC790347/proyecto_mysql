using models;
using services;
using System.Text.Json;
namespace controllers{
    class DetallePedidosController
    {
        public ulong id{get;}
        private List<Pedido> pedidos;
        
        public DetallePedidosController(){
            this.id = (ulong)HashCode.Combine(TimeOnly.FromDateTime(DateTime.Now));
            pedidos = new List<Pedido>();
        }
 
        public void dumpInfoToaService(){
            new DetallePedidosService().insertarRegistroPedido(this.id,JsonSerializer.Serialize(this.pedidos));
        }
        public void agregarModificarPedidosaEnviar(Pedido nuevoPedido){
            Pedido? pedidoToMatch = this.pedidos.Find((p)=>p.producto.id==nuevoPedido.producto.id);
            if(pedidoToMatch ==null){
                this.pedidos.Add(nuevoPedido);
            }else{
                pedidoToMatch.cantidad = nuevoPedido.cantidad;
            }
        }
        public void quitarPedido(ushort id){
            Pedido pedidoToDelete = this.pedidos.Find((p)=>p.producto.id==id)??throw new Exception("No se encontro pedido para elminar verifique el codigo");
            this.pedidos.Remove(pedidoToDelete); 
        }
    }
}