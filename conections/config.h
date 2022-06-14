#ifndef CONFIG_H
#define CONFIG_H 

#include "conn.h"
#include "utilities/errors.h"
#include "utilities/cadena_funciones.h"


#ifndef SERVER
#define SERVER "localhost"
#endif

#ifndef USER
#define USER "root"
#endif

#ifndef PASSWORD
#define PASSWORD "angel790347"
#endif	

#ifndef PORT
#define PORT 0
#endif

#ifndef SOCKET
#define SOCKET "/tmp/mysql.sock"
#endif

#endif