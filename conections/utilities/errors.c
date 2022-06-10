#include"errors.h"
void handle_errors(bool sentencia,const char *mensaje){
	if(!sentencia){
		printf("%s\n",mensaje);
		exit(1);
	}
}