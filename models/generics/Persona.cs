namespace generics{
    class Persona
    {
        protected uint dni{get;}
        public String nombre{get;}
        public String apellido{get;}

        public Persona(uint dni,String nombre,String apellido){
            this.dni = dni;
            this.nombre = nombre;
            this.apellido= apellido;
        }
    }
}