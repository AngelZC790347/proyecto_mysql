#include "config.h"
const char *database = "restaurante"; /*nombre de la base de datos a consultar */
void init_query_task(t_query_task * task ,const char *newQuery){
	if(task == NULL){
		task=create_query_task(newQuery);		
	}
	strcpy(task->query,newQuery);
	handle_errors(!mysql_real_connect(task->conn,SERVER,USER,PASSWORD,database,PORT,SOCKET,1),mysql_error(task->conn));
	handle_errors(mysql_real_query(task->conn,task->query,strlen(task->query)),mysql_error(task->conn));
	while ((task->res = mysql_use_result(task->conn)) != NULL)
	{
		while((task->row = mysql_fetch_row(task->res))!=NULL){
			for (int i = 0; i < mysql_num_fields(task->res); i++)
			{
				/* code */
				printf("%s ",task->row[i]);
			}
			printf("\n");
		}
		mysql_free_result(task->res);
	}
	
	//task->res = mysql_use_result(task->conn);
	//handle_errors(!task->res,mysql_error(task->conn));
	// while((task->row = mysql_fetch_row(task->res))!=NULL){
	// 	for (int i = 0; i < mysql_num_fields(task->res); ++i)
	// 	{
	// 		/* code */
	// 		printf("%s ",task->row[i]);
	// 	}
	// 	printf("\n");
	// }
	// mysql_free_result(task->res);
	mysql_close(task->conn);
}

t_query_task * create_query_task(const char * newQuery){
	FILE*wf= fopen("/Users/angelcano/Documents/Sublime/clang_files/proyecto_mysql/conections/warning.txt","a+");
	t_query_task * new_q_t = (t_query_task *)malloc(sizeof(t_query_task));
	new_q_t->conn  = mysql_init(NULL);
	handle_errors(!new_q_t->conn,mysql_error(new_q_t->conn));
	new_q_t->query = (char*)malloc(strlen(newQuery)*sizeof(char));
	fprintf(wf,"%s %lu\n",newQuery,strlen(newQuery));
	fclose(wf);
	//handle_errors(mysql_options(new_q_t->conn,MYSQL_OPT_CONNECT_TIMEOUT,NULL),mysql_error(new_q_t->conn));
	return new_q_t;
}

