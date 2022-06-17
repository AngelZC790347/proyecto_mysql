namespace models
{
    class Pedido
    {
        public ProductoPlatillos producto {get;set;}
        public byte cantidad {get;set;}
        public Pedido(ProductoPlatillos producto,byte cantidad){
            this.producto = producto;
            this.cantidad =cantidad;
        }
        public string showInfo(){
            return $"{this.producto.nombre}\t{this.cantidad}\n";
        }
    }
}