#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    unsigned int n;
    printf("n = ");
    scanf("%u", &n);

    unsigned int maskFirstEight = 7 << 3;
    unsigned int maskLastEight = 7 << 24;

    maskFirstEight &= n;
    n &= ~maskFirstEight;
    maskFirstEight <<= 21;

    maskLastEight &= n;
    n &= ~maskLastEight;
    maskLastEight >>= 21;

    n += maskFirstEight;
    n += maskLastEight;

    printf("result = %u", n);

    return (EXIT_SUCCESS);
}