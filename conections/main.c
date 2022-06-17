#include "config.h"
int main(int argc, char const *argv[])
{	
	FILE*wf= fopen("/Users/angelcano/Documents/Sublime/clang_files/proyecto_mysql/conections/warning.txt","a+");
	t_query_task *conexion = NULL;
	handle_errors(argc<2,"Modo de uso agrege la consulta");
	fprintf(wf,"%s ",argv[1]);
	// query = malloc(get_total_length_argv(argv,argc)*sizeof(char));
	// parse_arguments_to_query(query,argv,argc);
	fclose(wf);
	init_query_task(conexion,argv[1]);
	free(conexion);
	return 0;
}