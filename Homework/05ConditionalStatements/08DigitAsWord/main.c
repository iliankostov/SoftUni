#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    char input[2];
    int d;
    printf("d = ");
    scanf("%s", input);

    if (input[1] != '\0') {
        printf("not a digit");
    } else {
        d = input[0] - '0';
        switch (d) {
            case 0: printf("zero");
                break;
            case 1: printf("one");
                break;
            case 2: printf("two");
                break;
            case 3: printf("three");
                break;
            case 4: printf("four");
                break;
            case 5: printf("five");
                break;
            case 6: printf("six");
                break;
            case 7: printf("seven");
                break;
            case 8: printf("eight");
                break;
            case 9: printf("nine");
                break;
            default: printf("not a digit");
                break;
        }
    }

    return (EXIT_SUCCESS);
}