#include <stdio.h>
#include <stdlib.h>

int *reversed_numbers(int *array, int length);
void print_array(int *array, int length);

int main() {
    int n;
    printf("Input:\n");
    if (scanf("%d", &n) != 1) {
        printf("Invalid input!");
        return 1;
    }

    int i;
    int numbers[n];
    for (i = 0; i < n; i++) {
        scanf("%d", &numbers[i]);
    }

    int *reversedNums = reversed_numbers(numbers, n);
    printf("Output:\n");
    print_array(reversedNums, n);
    free(reversedNums);

    return (EXIT_SUCCESS);
}

int *reversed_numbers(int *array, int length) {
    int *reversed = malloc(sizeof (int) * length);
    int i, r;
    for (i = 0, r = length - 1; i < length; i++, r--) {
        reversed[i] = array[r];
    }

    return reversed;
}

void print_array(int *array, int length) {
    int i;
    for (i = 0; i < length; i++) {
        printf("%d ", array[i]);
    }
}