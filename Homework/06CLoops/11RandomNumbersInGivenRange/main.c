#include<stdio.h>
#include<stdlib.h>
#include<time.h>

void swap_int(int* a, int* b) {
    int tmp = *a;
    *a = *b;
    *b = tmp;
}

inline int rand_int_hi_lo(int upper, int lower) {
    return ((rand() % (upper - lower + 1)) + lower);
}

int rand_int(int a, int b) {
    if (b > a) swap_int(&a, &b);
    return rand_int_hi_lo(a, b);
}

int main(int argc, char** argv) {
    int n, min, max;
    srand(time(0));
    printf("n = ");
    scanf("%d", &n);
    printf("min = ");
    scanf("%d", &min);
    printf("max = ");
    scanf("%d", &max);

    int i;
    for (i = 0; i < n; i++) {
        printf("%d ", rand_int(min, max));
    }

    return (EXIT_SUCCESS);
}