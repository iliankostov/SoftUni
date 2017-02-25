
#include <stdio.h>
#include <stdlib.h>

void fill_matrix(int rows, int cols, int matrix[][cols]);

int main() {
    int rows, cols;
    printf("Input:\n");
    if (scanf("%d %d", &rows, &cols) != 2) {
        printf("Invalid input!");
        return 1;
    }

    int firstMatrix[rows][cols];
    int secondMatrix[rows][cols];
    int resultMatrix[rows][cols];

    fill_matrix(rows, cols, firstMatrix);
    fill_matrix(rows, cols, secondMatrix);

    printf("Output:\n");
    int i, j;
    for (i = 0; i < rows; i++) {
        for (j = 0; j < cols; j++) {
            resultMatrix[i][j] = firstMatrix[i][j] + secondMatrix[i][j];
            printf("%-3d", resultMatrix[i][j]);
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