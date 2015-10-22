#include <stdio.h>
#include <stdlib.h>

#define FORMAT "%.1lf "

int main(int argc, char** argv) {
    
    double a, b, c;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("c = ");
    scanf("%lf", &c);
    
    if (a >= b && a >= c) {
        printf(FORMAT, a);
        if (b >= c) {
            printf(FORMAT, b);
            printf(FORMAT, c);
        }
        else {
            printf(FORMAT, c);
            printf(FORMAT, b);
        }
    } else if (b >= a && b >= c) {
        printf(FORMAT, b);
        if (a >= c) {
            printf(FORMAT, a);
            printf(FORMAT, c);
        }
        else {
            printf(FORMAT, c);
            printf(FORMAT, a);
        }
    } else if (c >= a && c >= b) {
        printf(FORMAT, c);
        if (a >= b) {
            printf(FORMAT, a);
            printf(FORMAT, b);
        }
        else {
            printf(FORMAT, b);
            printf(FORMAT, a);
        }
    }

    return (EXIT_SUCCESS);
}