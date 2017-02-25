#include <stdio.h>
#include <stdlib.h>

#define CARDS_LENGTH 13

int main(int argc, char** argv) {

    char cards[CARDS_LENGTH][3] = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    char suits[4] = {'C', 'D', 'H', 'S'};

    int row;
    for (row = 0; row < CARDS_LENGTH; row++) {
        int col;
        for (col = 0; col < sizeof (suits); col++) {
            printf("%s%c ", cards[row], suits[col]);
        }
        printf("\n");
    }

    return (EXIT_SUCCESS);
}