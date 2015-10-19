#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    double numberA;
    double numberB;
    double esp = 0.000001;
    
    printf("a = ");
    scanf("%lf", &numberA);
    printf("b = ");
    scanf("%lf", &numberB);
    
    if (numberA > numberB) {
        if ((numberA - numberB) > esp) {
            printf("false");
        }
        else {
            printf("true");
        }
    }
    else {
        if ((numberB - numberA) > esp) {
            printf("false");
        }
        else {
            printf("true");
        }
    }
    
    return (EXIT_SUCCESS);
}