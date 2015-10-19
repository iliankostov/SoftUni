#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    int number;
    scanf("%d", &number);
    
    int i;
    for (i = 1; i <= number; i++) {
        printf("%d\n", i);
    }

    return (EXIT_SUCCESS);
}