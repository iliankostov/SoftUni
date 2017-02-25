#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    unsigned int n;
    printf("n = ");
    scanf("%u", &n);

    unsigned int mask = 1 << 3;
    unsigned int result = n & mask;

    printf("Result = %s", result == mask ? "1" : "0");

    return (EXIT_SUCCESS);
}