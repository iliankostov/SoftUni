#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    double a, b, c, d, e;
    scanf("%lf %lf %lf %lf %lf", &a, &b, &c, &d, &e);

    double sum = a + b + c + d + e;

    printf("%.2lf", sum);

    return (EXIT_SUCCESS);
}