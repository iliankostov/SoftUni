#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, p;
    printf("n = ");
    scanf("%d", &n);
    printf("p = ");
    scanf("%d", &p);

    int mask = 1 << p;
    int result = n & mask;

    printf("bit @ p = %s", result == mask ? "1" : "0");

    return (EXIT_SUCCESS);
}