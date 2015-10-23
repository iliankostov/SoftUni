#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, k, i, j;
    double nominator = 1, denominator = 1;
    printf("n = ");
    scanf("%d", &n);
    printf("k = ");
    scanf("%d", &k);

    for (i = n; i > k; i--) {
        nominator *= i;
    }

    for (j = 2; j <= (n - k); j++) {
        denominator *= j;
    }

    printf("%.0f", nominator / denominator);

    return (EXIT_SUCCESS);
}