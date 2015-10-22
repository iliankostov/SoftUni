#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int input, number = 2;
    scanf("%d", &input);

    while (input != 0) {

        if (number % 2 == 0) {
            printf("%d ", number);
        } else {
            printf("%d ", number * -1);
        }

        number++;
        input--;
    }

    return (EXIT_SUCCESS);
}