#include <stdio.h>
#include <stdlib.h>
#include <float.h>

double findMin(double array[], int capacity) {

    double min = DBL_MAX;
    int i;
    for (i = 0; i < capacity; i++) {
        if (array[i] < min) {
            min = array[i];
        }
    }

    return min;
}

double findMax(double array[], int capacity) {

    double max = DBL_MIN;
    int i;
    for (i = 0; i < capacity; i++) {
        if (array[i] > max) {
            max = array[i];
        }
    }

    return max;
}

double findSum(double array[], int capacity) {

    double sum = 0;
    int i;
    for (i = 0; i < capacity; i++) {
        sum += array[i];
    }

    return sum;
}

double findAvg(double array[], int capacity) {

    return findSum(array, capacity) / capacity;
}

int main(int argc, char** argv) {

    int capacity, i;
    printf("capacity = ");
    scanf("%d", &capacity);

    double array[capacity];
    for (i = 0; i < capacity; i++) {
        printf("number %d = ", i + 1);
        scanf("%lf", &array[i]);
    }

    printf("min = %.2lf\n", findMin(array, capacity));
    printf("max = %.2lf\n", findMax(array, capacity));
    printf("sum = %.2lf\n", findSum(array, capacity));
    printf("avg = %.2lf\n", findAvg(array, capacity));

    return (EXIT_SUCCESS);
}