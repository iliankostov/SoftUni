#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    int mask = 1 << 1;
    int result = n & mask;

    printf("Result = %s", result == mask ? "1" : "0");

    return (EXIT_SUCCESS);
}