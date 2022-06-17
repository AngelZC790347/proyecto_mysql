namespace services
{
    class PersonaService : RestApiConectorService
    {
        protected PersonaService(string table_name) : base(table_name){}
         public string obtenerEntidadPorId(ulong id)
        {
            return this.dispatchQuery($"select * from {this.table_name} where dni = {id}");
        }
        public void insertOrUpdateRegistroReparto(uint dni,string nombre,string apellido){
            string tmpresponse = this.obtenerEntidadPorId(dni);
            if (tmpresponse == " " || tmpresponse == "" || tmpresponse ==null)
            {
                this.dispatchQuery($"insert into {this.table_name} (dni,nombre,apellido) values ({dni},'{nombre}','{apellido}')");    
            }else
            {
                this.dispatchQuery($"update {this.table_name} set nombre = '{nombre}',apellido = '{apellido}' where dni = {dni}");    
            }

        }
    }
}