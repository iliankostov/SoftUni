#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    double a, b, c;
    scanf("%lf %lf %lf", &a, &b, &c);
    double sum = a + b + c;

    printf("%.2lf", sum);

    return (EXIT_SUCCESS);
}