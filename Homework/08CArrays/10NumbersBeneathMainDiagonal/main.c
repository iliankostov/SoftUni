#include <stdio.h>
#include <stdlib.h>

void fill_matrix(int rows, int cols, int matrix[][cols]);

int main() {
    int n;
    printf("Input:\n");
    if (scanf("%d", &n) != 1) {
        printf("Invalid input!");
        return 1;
    }
    int matrix[n][n];
    fill_matrix(n, n, matrix);
    int i, r;
    printf("Output:\n");
    for (i = 0; i < n; i++) {
        for (r = 0; r <= i; r++) {
            printf("%-3d", matrix[i][r]);
        }

        printf("\n");
    }

    return (EXIT_SUCCESS);
}

void fill_matrix(int rows, int cols, int matrix[][cols]) {
    int i, r;
    for (i = 0; i < rows; i++) {
        for (r = 0; r < cols; r++) {
            scanf("%d", &matrix[i][r]);
        }
    }
}