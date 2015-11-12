#include <stdio.h>
#include <stdlib.h>
#include <errno.h>

#define BUFFER_SIZE 4096

ssize_t get_line(char **lineptr, size_t *buf_size, FILE *stream);
int str_split(char** dest[], char* raw_str, const char* delimiters);
void offset_time(char *newStr, char *oldStr, int offset);
void die(const char *);

int main(int argc, char** argv) {

    int offset = 1500;

    FILE *sourceFile = fopen("source.sub", "r");
    if (!sourceFile) {
        die("Cannot open source file");
        return (EXIT_FAILURE);
    }

    FILE *fixedFile = fopen("fixed.sub", "w");
    if (!fixedFile) {
        die("Cannot open destination file");
    }

    char buffer[BUFFER_SIZE];
    while (!feof(sourceFile) && !ferror(sourceFile)) {

        char *line = NULL;
        size_t size = 0;
        ssize_t lenght = get_line(&line, &size, sourceFile);

        char** elements = NULL;
        int element_count = str_split(&elements, line, "-->");

        if (element_count == 2) {

            char *start_str = *(elements);
            char *end_str = *(elements + 1);

            char new_start_str[13];
            char new_end_str[13];

            offset_time(new_start_str, start_str, offset);
            offset_time(new_end_str, end_str, offset);

            sprintf(line, "%s --> %s", new_start_str, new_end_str);
        }

        fprintf(fixedFile, "%s\n", line);
    }

    fclose(sourceFile);
    fclose(fixedFile);
    printf("Done!");

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

    return (ssize_t) (i + 1);
}

int str_split(char** dest[], char* raw_str, const char* delimiters) {
    int split_arr_len = 0;
    int dest_current_len = 10;
    *dest = malloc(dest_current_len * sizeof (char*));
    if (*dest == NULL) exit(1);

    char* current_split = strtok(raw_str, delimiters);
    while (current_split != NULL) {
        int current_split_len = strlen(current_split) * sizeof (char);

        // malloc space for the current_split in the dest array :
        (*dest)[split_arr_len] = malloc(current_split_len + 1);
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
            *dest = realloc(*dest, dest_current_len * sizeof (char*));
            if (*dest == NULL) exit(1);
        }
    }

    return split_arr_len;
}

void offset_time(char *newStr, char *oldStr, int offset) {
    long long timespan = 0;

    char **elements = NULL;
    str_split(&elements, oldStr, ":,");

    char *ptr;
    long hours = strtol(*(elements), &ptr, 10);
    long minutes = strtol(*(elements + 1), &ptr, 10);
    long seconds = strtol(*(elements + 2), &ptr, 10);
    long miliseconds = strtol(*(elements + 3), &ptr, 10);

    timespan += hours * 60 * 60 * 1000;
    timespan += minutes * 60 * 1000;
    timespan += seconds * 1000;
    timespan += miliseconds;
    timespan += offset;

    int newHours = timespan / 1000 / 60 / 60;
    char hoursStr[3];
    newHours < 10 ? sprintf(hoursStr, "0%d", newHours) : sprintf(hoursStr, "%d", newHours);
    timespan -= newHours * 60 * 60 * 1000;

    int newMinutes = timespan / 1000 / 60;
    char minutesStr[3];
    newMinutes < 10 ? sprintf(minutesStr, "0%d", newMinutes) : sprintf(minutesStr, "%d", newMinutes);
    timespan -= newMinutes * 60 * 1000;

    int newSeconds = timespan / 1000;
    char secondsStr[3];
    newSeconds < 10 ? sprintf(secondsStr, "0%d", newSeconds) : sprintf(secondsStr, "%d", newSeconds);
    timespan -= newSeconds * 1000;

    int newMiliseconds = timespan;
    char milisecondsStr[3];
    if (newMiliseconds < 10) {
        sprintf(milisecondsStr, "00%d", newMiliseconds);
    } else if (newMiliseconds < 100) {
        sprintf(milisecondsStr, "0%d", newMiliseconds);
    } else {
        sprintf(milisecondsStr, "%d", newMiliseconds);
    }

    sprintf(newStr, "%s:%s:%s,%s", hoursStr, minutesStr, secondsStr, milisecondsStr);
}

void die(const char *msg) {
    if (errno) {
        perror(msg);
    } else {
        fprintf(stderr, msg);
    }

    exit(EXIT_FAILURE);
}