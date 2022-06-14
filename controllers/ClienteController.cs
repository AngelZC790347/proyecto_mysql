using models;

namespace controllers
{
    class ClienteController:Cliente
    {
        public ClienteController(uint dni,String nombre,String apellido):base(dni,nombre,apellido){}

        public string pedirMenu(){
            string menu="";
            ProductoPlatillosController.obtenerMenu().ForEach((p)=>menu+=p.detallar());
            return menu;
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}