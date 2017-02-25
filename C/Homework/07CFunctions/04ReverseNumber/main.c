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

    char *input;
    size_t str_size = 0;
    printf("Input = ");
    getline(&input, &str_size, stdin);
    int length = strlen(input);
    char result[length];

    reverse(input, result, length + 1, 0, length - 1);

    double d;
    sscanf(result, "%lf", &d) != 0 ? printf("%.3lf", d) : printf("Invalid input");

    return (EXIT_SUCCESS);
}