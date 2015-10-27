#include <stdio.h>
#include <stdlib.h>

char* last_digit_as_word(int number) {

    int digit = number % 10;

    switch (digit) {
        case 0: return "zero";
            break;
        case 1: return "one";
            break;
        case 2: return "two";
            break;
        case 3: return "three";
            break;
        case 4: return "four";
            break;
        case 5: return "five";
            break;
        case 6: return "six";
            break;
        case 7: return "seven";
            break;
        case 8: return "eight";
            break;
        case 9: return "nine";
            break;
        default: return "not a digit";
            break;
    }
}

int main(int argc, char** argv) {

    int number;
    printf("Input = ");
    scanf("%d", &number);

    printf("%s", last_digit_as_word(number));

    return (EXIT_SUCCESS);
}