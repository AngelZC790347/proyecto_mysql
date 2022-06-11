#include "cadena_funciones.h"
void parse_arguments_to_query(char *dest,const char**argv,int argc){	
	for (int i = 1; i < argc; ++i)
	{
		/* code */
		strcat(dest,argv[i]);
		strcat(dest," ");
	}
}
int get_total_length_argv(const char**argv,int argc){
	int tam_input = 0;
	for (int i = 1; i < argc; ++i)
	{
		tam_input += strlen(argv[i]) + argc-2;
	}
	return tam_input;
}