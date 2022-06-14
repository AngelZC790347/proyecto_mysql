using models;
using services;
namespace  controllers
{
    class ProductoPlatillosController:ProductoPlatillosService
    {
        public void registrarPlatilloNuevoAlServicio(){
            throw new NotImplementedException();
        }
        public void eliminarPlatilloPorIdlServicio(){
            throw new NotImplementedException();
        } 

        static public List <ProductoPlatillos> obtenerMenu(){
            List<string>platilosStr=new ProductoPlatillosService().getAllInformation().Split('\n').ToList();
            List<ProductoPlatillos> productoPlatillos= new List<ProductoPlatillos>(); 
            for (int i = 0; i < platilosStr.Count-1; i++)
            {
             productoPlatillos.Add(parseStringToProductoPlatillos(platilosStr[i]));
            }
            return productoPlatillos;
        }
        static private ProductoPlatillos parseStringToProductoPlatillos(string texto){
            var arr = texto.Split(' ').ToArray();
            return new ProductoPlatillos(ushort.Parse(arr[0]),arr[1],float.Parse(arr[2]));
        }
    }
}