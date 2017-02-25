#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int find_possition(char *str, int length, char ch) {

    int i;
    for (i = length; i >= 0; i--) {
        if (str[i] == ch) {
            return i;
        }
    }

    return -1;
}

int main(int argc, char** argv) {

    char *str, ch;
    size_t str_size = 0;
    printf("Arguments = ");
    getline(&str, &str_size, stdin);
    scanf("%c", &ch);

    int length = strlen(str);

    int index = find_possition(str, length, ch);

    printf("Return Value = %d", index);

    return (EXIT_SUCCESS);
}