#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    printf("%s", isPrime(n) ? "true" : "false");

    return (EXIT_SUCCESS);
}

int isPrime(int n) {
    if (n < 2) {
        return 0;
    }

    int i;
    for (i = 2; i < n; i++) {
        if (n % i == 0) {
            return 0;
        }
    }
    return 1;
}