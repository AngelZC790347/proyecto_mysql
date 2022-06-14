#include "config.h"
const char *database = "restaurante"; /*nombre de la base de datos a consultar */
void init_query_task(t_query_task * task ,const char *newQuery){
	if(task == NULL){
		task=create_query_task(newQuery);		
	}
	system("sleep 2");
	strcpy(task->query,newQuery);	
	handle_errors(!mysql_real_connect(task->conn,SERVER,USER,PASSWORD,database,PORT,SOCKET,1),mysql_error(task->conn));
	handle_errors(mysql_query(task->conn,newQuery),mysql_error(task->conn));
	task->res = mysql_use_result(task->conn);
	handle_errors(!task->res,mysql_error(task->conn));
	while((task->row = mysql_fetch_row(task->res))!=NULL){
		for (int i = 0; i < mysql_num_fields(task->res); ++i)
		{
			/* code */
			printf("%s ",task->row[i]);
		}
		printf("\n");
	}
	mysql_free_result(task->res);
	mysql_close(task->conn);
}

t_query_task * create_query_task(const char * newQuery){
	t_query_task * new_q_t = (t_query_task *)malloc(sizeof(t_query_task));
	unsigned int timeStamp = 2;
	new_q_t->conn  = mysql_init(NULL);
	handle_errors(!new_q_t->conn,mysql_error(new_q_t->conn));
	new_q_t->query = (char*)malloc(strlen(newQuery)*sizeof(char));
	handle_errors(mysql_options(new_q_t->conn,MYSQL_OPT_CONNECT_TIMEOUT,&timeStamp),mysql_error(new_q_t->conn));
	return new_q_t;
}

