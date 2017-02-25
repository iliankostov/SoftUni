#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, x, i;
    double nominator = 1, denominator = 1, sum = 1;
    printf("n = ");
    scanf("%d", &n);
    printf("x = ");
    scanf("%d", &x);

    for (i = 1; i <= n; i++) {
        nominator *= i;
        denominator *= x;
        sum += nominator / denominator;
    }

    printf("%.5f", sum);

    return (EXIT_SUCCESS);
}