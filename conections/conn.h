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
typedef  t_query_task t_task_queve[MAX_TASKS];
void init_task(t_query_task * task,const char * newQuery);
#endif