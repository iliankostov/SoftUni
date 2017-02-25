#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    FILE *sourceFile = fopen("main.c", "r");
    if (!sourceFile) {
        return (EXIT_FAILURE);
    }

    FILE *modifiedFile = fopen("modified.c", "w");
    if (!modifiedFile) {
        return (EXIT_FAILURE);
    }


    int count = 0;
    while (!feof(sourceFile) && !ferror(sourceFile)) {

        char *line = NULL;
        size_t size = 0;
        ssize_t length = getline(&line, &size, sourceFile);

        fprintf(modifiedFile, "%d %s", count, line);

        free(line);
        count++;
    }

    fclose(sourceFile);
    fclose(modifiedFile);

    printf("Done!");

    return (EXIT_SUCCESS);
}