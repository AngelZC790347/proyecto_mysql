using controllers;
using models;
namespace proyecto_final
{
    class Program
    {
        public static void Main(){
            try
            {
                ClienteController cliente = new ClienteController(78312331,"test@name","test@lastname"); 
                System.Console.WriteLine( cliente.solicitarMenu());
                System.Console.WriteLine(cliente.solicitarEstadoDelPedido());    
            }
            catch (System.Exception e)
            {
                Console.Error.Write(e.Message);
                Environment.Exit(1);
            }
            
        }
    }
}