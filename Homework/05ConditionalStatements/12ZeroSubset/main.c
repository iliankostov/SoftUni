#include <stdio.h>
#include <string.h>
#include <math.h>

#define BUFFER_SIZE 30

int main() {
    char input[BUFFER_SIZE];
    fgets(input, BUFFER_SIZE, stdin);
    int numbers[5];
    int index = 0;
    int combinations = (int) pow(2, 5);
    char subsets[] = {'*', '*', '*', '*', '*'};
    int isFound = 0;
    char* token = strtok(input, " ");
    while (token != NULL) {
        int num = atoi(token);
        numbers[index] = num;
        index++;
        token = strtok(NULL, " ");
    }

    int i, j, k;

    for (i = 0; i < combinations; i++) {
        int subsetSum = 0;
        index = 0;
        int count = 0;
        for (j = 0; j < 5; j++) {
            if ((i & (1 << j)) != 0) {
                subsets[index] = numbers[j];
                subsetSum += subsets[index];
                count++;
                index++;
            }
        }

        if (subsetSum == 0 && count != 0) {
            isFound = 1;
            for (k = 0; k < count; k++) {
                if (subsets[k] != '*') {
                    if (k != count - 1) {
                        printf("%d + ", subsets[k]);
                    } else {
                        printf("%d ", subsets[k]);
                    }
                }
            }

            printf("= 0\n");
        }

        memset(subsets, '*', 5);
    }

    if (!isFound) {
        printf("no zero subset");
    }

    return 0;
}
