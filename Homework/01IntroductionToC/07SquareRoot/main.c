#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv) {
    
    double number;
    scanf("%lf", &number);
    printf("Square root of %lf is %lf\n", number, sqrt(number));
   
    return (EXIT_SUCCESS);
}