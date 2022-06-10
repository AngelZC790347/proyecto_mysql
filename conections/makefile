CC = clang
CFLAGS = -Wall -ansi -pedantic
B_DIR = "build/"
cnn : conn.o 
	$(CC) -o $(B_DIR)cnn conn.o `mysql_config --libs`
conn.o: conn.c $(mysql_config -–libs) config.h
	$(CC)  -c `mysql_config --cflags` conn.c 
clean:
	rm*.o conn
	$(B_DIR)cnn