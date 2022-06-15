namespace models
{
    class Pedido
    {
        public ProductoPlatillos producto ;
        public byte cantidad;
        public Pedido(ProductoPlatillos producto,byte cantidad){
            this.producto = producto;
            this.cantidad =cantidad;
        }
    }
}