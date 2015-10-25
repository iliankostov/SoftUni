#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    char bin;
    long dec = 0;

    printf("binary = ");
    while (bin != '\n') {
        scanf("%c", &bin);
        if (bin == '1') {
            dec = dec * 2 + 1;
        } else if (bin == '0') {
            dec *= 2;
        }
    }

    printf("decimal = %lu", dec);

    return (EXIT_SUCCESS);
}