#include <stdio.h>
#include <stdlib.h>

int get_max(int a, int b) {
    return a >= b ? a : b;
}

int main(int argc, char** argv) {

    int a, b;
    printf("Input = ");
    scanf("%d %d", &a, &b);

    printf("Output = %d", get_max(a, b));

    return (EXIT_SUCCESS);
}