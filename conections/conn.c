#include "config.h"
#include "conn.h"
#include <string.h>
#include "utilities/errors.h"
// definimos la base de datos a consultar
const char *database = "restaurante"; /*nombre de la base de datos a consultar */
int main(int argc, char const *argv[])
{
	t_task_queve conns;
	for (int i = 0; i < MAX_TASKS; i++)
	{
		/* encolando conexiones*/
		init_task(&conns[i],"show tables;");
	}
	return EXIT_SUCCESS;
}

void init_task(t_query_task * task ,const char *newQuery){
	unsigned int timeStamp = 2;
	task->conn  = mysql_init(NULL);
	handle_errors(task->conn!=NULL,mysql_error(task->conn));
	task->query = (char*)malloc(strlen(newQuery)*sizeof(char));
	printf("Iniciando conexion\n");
	strcpy(task->query,newQuery);
	handle_errors(mysql_options(task->conn,MYSQL_OPT_CONNECT_TIMEOUT,&timeStamp),mysql_error(task->conn));
	handle_errors(mysql_real_connect(task->conn,SERVER,USER,PASSWORD,database,PORT,SOCKET,1),mysql_error(task->conn));
	mysql_close(task->conn);
}

