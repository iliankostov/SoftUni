#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    printf("Result = %s", n > 20 && n % 2 == 1 ? "1" : "0");

    return (EXIT_SUCCESS);
}