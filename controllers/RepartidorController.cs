using models;
using services;
using System.Text.Json;
namespace controllers
{
    class RepartidorController
    {
        static string path = "tmp_data/repartidoresDisp.json";
        
        public List<Repartidor> repartidoresDisp;
        
        public RepartidorController(){
            repartidoresDisp = new List<Repartidor>();
            if (!File.Exists(path))
            {
                this.repartidoresDisp=obtenerRepartidoresDelServicio();
                registrarAsistencia(this.repartidoresDisp);
            }else{
                actualizarRepartidoresDisponibles();
            }           
            
        }
       
        public void registrarRepartidor(Repartidor r1){
            actualizarRepartidoresDisponibles();
            this.repartidoresDisp.Add(r1);
            registrarAsistencia(this.repartidoresDisp);
        }
       
        public Repartidor agignarRepartidor(){
            actualizarRepartidoresDisponibles();
            Repartidor repartidorAsginado = this.repartidoresDisp[this.repartidoresDisp.Count-1];
            this.repartidoresDisp.Remove(repartidorAsginado);
            registrarAsistencia(this.repartidoresDisp);
            return repartidorAsginado;
        }
       
        private List<Repartidor>obtenerRepartidoresDisponibles(){
            JsonDocument jdoc =JsonDocument.Parse(File.ReadAllText(path));
            List<Repartidor> r = new List<Repartidor>();
            r.AddRange((List<Repartidor>)jdoc.Deserialize(r.GetType()));
            return r;
        }
       
        private void actualizarRepartidoresDisponibles(){
            this.repartidoresDisp = obtenerRepartidoresDisponibles();
        }
       
        static void registrarAsistencia(List<Repartidor> repartidoresAsistentes){
            using (Utf8JsonWriter writer = new Utf8JsonWriter(File.CreateText(path).BaseStream))
            {
                writer.WriteRawValue(JsonSerializer.Serialize(repartidoresAsistentes));
            }
        }
       
        static private List<Repartidor> obtenerRepartidoresDelServicio(){
            List <String> repartidoresStr = new RepartidoresService().getAllInformation().Split("\n").ToList();
            List<Repartidor>repartidores = new List<Repartidor>();
            for (int i = 0; i <repartidoresStr.Count-1; i++)
            {
                repartidores.Add(parseStringToRepartidor(repartidoresStr[i]));
            }
            System.Console.WriteLine(repartidores.Count);
            return repartidores;
        }
       
        //Parsea una cadena en un entidad repartidor
        static private Repartidor parseStringToRepartidor(string texto){
             var arr = texto.Split(' ').ToArray();
             return new Repartidor(uint.Parse(arr[0]),arr[1]+" "+arr[2],arr[3]);
        }
    }
}