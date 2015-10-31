#include <stdio.h>
#include <stdlib.h>

int cmpfunc(const void * a, const void * b) {
    return ( *(int*) a - *(int*) b);
}

int main(int argc, char** argv) {

    int capacity, i;
    printf("Input:\n");
    scanf("%d", &capacity);
    int array[capacity];

    for (i = 0; i < capacity; i++) {
        if (i < capacity - 1) {
            scanf("%d\n", &array[i]);
        } else {
            scanf("%d", &array[i]);
        }
    }

    qsort(array, capacity, sizeof (int), cmpfunc);

    printf("Output:\n");
    int j;
    for (j = 0; j < capacity; j++) {
        printf("%d ", array[j]);
    }

    return (EXIT_SUCCESS);
}