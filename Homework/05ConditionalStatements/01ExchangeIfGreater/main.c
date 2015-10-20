#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    double a, b, temp;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    
    if (a > b) {
        temp = a;
        a = b;
        b = temp;
    }
    
    printf("%.2lf %.2lf", a, b);

    return (EXIT_SUCCESS);
}