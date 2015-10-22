#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(int argc, char** argv) {

    time_t rawtime;
    struct tm *info;
    char str[80];

    time(&rawtime);
    info = localtime(&rawtime);

    strftime(str, 80, "%d %B %Y %H:%M:%S", info);
    printf("%s", str);

    return (EXIT_SUCCESS);
}