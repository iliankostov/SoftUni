#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, k, i;
    double nominator = 1, denominator = 1;
    printf("n = ");
    scanf("%d", &n);
    printf("k = ");
    scanf("%d", &k);

    for (i = 1; i <= n; i++) {

        nominator *= i;

        if (i <= k) {
            denominator *= i;
        }
    }

    printf("%.0f", nominator / denominator);

    return (EXIT_SUCCESS);
}