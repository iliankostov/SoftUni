#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int n;
    printf("n = ");
    scanf("%d", &n);
    
    printf("Odd? %s", n % 2 == 0 ? "0" : "1");
    
    return (EXIT_SUCCESS);
}