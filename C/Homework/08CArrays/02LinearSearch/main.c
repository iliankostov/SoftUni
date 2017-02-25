#include <stdio.h>
#include <stdlib.h>

int arr_contains(int array[], int capacity, int number) {
    int i;
    for (i = 0; i < capacity; i++) {
        if (array[i] == number) {
            return 1;
        }
    }

    return 0;
}

int main(int argc, char** argv) {

    int capacity, search, i;
    printf("Input:\n");
    scanf("%d", &capacity);
    int array[capacity];

    for (i = 0; i < capacity; i++) {
        if (i < capacity - 1) {
            scanf("%d ", &array[i]);
        } else {
            scanf("%d", &array[i]);
        }
    }

    scanf("%d", &search);

    printf("Output: %s", arr_contains(array, capacity, search) ? "yes" : "no");

    return (EXIT_SUCCESS);
}