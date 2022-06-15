using controllers;
namespace proyecto_final
{
    class Program
    {
        static string nombre ="Amgeñ Gabriel", apellido = "Zuñiga Cano";
        static uint dni= 76608998;
        public static void Main(){
            int option;
            // Console.Clear();
            // System.Console.WriteLine("1 . Menu de Admin");
            // System.Console.WriteLine("2 . Menu de Cliente");
            // System.Console.WriteLine("0 . Salir");
            menuCliente();
            // try{
            //     System.Console.Write("OP: ");
            //     option = int.Parse(Console.ReadLine());
            //     switch (option)
            //     {
            //         case 0:
            //             Environment.Exit(0);
            //             break;
            //         case 1:
            //             menuAdmin();
            //             break;
            //         case 2:
            //             Console.Clear();
            //             System.Console.WriteLine("Ingrese sus Datos\n");
            //             System.Console.Write("Nombre: ");
            //             nombre = Console.ReadLine();
            //             System.Console.WriteLine();
            //             System.Console.Write("Apellido: ");
            //             apellido = Console.ReadLine();
            //             System.Console.WriteLine();
            //             System.Console.Write("Dni: ");
            //             dni = uint.Parse(Console.ReadLine());
            //             Console.Clear();
            //             menuCliente();
            //             break;        
            //         default:
            //             throw new Exception($"{option} no es una opcion disponible");
            //     }
            // }catch (Exception e){
            //     Console.Error.WriteLine(e.Message,e.Source);
            //     Environment.Exit(1);
            // }
        }
        private static void menuAdmin(){

        }   
        private static void menuCliente(){
            System.Console.WriteLine($"Menu de Cliente {nombre} {apellido}");
            ClienteController actualCliente = new ClienteController(dni,nombre,apellido);
            System.Console.WriteLine(actualCliente.solicitarMenu());
            actualCliente.agregarPedido(1,2);
            actualCliente.agregarPedido(3,2);
            actualCliente.confirmarPedido("Mz. A Lt. 1 Urb LA Libertad");
        }
    }
}