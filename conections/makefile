CC = clang
CFLAGS = -Wall -ansi -pedantic
B_DIR = build/
U_DIR = utilities/
D_DIR = debug/

rest_api :main.o conn.o errors.o cadena_funciones.o
	$(CC) -o  $(B_DIR)rest_api  $(D_DIR)main.o $(D_DIR)conn.o $(D_DIR)cadena_funciones.o  $(D_DIR)errors.o `mysql_config --libs_r`

main.o: main.c config.h
	$(CC) `mysql_config --cflags`  -c -o  $(D_DIR)main.o main.c 

conn.o: conn.c $(mysql_config -–libs) config.h 
	$(CC) `mysql_config --cflags`  -c -o  $(D_DIR)conn.o conn.c 

cadena_funciones.o: $(U_DIR)cadena_funciones.c $(U_DIR)cadena_funciones.h
	$(CC) -c -o $(D_DIR)cadena_funciones.o $(U_DIR)cadena_funciones.c

errors.o: $(U_DIR)errors.c $(U_DIR)errors.h
	$(CC) -c -o $(D_DIR)errors.o $(U_DIR)errors.c
	
clean:
	rm $(D_DIR)*.o