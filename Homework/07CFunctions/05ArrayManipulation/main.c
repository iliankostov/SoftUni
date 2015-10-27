#include <stdio.h>
#include <stdlib.h>
#include "array_functions.h"

int main(int argc, char** argv) {
    double array[] = {0, 1, 2, 3.5, 16.8, 4.2, 0.5, -10, 12, -5};
    int capacity = sizeof (array) / sizeof (double);

    printf("min = %.3lf\n", arr_min(array, capacity));
    printf("max = %.3lf\n", arr_max(array, capacity));
    printf("sum = %.3lf\n", arr_sum(array, capacity));
    printf("avg = %.3lf\n", arr_average(array, capacity));

    double search = 16.8;
    printf("contains %.3lf = %s\n", search, arr_contains(array, capacity, 16.8) ? "true" : "false");

    double mergeArr[] = {1, 2, 3};
    int mergeCapacity = sizeof (mergeArr) / sizeof (double);
    double *result = arr_merge(array, capacity, mergeArr, mergeCapacity);
    printf("merged: ");
    int j;
    for (j = 0; j < capacity + mergeCapacity; j++) {
        printf("%.3lf ", result[j]);
    }
    printf("\n");

    arr_clear(result, capacity + mergeCapacity);
    printf("clear:  ");
    int i;
    for (i = 0; i < capacity + mergeCapacity; i++) {
        printf("%.3lf ", result[i]);
    }

    return (EXIT_SUCCESS);
}