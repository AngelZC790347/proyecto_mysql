namespace services
{
    interface IDetallePedidos:IEntidadesUnicasService
    {
        void insertarRegistroPedido(ulong id ,string  infoJsonFormat);
    }
}