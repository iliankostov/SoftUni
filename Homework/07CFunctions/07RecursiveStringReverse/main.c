#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void reverse(char *str, char *result, int length, int n, int m) {

    if (n == length - 1) {
        result[n] = '\0';
        return;
    }

    char ch = str[n];
    result[m] = ch;

    reverse(str, result, length, ++n, --m);
}

int main(int argc, char** argv) {

    char str[32];

    printf("Input = ");
    scanf("%s", str);

    int length = strlen(str);
    char result[length + 1];

    reverse(str, result, length + 1, 0, length - 1);

    printf("%s", result);

    return (EXIT_SUCCESS);
}