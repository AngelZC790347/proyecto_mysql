using models;
using services;
namespace controllers{
    class DetallePedidosController
    {
        private ulong id{get;}
        public List<Pedido> pedidos;
        public DetallePedidosController(){
            this.id = (ulong)HashCode.Combine(TimeOnly.FromDateTime(DateTime.Now));
            pedidos = new List<Pedido>();
        }
        public void agregarPedido(Pedido nuevoPedido){
            this.pedidos.Add(nuevoPedido);
        }
    }
}