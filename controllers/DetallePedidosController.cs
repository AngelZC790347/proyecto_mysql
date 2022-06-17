using models;
using services;
using System.Text.Json;
using System.Text.Encodings.Web;
namespace controllers{
    class DetallePedidosController
    {
        public ulong id{get;}
        
        public List<Pedido> pedidos;

        public DetallePedidosController(){
            this.id = (ulong)HashCode.Combine(TimeOnly.FromDateTime(DateTime.Now));
            pedidos = new List<Pedido>();
        }
        public string obtenerInfoDePedido(){
            string ms = "";
            pedidos.ForEach((pd)=>ms += pd.showInfo());
            return ms;
        }
        public void dumpInfoToService(){
            new DetallePedidosService().insertarRegistroPedido(this.id,JsonSerializer.Serialize(this.pedidos).Replace("\"","\\\""));
        }
        public void agregarModificarPedidosaEnviar(Pedido nuevoPedido){
            Pedido? pedidoToMatch = this.pedidos.Find((p)=>p.producto.id==nuevoPedido.producto.id);
            if(pedidoToMatch ==null){
                this.pedidos.Add(nuevoPedido);
            }else{
                pedidoToMatch.cantidad = nuevoPedido.cantidad;
            }
            //System.Console.WriteLine(pedidos[pedidos.Count-1].producto.nombre);
        }
        public void quitarPedido(ushort id){
            Pedido pedidoToDelete = this.pedidos.Find((p)=>p.producto.id==id)??throw new Exception("No se encontro pedido para elminar verifique el codigo");
            this.pedidos.Remove(pedidoToDelete); 
        }
    }
}