#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    long int decimalNumber, remainder, quotient;
    int i = 1, j, temp;
    char hexadecimalNumber[100];

    printf("decimal = ");
    scanf("%ld", &decimalNumber);
    quotient = decimalNumber;

    while (quotient != 0) {
        temp = quotient % 16;
        if (temp < 10)
            temp = temp + 48;
        else
            temp = temp + 55;
        hexadecimalNumber[i++] = temp;
        quotient = quotient / 16;
    }

    printf("hexadecimal = ");
    for (j = i - 1; j > 0; j--) {
        printf("%c", hexadecimalNumber[j]);
    }

    return (EXIT_SUCCESS);
}