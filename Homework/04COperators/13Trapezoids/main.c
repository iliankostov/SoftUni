#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    double a, b, h, area;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("h = ");
    scanf("%lf", &h);
    
    area = (h * a) + (h * (b - a) / 2);
    
    printf("%.2lf", area);

    return (EXIT_SUCCESS);
}