#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    
    int n;
    scanf("%d", &n);
        
    int i;
    for (i = 0; i < n; i++) {
        printf("%d ", Fibonacci(i));
    }

    return (EXIT_SUCCESS);
}

int Fibonacci(int i)
{
   if ( i == 0 )
      return 0;
   else if ( i == 1 )
      return 1;
   else
      return ( Fibonacci(i-1) + Fibonacci(i-2) );
} 