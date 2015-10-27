#include <stdlib.h>
#include <float.h>
#include "array_functions.h"

double arr_min(double array[], int capacity) {

    double min = DBL_MAX;
    int i;
    for (i = 0; i < capacity; i++) {
        if (array[i] < min) {
            min = array[i];
        }
    }

    return min;
}

double arr_max(double array[], int capacity) {

    double max = DBL_MIN;
    int i;
    for (i = 0; i < capacity; i++) {
        if (array[i] > max) {
            max = array[i];
        }
    }

    return max;
}

void arr_clear(double array[], int capacity) {
    int i;
    for (i = 0; i < capacity; i++) {
        array[i] = 0;
    }
}

double arr_sum(double array[], int capacity) {

    double sum = 0;
    int i;
    for (i = 0; i < capacity; i++) {
        sum += array[i];
    }

    return sum;
}

double arr_average(double array[], int capacity) {

    double sum = 0;
    int i;
    for (i = 0; i < capacity; i++) {
        sum += array[i];
    }

    return sum / capacity;
}

int arr_contains(double array[], int capacity, double number) {
    int i;
    for (i = 0; i < capacity; i++) {
        if (array[i] == number) {
            return 1;
        }
    }

    return 0;
}

double* arr_merge(double arrayOne[], int capacityOne, double arrayTwo[], int capacityTwo) {

    int newCapacity = capacityOne + capacityTwo;
    double *result = malloc(newCapacity * sizeof (double));
    if (!result) {
        return 0;
    }

    int i;
    for (i = 0; i < newCapacity; i++) {
        if (i < capacityOne) {
            result[i] = arrayOne[i];
        } else {
            result[i] = arrayTwo[i - capacityOne];
        }
    }

    return result;
}
