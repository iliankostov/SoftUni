#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    char input[3], cards[13][3] = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    int isFound = 0;
    printf("character = ");
    scanf("%s", input);

    int i;
    for (i = 0; i < 13; i++) {
        if (cards[i][0] == input[0] && cards[i][1] == input[1]) {
            printf("yes");
            isFound = 1;
            break;
        }
    }

    if (!isFound) {
        printf("no");
    }

    return (EXIT_SUCCESS);
}