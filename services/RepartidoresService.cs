namespace services
{
    class RepartidoresService : RestApiConectorService,IEntidadesUnicasService
    {
        public RepartidoresService() : base("repartidores"){}
        public string obtenerEntidadPorId(long id)
        {
            return this.dispatchQuery($"select * from ${this.table_name} where dni == ${id}");
        }
    }
}