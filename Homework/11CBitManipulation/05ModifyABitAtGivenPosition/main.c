#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, p, v;
    printf("n = ");
    scanf("%d", &n);
    printf("p = ");
    scanf("%d", &p);
    printf("v = ");
    scanf("%d", &v);

    int mask = 1 << p, result;
    if (v == 1) {
        result = n | mask;
    } else if (v == 0) {
        result = n & ~mask;
    } else {
        printf("incorrect v");
        return (EXIT_FAILURE);
    }

    printf("result = %d", result);

    return (EXIT_SUCCESS);
}