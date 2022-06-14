namespace generics{
    class Persona
    {
        protected uint dni{get;}
        protected String nombre{get;}
        protected String apellido{get;}

        public Persona(uint dni,String nombre,String apellido){
            this.dni = dni;
            this.nombre = nombre;
            this.apellido= apellido;
        }
    }
}