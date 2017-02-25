#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    int i;
    for (i = 1; i <= n; i++) {
        printf("%d ", i);
    }

    return (EXIT_SUCCESS);
}