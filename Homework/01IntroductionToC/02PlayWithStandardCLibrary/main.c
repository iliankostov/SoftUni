#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    printf("Type something up to 10 symbols: ");
    char greeting[10];
    scanf("%9s", greeting);
    printf("You typed %s!", greeting);
    
    return (EXIT_SUCCESS);
}