using controllers;
using models;
namespace proyecto_final
{
    class Program
    {
        public static void Main(){
            RepartidorController repartidor = new RepartidorController();
            
            Repartidor repartidor2 = new Repartidor(7665613,"Piero Joel","Valenzuela Chirinos");
            repartidor.registrarRepartidor(repartidor2);
        }
    }
}