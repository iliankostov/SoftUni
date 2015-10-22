#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    double weight;
    printf("weight = ");
    scanf("%lf", &weight);

    printf("weight on the Moon = %.3lf", weight * 17 / 100);

    return (EXIT_SUCCESS);
}