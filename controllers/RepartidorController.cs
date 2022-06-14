using models;
using services;
using System.Text.Json;
using System.Linq;
namespace controllers
{
    class RepartidorController
    {
        Repartidor repartidorHandler;
        static string path = "tmp_data/repartidoresDisp.json";
        public void registrarAsistenciaRepartidor(Repartidor r1){        
            using(StreamWriter sw = File.CreateText(path)){sw.Write((r1));}
        }  
        public void obtenerRepartidores(){
            Array repartidores=new RepartidoresService().getAllInformation().Split('\n').ToArray();   
            
            // foreach (string item in repartidores)
            // {
            //     System.Console.WriteLine("item:"+item);
            //     obtenerRepartidor(item);
            //    // registrarAsistenciaRepartidor(tmpR);
            // }
        }
        public void obtenerRepartidor(string texto){
            var arr = texto.Split(' ').ToArray();
            System.Console.WriteLine(uint.Parse(arr[0]));
            //return new Repartidor(uint.Parse(arr[0]),arr[1]+arr[2],arr[3]);
        }
    }
}