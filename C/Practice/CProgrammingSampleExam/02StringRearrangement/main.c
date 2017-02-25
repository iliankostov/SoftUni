#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

#define BUFFER_SIZE 64

ssize_t get_line(char **, size_t *, FILE *);
int str_split(char** [], char*, const char*);
void str_arr_free(char**, int);

int main(int argc, char** argv) {

    ssize_t length = 0;
    size_t buffer = 0;
    char *line = NULL;

    length = get_line(&line, &buffer, stdin);

    char **elements = NULL;
    int elements_count = str_split(&elements, line, "|");

    char *result = (char*) calloc(length, sizeof (char));
    size_t j = 0;

    size_t i;
    for (i = 0; i < elements_count; i++) {
        char *block = *(elements + i);
        char *openingBrackets = strchr(block, '{');
        if (openingBrackets) {
            char *closingBracket = strchr(openingBrackets + 1, '}');
            if (closingBracket) {
                size_t concatSize = closingBracket - openingBrackets - 1;
                strncat(result, openingBrackets + 1, concatSize);
                j += concatSize;
            }
        }
    }
    
    length = get_line(&line, &buffer, stdin);
    while (strcmp(line, "end") != 0) {
        
        long posA, posB, copySize;
        sscanf(line, "swap %ld %ld %ld", &posA, &posB, &copySize);
        
        if (posA >= 0 && posA < j &&
            posB >= 0 && posB < j &&
            copySize >= 0 && 
            (copySize + posA < j && copySize + posB < j)) {
            //swap
            char tempBuffer[copySize];
            strncpy(tempBuffer, result + posB, copySize);
            strncpy(result + posB, result + posA, copySize);
            strncpy(result + posA, tempBuffer, copySize);
        } else {
            printf("\nInvalid command parameters");
        }
        
        length = get_line(&line, &buffer, stdin);
    }
    
    printf("\n%s", result);
    
    str_arr_free(elements, elements_count);
    free(line);
    free(result);
    
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

int str_split(char** dest[], char* raw_str, const char* delimiters) {
    int split_arr_len = 0;
    int dest_current_len = 10;
    *dest = (char**) malloc(dest_current_len * sizeof (char*));
    if (*dest == NULL) exit(1);

    char* current_split = strtok(raw_str, delimiters);
    while (current_split != NULL) {
        int current_split_len = strlen(current_split) * sizeof (char);

        // malloc space for the current_split in the dest array :
        (*dest)[split_arr_len] = (char*) malloc(current_split_len + 1);
        if ((*dest)[split_arr_len] == NULL) exit(1);

        // copy the current split into the dest at split_arr_len :
        strcpy((*dest)[split_arr_len], current_split);
        // put a terminating char at the end of the string :
        (*dest)[split_arr_len][current_split_len] = '\0';

        current_split = strtok(NULL, delimiters);
        split_arr_len++;

        // if the dest buffer overflows resize it :
        if (split_arr_len >= dest_current_len) {
            dest_current_len *= 2;
            *dest = (char**) realloc(*dest, dest_current_len * sizeof (char*));
            if (*dest == NULL) exit(1);
        }
    }

    return split_arr_len;

}

void str_arr_free(char** str_arr, int len) {
    int i;
    for (i = 0; i < len; ++i) {
        free(str_arr[i]);
    }

    free(str_arr);
}