#include <stdio.h>
#include <stdlib.h>

void filling_vector(int *array, int length);
void cross_product_vectors(int *resultArr, int *firstArr, int *secondArr);

int main() {
    int firstVector[3], secondVector[3], resultVector[3];
    printf("Input:\n");
    filling_vector(firstVector, 3);
    filling_vector(secondVector, 3);
    cross_product_vectors(resultVector, firstVector, secondVector);
    printf("Output:\n[%d, %d, %d]",
            resultVector[0], resultVector[1], resultVector[2]);

    return (EXIT_SUCCESS);
}

void filling_vector(int *array, int length) {
    int i;
    for (i = 0; i < length; i++) {
        scanf("%d", &array[i]);
    }
}

void cross_product_vectors(int *resultArr, int *firstArr, int *secondArr) {
    resultArr[0] = (firstArr[1] * secondArr[2]) -
            (firstArr[2] * secondArr[1]);
    resultArr[1] = (firstArr[2] * secondArr[0]) -
            (firstArr[0] * secondArr[2]);
    resultArr[2] = (firstArr[0] * secondArr[1]) -
            (firstArr[1] * secondArr[0]);
}