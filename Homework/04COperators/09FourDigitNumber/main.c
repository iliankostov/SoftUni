#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    char n[4];
    int ints[4], i, sum = 0;
    printf("n = ");
    scanf("%s", n);
 
    for(i = 0; i < 4; i++){
        sum += n[i] - '0';
    }
    
    printf("sum of digits = %d\n", sum);
    printf("reversed = %c%c%c%c\n", n[3], n[2], n[1], n[0]);
    printf("last digit in front = %c%c%c%c\n", n[3], n[0], n[1], n[2]);
    printf("second and third digits exchanged = %c%c%c%c\n", n[0], n[2], n[1], n[3]);
    
    return (EXIT_SUCCESS);
}