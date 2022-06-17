namespace models{
    class ProductoPlatillos
    {
        public ushort id{get;set;}
        public String nombre{get;set;}
        public float costo{get;set;}
        public ProductoPlatillos(ushort id,String nombre , float costo){
            this.id = id;
            this.nombre = nombre;
            this.costo = costo;
        }
        public string detallar(){
            return $"{id} {nombre}\t.................................... \t{costo}\n";
        }        
    }
}