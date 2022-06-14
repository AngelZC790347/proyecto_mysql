namespace models{
    class ProductoPlatillos
    {
        public ushort id;
        public String nombre;
        public float costo;
        public ProductoPlatillos(ushort id,String nombre , float costo){
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
        public string detallar(){
            return $"{nombre}....................................{costo}\n";
        }        
    }
}