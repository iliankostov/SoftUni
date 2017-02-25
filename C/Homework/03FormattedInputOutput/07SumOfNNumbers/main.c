#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    int count;
    scanf("%d", &count);

    double sum = 0;
    int i;
    for (i = 0; i < count; i++) {
        double temp;
        scanf("%lf", &temp);
        sum += temp;
    }

    printf("%.1lf", sum);

    return (EXIT_SUCCESS);
}