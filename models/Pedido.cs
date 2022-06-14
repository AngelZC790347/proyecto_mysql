namespace models
{
    class Pedido
    {
        ProductoPlatillos producto ;
        byte cantidad;
        public Pedido(ProductoPlatillos producto,byte cantidad){
            this.producto = producto;
            this.cantidad =cantidad;
        }
    }
}