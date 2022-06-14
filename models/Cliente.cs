using generics;

namespace models{
    class Cliente:Persona
    {
        protected Cliente(uint dni,String nombre,String apellido):base(dni,nombre,apellido){

        }
    }
}