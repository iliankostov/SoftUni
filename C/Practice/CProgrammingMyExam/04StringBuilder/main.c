#include <stdio.h>
#include <stdlib.h>
#include <assert.h>
#include <ctype.h>
#include <string.h>
#include <stdbool.h>
#include <errno.h>

#define BUFFER_SIZE 64
#define STRING_BUILDER_H_ 1
#define SB_DEFAULT_LEN 10

typedef struct {
    size_t count; // logical length.
    size_t _len; // actual length of allocated memory.
    char* _str_p; // actual representation of the string.
} string_builder;

ssize_t get_line(char **, size_t *, FILE *);
int str_split(char** [], char*, const char*);
void str_arr_free(char**, int);

void sb_init(string_builder *);
void sb_concat(string_builder *, const char *);
char* sb_give_control_of_str(string_builder *);
static void sb_resize(string_builder *);
void sb_free(string_builder *);
void sb_clear(string_builder *);

int main(int argc, char** argv) {

    string_builder sb;
    sb_init(&sb);

    ssize_t length = 0;
    size_t buffer = 0;
    char *line = NULL;

    char **elements = NULL;
    int elements_count;

    length = get_line(&line, &buffer, stdin);

    while (strcmp(line, "over") != 0) {

        elements_count = str_split(&elements, line, "-");
        if (elements_count == 2) {

            if (strcmp(elements[0], "concat") == 0) {           
                sb_concat(&sb, elements[1]);
            }
        }
        
        char* str_content = sb_give_control_of_str(&sb);
	printf("%s", str_content);
        
        str_arr_free(elements, elements_count);
        free(str_content);
        length = get_line(&line, &buffer, stdin);
    }

    free(line);
    sb_free(&sb);
    sb_clear(&sb);

    return (EXIT_SUCCESS);
}

ssize_t get_line(char **lineptr, size_t *buf_size, FILE *stream) {
    if (lineptr == NULL || buf_size == NULL || stream == NULL)
        return -1;

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

void sb_init(string_builder* sb) {
    sb->_str_p = (char*) malloc(SB_DEFAULT_LEN);
    sb->_len = SB_DEFAULT_LEN;
    sb->count = 0;
}

void sb_concat(string_builder* sb, const char* str) {
    if (str == NULL)
        return;

    int str_len = strlen(str);
    if (sb->count + str_len >= sb->_len) {
        sb->_len += str_len;
        sb_resize(sb);
    }

    memcpy(sb->_str_p + sb->count, str, str_len);
    sb->count += str_len;
}

char* sb_give_control_of_str(string_builder* sb) {
	char* str_p = sb->_str_p;
	str_p[sb->count] = '\0';
	sb_init(sb);
	return str_p;
}

static void sb_resize(string_builder* sb) {
    sb->_len *= 2;
    sb->_str_p = (char*) realloc(sb->_str_p, sb->_len);
    assert(sb->_str_p);
}

void sb_free(string_builder* sb) {
    sb->count = 0;
    sb->_len = 0;
    free(sb->_str_p);
}

void sb_clear(string_builder* sb) {
    sb->count = 0;
}