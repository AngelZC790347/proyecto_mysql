using System.Diagnostics;
namespace services
{
    class RestApiConectorService:IRestApiConector
    {
        protected readonly String table_name;
        protected Process process;
        static string conectorPath = "conections/build/rest_api"; 
        private StreamReader ?response;
        protected RestApiConectorService(string table_name){
            this.table_name = table_name;
            process = new Process(); 
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.FileName = conectorPath;
        }
        public int contarRegistros()
        {
           return Int32.Parse(dispatchQuery($"SELECT COUNT(*) FROM {this.table_name} WHERE true"));
            
        }
        public string describeDB()
        {
            throw new NotImplementedException();
        }
        public string getAll()
        {
            throw new NotImplementedException();
        }
        private int ejecutarConsulta(string query){
            this.process.StartInfo.Arguments = query;
            this.process.Start();
            this.response = this.process.StandardOutput;
            this.process.WaitForExit();
            return this.process.ExitCode;              
        }
        protected string dispatchQuery(string  query){
            if (ejecutarConsulta(query) == 1)
            {
                throw new Exception(this.response.ReadToEnd());
            }
            return this.response.ReadToEnd(); 
        }
        public string getAllInformation(){
            return dispatchQuery($"select * from {this.table_name}");                     
        }
    }
}