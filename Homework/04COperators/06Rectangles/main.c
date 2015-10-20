#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    double width, height;
    printf("width = ");
    scanf("%lf", &width);
    printf("height = ");
    scanf("%lf", &height);
    
    double perimeter = 2 * width + 2 * height;
    double area = width * height;
    
    printf("perimeter = %.1lf\narea = %.1lf", perimeter, area);
    
    return (EXIT_SUCCESS);
}