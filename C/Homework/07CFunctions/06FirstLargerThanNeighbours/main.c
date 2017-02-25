#include <stdio.h>
#include <stdlib.h>

int first_larger(int array[], int capacity) {
    int i;
    for (i = 0; i < capacity; i++) {
        if (i > 0 && i < capacity - 1) {
            if (array[i] > array[i - 1] && array[i] > array[i + 1]) {
                return i;
            }
        }
    }

    return -1;
}

int main(int argc, char** argv) {

    int sequenceOne[] = {1, 3, 4, 5, 1, 0, 5};
    int sequenceTwo[] = {1, 2, 3, 4, 5, 6, 6};
    int sequenceThree[] = {1, 1, 1};

    printf("Return Value One = %d\n", first_larger(sequenceOne, sizeof (sequenceOne) / sizeof (int)));
    printf("Return Value Two = %d\n", first_larger(sequenceTwo, sizeof (sequenceTwo) / sizeof (int)));
    printf("Return Value Three = %d", first_larger(sequenceThree, sizeof (sequenceThree) / sizeof (int)));

    return (EXIT_SUCCESS);
}