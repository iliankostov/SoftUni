#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int input;
    scanf("%d", &input);
    int number;
    for (number = 2; number < input; number++) {
        if (number % 2 == 0) {
            if (number == input - 1) {
                printf("%d", number);
                break;
            }
            printf("%d, ", number);
        }
        else{
            if (number == input - 1) {
                printf("%d", number * -1);
                break;
            }
            printf("%d, ", number * -1);
        }
    }

    return (EXIT_SUCCESS);
}