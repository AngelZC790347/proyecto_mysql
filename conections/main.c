#include "config.h"
int main(int argc, char const *argv[])
{	
	char *query;
	t_query_task *conexion = NULL;
	handle_errors(argc<2,"Modo de uso agrege la consulta");
	query = malloc(get_total_length_argv(argv,argc)*sizeof(char));
	parse_arguments_to_query(query,argv,argc);
	init_query_task(conexion,query);
	return EXIT_SUCCESS;
}