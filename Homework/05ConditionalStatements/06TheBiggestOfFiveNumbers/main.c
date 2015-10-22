#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    double a, b, c, d, e, biggest;
    printf("a = ");
    scanf("%lf", &a);
    printf("b = ");
    scanf("%lf", &b);
    printf("c = ");
    scanf("%lf", &c);
    printf("d = ");
    scanf("%lf", &d);
    printf("e = ");
    scanf("%lf", &e);
    
    if (a >= b && a >= c && a >= d && a >= e) {
        biggest = a;
    }
    else if (b >= a && b >= c && b >= d && b >= e) {
        biggest = b;
    }
    else if (c >= a && c >= b && c >= d && c >= e) {
        biggest = c;
    }
    else if (d >= a && d >= b && d >= c && d >= e) {
        biggest = d;
    }
    else if (e >= a && e >= b && e >= c && e >= d) {
        biggest = e;
    }
    
    printf("biggest = %.1lf", biggest);

    return (EXIT_SUCCESS);
}