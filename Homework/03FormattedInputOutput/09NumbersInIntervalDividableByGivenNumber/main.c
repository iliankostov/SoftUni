#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    int start, end;
    printf("start = ");
    scanf("%d", &start);
    printf("end = ");
    scanf("%d", &end);
    
    int i;
    int count = 0;
    for (i = start; i <= end; i++) {
        if (i % 5 == 0) {
            count++;
        }
    }

    printf("p = %d", count);

    return (EXIT_SUCCESS);
}