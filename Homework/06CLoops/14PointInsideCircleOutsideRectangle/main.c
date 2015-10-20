#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv) {
    
    double x, y, r = 1.5, pathToCenter;
    printf("x = ");
    scanf("%lf", &x);
    printf("y = ");
    scanf("%lf", &y);   
    
    if(y > 1){
        pathToCenter = sqrt(pow(x - 1, 2) + pow(y - 1, 2));
        if (pathToCenter <= r) {
            printf("yes");
        }
        else{
            printf("no");
        }
    }
    else {
        printf("no");
    }

    return (EXIT_SUCCESS);
}