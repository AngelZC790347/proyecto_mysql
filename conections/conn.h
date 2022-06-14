#ifndef CONN_H
#define CONN_H 
#ifndef MYSQL_H
	#include <mysql.h>
#endif
#define MAX_TASKS 5
typedef struct{
	MYSQL *conn; /* variable de conexión para MySQL */
	MYSQL_RES *res; /* variable que contendra el resultado de la consuta */
	MYSQL_ROW row; /* variable que contendra los campos por cada registro consultado */	
	char * query;
	unsigned int timeDelay;
}t_query_task;

// typedef  t_query_task t_task_queve[MAX_TASKS]; deprecated

/* t_query_task interface*/

void init_query_task(t_query_task * task,const char * newQuery); // start query and return de output

t_query_task * create_query_task(const char * query); // reserve task memory from a query


#endif