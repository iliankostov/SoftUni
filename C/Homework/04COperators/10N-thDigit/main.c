#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv) {

    char result = '-';
    int number, n, i;
    printf("Number = ");
    scanf("%d", &number);
    printf("n = ");
    scanf("%d", &n);

    int length = floor(log10(abs(number))) + 1;

    for (i = 1; i <= length; i++) {
        if (i == n) {
            result = abs(number % 10) + 48;
            break;
        }
        number /= 10;
    }

    printf("Result %c", result);

    return (EXIT_SUCCESS);
}