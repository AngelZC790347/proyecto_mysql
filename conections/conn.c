#include <mysql.h>
#include <stdlib.h>
#include <stdio.h>
#include "config.h"
#include<stdbool.h>
// definimos la base de datos a consultar
const char *database = "restaurante"; /*nombre de la base de datos a consultar */
int main(int argc, char const *argv[])
{
	MYSQL *conn; /* variable de conexión para MySQL */
	MYSQL_RES *res; /* variable que contendra el resultado de la consuta */
	MYSQL_ROW row; /* variable que contendra los campos por cada registro consultado */
	conn = mysql_init(NULL); /*inicializacion a nula la conexión */
	/* conectar a la base de datos */
	if (!mysql_real_connect(conn, SERVER, USER, PASSWORD, database, PORT,SOCKET, 0))
	{ /* definir los parámetros de la conexión antes establecidos */
		fprintf(stderr, "%s\n", mysql_error(conn)); /* si hay un error definir cual fue dicho error */
		exit(1);
	}

	/* enviar consulta SQL */
	if (mysql_query(conn, "describe producto_platillos")!=0)
	{ /* definicion de la consulta y el origen de la conexion */
		fprintf(stderr, "%s\n", mysql_error(conn));
		exit(1);
	}

	res = mysql_use_result(conn);
	//printf("ID\tNombre\t\tedad\n");
	while ((row = mysql_fetch_row(res)) != NULL) /* recorrer la variable res con todos los registros obtenidos para su uso */
		printf("%s\t%s\t%s \n", row[0],row[1],row[2]); /* la variable row se convierte en un arreglo por el numero de campos que hay en la tabla */

	/* se libera la variable res y se cierra la conexión */
	mysql_free_result(res);
	mysql_close(conn);
	return EXIT_SUCCESS;
}

