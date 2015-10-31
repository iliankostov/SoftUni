#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int count;
    printf("Input:\n");
    scanf("%d", &count);
    int array[count];

    int i;
    for (i = 0; i < count; i++) {
        if (i < count - 1) {
            scanf("%d ", &array[i]);
        } else {
            scanf("%d", &array[i]);
        }

        if (i == 0) {
            printf("Output:\n");
        }

        printf("%d ", array[i]);
    }

    return (EXIT_SUCCESS);
}