namespace models{
    class ProductoPlatillos
    {
        private ushort id;
        private String nombre;
        private float costo;
        ProductoPlatillos(ushort id,String nombre , float costo){
            this.id = id;
            this.nombre = nombre;
            this.costo = costo;
        }
        public ushort getId(){
            return id;
        }
        public String getNombre(){
            return nombre;
        }
        public float getCosto(){
            return costo;
        }        
    }
}