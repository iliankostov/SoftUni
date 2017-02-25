#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    int i;
    int result = 0;
    for (i = 0; i < 3; i++) {
        if (i == 2 && n % 10 == 7) {
            result = 1;
        }

        n /= 10;
    }

    printf("Third digit 7? %s", result == 0 ? "false" : "true");

    return (EXIT_SUCCESS);
}