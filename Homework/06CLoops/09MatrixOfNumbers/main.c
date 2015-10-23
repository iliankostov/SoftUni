#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n, row, col;
    printf("n = ");
    scanf("%d", &n);

    for (row = 1; row <= n; row++) {
        for (col = row; col < n + row; col++) {
            printf("%d ", col);
        }
        printf("\n");
    }

    return (EXIT_SUCCESS);
}