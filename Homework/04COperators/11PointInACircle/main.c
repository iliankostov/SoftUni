#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv) {

    double x, y, r = 2, pathToCenter;
    printf("x = ");
    scanf("%lf", &x);
    printf("y = ");
    scanf("%lf", &y);

    pathToCenter = sqrt(pow(x, 2) + pow(y, 2));

    if (pathToCenter == 0) {
        printf("inside Yes");
    } else if (pathToCenter > 0) {
        printf("inside %s", pathToCenter <= r ? "Yes" : "No");
    } else if (pathToCenter < 0) {
        printf("inside %s", pathToCenter >= r ? "Yes" : "No");
    }

    return (EXIT_SUCCESS);
}