#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int score;
    printf("score = ");
    scanf("%d", &score);
    
    if (score >= 1 && score <= 3) {
        printf("%d", score *= 10);
    }
    else if (score >= 4 && score <= 6) {
        printf("%d", score *= 100);
    }
    else if (score >= 7 && score <= 9) {
        printf("%d", score *= 1000);
    }
    else{
        printf("invalid score");
    }

    return (EXIT_SUCCESS);
}