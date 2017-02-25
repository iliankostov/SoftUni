#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <errno.h>

#define BUFFER_SIZE 64

ssize_t get_line(char **, size_t *, FILE *);

int main(int argc, char** argv) {
    
    int base;
    scanf("%d", &base);
    getchar();
    
    size_t buffer;
    char *message = NULL;
    
    int lenght = get_line(&message, &buffer, stdin);
    
    size_t i;
    int sum = 0;
    for (i = 0; i < lenght; i++) {
        
        char currentChar = message[i];
        if (isalpha(currentChar)) {
            sum += tolower(currentChar) - 'a' + 1;
        } else {
            sum += currentChar;
        }
    }
    
    char digits[32];
    size_t index = 0;
    while (sum > 0) {
        int digit = sum % base;
        digits[index] = '0' + digit;
        index++;
        sum /= base;
    }

    printf("%d%d", base, lenght);
    int j;
    for (j = index - 1; j >= 0; j--) {
        printf("%c", digits[j]);
    }

    return (EXIT_SUCCESS);
}

ssize_t get_line(char **lineptr, size_t *buf_size, FILE *stream) {
    /* Sanity checks. */
    if (lineptr == NULL || buf_size == NULL || stream == NULL)
        return -1;

    /* Allocate the line the first time. */
    if (*lineptr == NULL) {
        errno = 0;
        *lineptr = (char *) malloc(BUFFER_SIZE);
        if (NULL == *lineptr) {
            return -1;
        }
        *buf_size = BUFFER_SIZE;
    }

    size_t i = 0;
    char ch;
    while ((ch = getc(stream)) != '\n' && ch != EOF) {
        if (i == (*buf_size - 1)) {
            errno = 0;
            char *newLine = (char *) realloc(*lineptr, *buf_size + BUFFER_SIZE);
            if (NULL == newLine) {
                if (*lineptr)
                    free(*lineptr);

                return -1;
            }

            *lineptr = newLine;
            *buf_size += BUFFER_SIZE;
        }

        (*lineptr)[i++] = ch;
    }

    (*lineptr)[i] = '\0';

    return (ssize_t) (i);
}