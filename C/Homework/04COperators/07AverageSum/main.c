#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    double a, b, c;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("c = ");
    scanf("%lf", &c);

    double average = (a + b + c) / 3;

    printf("Average = %.5lf", average);

    return (EXIT_SUCCESS);
}