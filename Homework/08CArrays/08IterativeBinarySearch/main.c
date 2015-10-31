#include <stdio.h>
#include <stdlib.h>

void bubble_sort(int *array, int length);
int binary_search(int *array, int length, int searchedNum);

int main() {
    int n;
    printf("Input:\n");
    if (scanf("%d", &n) != 1) {
        printf("Invalid input!");
        return 1;
    }

    int i, numbers[n];
    for (i = 0; i < n; i++) {
        scanf("%d", &numbers[i]);
    }

    int searchedNum;
    if (scanf("%d", &searchedNum) != 1) {
        printf("Invalid input!");
        return 1;
    }

    bubble_sort(numbers, n);
    int index = binary_search(numbers, n, searchedNum);
    printf("Output: %d", index);

    return (EXIT_SUCCESS);
}

void bubble_sort(int *array, int length) {
    int hasSwapped = 1;
    while (hasSwapped) {
        hasSwapped = 0;
        int i;
        for (i = 0; i < length - 1; i++) {
            if (array[i] > array[i + 1]) {
                int oldValue = array[i];
                array[i] = array[i + 1];
                array[i + 1] = oldValue;
                hasSwapped = 1;
            }
        }
    }
}

int binary_search(int *array, int length, int searchedNum) {
    int index = -1;
    int first = 0;
    int last = length;
    int middle = (first + last) / 2;
    while (first < last) {
        if (array[middle] == searchedNum) {
            index = middle;
            return index;
        } else if (array[middle] < searchedNum) {
            first = middle + 1;
        } else {
            last = middle - 1;
        }

        middle = (first + last) / 2;
    }

    return index;
}