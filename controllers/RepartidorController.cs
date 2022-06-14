using models;
using services;
using System.Text.Json;
namespace controllers
{
    class RepartidorController
    {
        Repartidor repartidorHandler;
        static string path = "tmp_data/repartidoresDisp.json";
        public void registrarAsistenciaRepartidor(Repartidor r1){ 
            insertValueToFile(JsonSerializer.Serialize(r1));
        }
        static private void insertValueToFile(string value){
            using(StreamWriter sw = File.AppendText(path)){sw.Write(value);}
        }
        public void registrarAsistencia(){
            var repartidoresStr=new RepartidoresService().getAllInformation().Split('\n').ToArray();
            using(StreamWriter sw = File.AppendText(path)){sw.Write('[');}
            for (int i = 0; i < repartidoresStr.Length-1; i++)
            {
                if (i!=0)
                {
                   insertValueToFile(",");
                }
                registrarAsistenciaRepartidor(obtenerRepartidor(repartidoresStr[i]));
            }
            insertValueToFile("]");
        }
        public Repartidor obtenerRepartidor(string texto){
            var arr = texto.Split(' ').ToArray();
            System.Console.WriteLine(uint.Parse(arr[0]));
            return new Repartidor(uint.Parse(arr[0]),arr[1]+" "+arr[2],arr[3]);
        }
    }
}