using controllers;
namespace proyecto_final
{
    class Program
    {
        public static void Main(){
            RepartidorController repartidor = new RepartidorController();
            repartidor.obtenerRepartidores();
        }
    }
}