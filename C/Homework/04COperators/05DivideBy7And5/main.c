#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);

    printf("Divided by 7 and 5? %s", n != 0 && n % 7 == 0 && n % 5 == 0 ? "1" : "0");

    return (EXIT_SUCCESS);
}