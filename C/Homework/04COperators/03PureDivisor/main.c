#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    printf("Result = %s", n != 0 && (n % 9 == 0 || n % 11 == 0 || n % 13 == 0) ? "1" : "0");

    return (EXIT_SUCCESS);
}