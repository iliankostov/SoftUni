#include <stdio.h>
#include <stdlib.h>

void fill_arr(int *arr, int length);

int main() {
    int n;
    printf("Input:\n");
    if (scanf("%d", &n) != 1) {
        printf("Invalid input!");
        return 1;
    }

    int numbers[n];
    fill_arr(numbers, n);
    int i, r, start = 0, finish = 0;
    int bestEnd = 1, bestCount = 0;
    printf("\nOutput:\n");
    for (i = 1; i <= n; i++) {
        int count = 0;
        if (numbers[i] > numbers[i - 1]) {
            finish++;
        } else {
            for (r = start; r <= finish; r++) {
                printf("%d ", numbers[r]);
            }

            printf("\n");
            finish++;
            count = finish - start;
            start = finish;
        }

        if (i == n) {
            for (r = start; r < finish; r++) {
                printf("%d ", numbers[r]);
            }

            count = finish - start;
        }

        if (bestCount < count) {
            bestCount = count;
            bestEnd = finish;
        }
    }

    printf("\nLongest: ");
    for (i = bestEnd - bestCount; i < bestEnd; i++) {
        printf("%d ", numbers[i]);
    }

    printf("\n");

    return (EXIT_SUCCESS);
}

void fill_arr(int *arr, int length) {
    int i;
    for (i = 0; i < length; i++) {
        scanf("%d", &arr[i]);
    }
}