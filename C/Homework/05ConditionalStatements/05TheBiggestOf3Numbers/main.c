#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    double a, b, c, biggest;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("c = ");
    scanf("%lf", &c);


    if (a >= b && a >= c) {
        biggest = a;
    } else if (b >= a && b >= c) {
        biggest = b;
    } else if (c >= a && c >= b) {
        biggest = c;
    }

    printf("biggest = %.1lf", biggest);

    return (EXIT_SUCCESS);
}