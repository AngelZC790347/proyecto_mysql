#include "cadena_funciones.h"
#include <stdio.h>
void parse_arguments_to_query(char *dest,const char**argv,int argc){	
		/* code */
	FILE*wf= fopen("/Users/angelcano/Documents/Sublime/clang_files/proyecto_mysql/conections/warning.txt","a+");
	fprintf(wf,"%s\n",argv[1]);
	strcat(dest,argv[1]);
	fclose(wf);
}
int get_total_length_argv(const char**argv,int argc){
	return strlen(argv[1]);
}