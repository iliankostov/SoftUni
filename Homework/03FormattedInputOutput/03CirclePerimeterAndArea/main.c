#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv) {

    double r;
    scanf("%lf", &r);

    double perimeter = 2 * M_PI * r;
    double area = M_PI * r * r;

    printf("perimeter: %.2f\n", perimeter);
    printf("area: %.2f\n", area);

    return (EXIT_SUCCESS);
}