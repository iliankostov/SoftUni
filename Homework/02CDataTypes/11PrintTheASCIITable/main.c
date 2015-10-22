#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int i;
    for (i = 0; i <= 255; i++) {
        printf("Number: %d -> ASCII character: %c\n", i, i);
    }

    return (EXIT_SUCCESS);
}