#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    double a, b, c;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("c = ");
    scanf("%lf", &c);
    
    char result[1];
    
    if (a == 0 || b == 0 || c == 0) {
        result[0] = '0';
    }
    else if (
                (a < 0 && b > 0 && c > 0) || 
                (a > 0 && b < 0 && c > 0) || 
                (a > 0 && b > 0 && c < 0) || 
                (a < 0 && b < 0 && c < 0)
            ) {
        result[0] = '-';
    }
    else if (
                (a < 0 && b < 0 && c > 0) || 
                (a < 0 && b > 0 && c < 0) || 
                (a > 0 && b < 0 && c < 0) ||
                (a > 0 && b > 0 && c > 0)
            ) {
        result[0] = '+';
    }
    
    printf("result: %c", result[0]);
    
    return (EXIT_SUCCESS);
}