#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    FILE *file = fopen("file.txt", "r");
    if (!file) {
        return (EXIT_FAILURE);
    }

    int count = 0;
    while (!feof(file) && !ferror(file)) {

        char *line = NULL;
        size_t size = 0;
        ssize_t length = getline(&line, &size, file);

        if (count % 2 == 0) {
            printf("%s", line);
        }

        free(line);
        count++;
    }

    fclose(file);

    return (EXIT_SUCCESS);
}