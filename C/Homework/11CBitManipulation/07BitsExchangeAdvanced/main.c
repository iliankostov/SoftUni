#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    unsigned int n;
    int p, q, k;

    printf("n = ");
    scanf("%u", &n);
    printf("p = ");
    scanf("%d", &p);
    printf("q = ");
    scanf("%d", &q);
    printf("k = ");
    scanf("%d", &k);

    printf("result = ");

    if (p + k > 32 || q + k > 32) {
        printf("out of range");
    } else if (k > 8 && p + k > q) {
        printf("overlaping");
    } else {
        if (p > q) {
            q ^= p;
            p ^= q;
            q ^= p;
        }

        int i;
        for (i = 0; i < k; i++) {
            unsigned int maskP = 1 << p + i;
            unsigned int valuesP = (n & maskP) >> (p + i);
            unsigned int maskQ = 1 << q + i;
            unsigned int valuesQ = (n & maskQ) >> (q + i);

            if (valuesP == 1) {
                n = n | maskQ;
            } else if (valuesP == 0) {
                n = n & ~maskQ;
            }

            if (valuesQ == 1) {
                n = n | maskP;
            } else if (valuesQ == 0) {
                n = n & ~maskP;
            }
        }

        printf("%u", n);
    }

    return (EXIT_SUCCESS);
}