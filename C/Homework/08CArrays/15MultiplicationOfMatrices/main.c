#include <stdio.h>
#include <stdlib.h>

void fill_matrix(int rows, int cols, int matrix[][cols]);
int cell_product(int rows, int cols,
        int firstMatrix[][cols], int secondMatrix[][rows]);

int main() {
    int rows, cols;
    printf("Input:\n");
    if (scanf("%d %d", &rows, &cols) != 2) {
        printf("Invalid input!");
        return 1;
    }

    int firstMatrix[rows][cols];
    int secondMatrix[cols][rows];
    int resultMatrix[rows][rows];

    fill_matrix(rows, cols, firstMatrix);
    fill_matrix(cols, rows, secondMatrix);

    printf("Output:\n");
    int i, j, r;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < rows; j++) {
            resultMatrix[i][j] = 0;
            for (r = 0; r < cols; r++) {
                resultMatrix[i][j] += firstMatrix[i][r] * secondMatrix[r][j];
            }
            ;
            printf("%-5d", resultMatrix[i][j]);
        }
        printf("\n");
    }

    return (EXIT_SUCCESS);
}

void fill_matrix(int rows, int cols, int matrix[][cols]) {
    int i, j;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            scanf("%d", &matrix[i][j]);
        }
    }
}