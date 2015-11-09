#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, p;
    printf("n = ");
    scanf("%d", &n);
    printf("p = ");
    scanf("%d", &p);

    int mask = ~(1 << p);
    int result = n & mask;

    printf("Result = %d", result);

    return (EXIT_SUCCESS);
}