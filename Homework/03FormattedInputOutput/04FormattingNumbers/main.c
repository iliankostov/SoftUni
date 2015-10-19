#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    int a;
    char bin[] = "0000000000";
    double b;
    double c;   
    scanf("%d %lf %lf", &a, &b, &c);
    
    int n = a;
    int i = 9;    
    while (n > 0) {
        int bit = n % 2;
        n = n / 2;
        bin[i] = bit == 1 ? '1' : '0';
        i--;
    }
    
    printf("|%-10x|%s|%10.2lf|%-10.3lf|" , a, bin, b, c);

    return (EXIT_SUCCESS);
}