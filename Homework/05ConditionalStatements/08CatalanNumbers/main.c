#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, i, j;
    double nominator = 1, denominator = 1;
    printf("n = ");
    scanf("%d", &n);

    for (i = 2 * n; i > n + 1; i--) {
        nominator *= i;
    }

    for (j = 2; j <= n; j++) {
        denominator *= j;
    }

    printf("%.0f", nominator / denominator);

    return (EXIT_SUCCESS);
}