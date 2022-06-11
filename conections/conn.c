#include "config.h"
#include "conn.h"
#include "utilities/errors.h"
#include "utilities/cadena_funciones.h"
// definimos la base de datos a consultar
const char *database = "stocks"; /*nombre de la base de datos a consultar */
int main(int argc, char const *argv[])
{
	char *query;	
	handle_errors(argc<2,"Modo de uso agrege la consulta");
	query = malloc(get_total_length_argv(argv,argc)*sizeof(char));
	parse_arguments_to_query(query,argv,argc);
	t_task_queve conns;
	for (int i = 0; i < MAX_TASKS; i++)
	{
		/* encolando conexiones*/
		init_task(&conns[i],query);
	}
	return EXIT_SUCCESS;
}

void init_task(t_query_task * task ,const char *newQuery){
	FILE * f = fopen("../tmp_data/cnn.output.txt","w");
	handle_errors(!f,"Cant open file");
	unsigned int timeStamp = 2;
	task->conn  = mysql_init(NULL);
	handle_errors(!task->conn,mysql_error(task->conn));
	task->query = (char*)malloc(strlen(newQuery)*sizeof(char));
	printf("Iniciando conexion\n");
	system("sleep 3");
	strcpy(task->query,newQuery);
	handle_errors(mysql_options(task->conn,MYSQL_OPT_CONNECT_TIMEOUT,&timeStamp),mysql_error(task->conn));
	handle_errors(!mysql_real_connect(task->conn,SERVER,USER,PASSWORD,database,PORT,SOCKET,1),mysql_error(task->conn));
	handle_errors(mysql_query(task->conn,newQuery),mysql_error(task->conn));
	task->res = mysql_use_result(task->conn);
	handle_errors(!task->res,mysql_error(task->conn));
	while((task->row = mysql_fetch_row(task->res))!=NULL){
		for (int i = 0; i < mysql_num_fields(task->res); ++i)
		{
			/* code */
			fprintf(f,"%s ",task->row[i]);
		}
		printf("\n");
	}
	mysql_free_result(task->res);
	mysql_close(task->conn);
}

