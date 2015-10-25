#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    long int dec, remainder, quotient;
    int binaryNumber[100], i = 1, j;

    printf("decimal = ");
    scanf("%lu", &dec);
    quotient = dec;

    while (quotient != 0) {
        binaryNumber[i++] = quotient % 2;
        quotient = quotient / 2;
    }

    printf("binary = ");
    for (j = i - 1; j > 0; j--) {
        printf("%d", binaryNumber[j]);
    }

    return (EXIT_SUCCESS);
}