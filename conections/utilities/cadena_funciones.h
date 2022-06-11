#ifndef CADENA_FUNCIONES_H
#define CADENA_FUNCIONES_H
#ifndef STRING_H
	#include <string.h>
#endif
#ifndef STDLIB_H
	#include <stdlib.h>
#endif
void parse_arguments_to_query(char *dest,const char**argv,int a);
int get_total_length_argv(const char**argv,int argc);
#endif