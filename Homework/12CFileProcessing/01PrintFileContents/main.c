#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 4096

int main(int argc, char** argv) {

    FILE *file = fopen("file.txt", "r");

    if (!file) {
        fprintf(stderr, "Error opening file");
        return (EXIT_FAILURE);
    }

    char buffer[BUFFER_SIZE + 1];
    while (!feof(file) && !ferror(file)) {
        size_t readBytes = fread(buffer, 1, BUFFER_SIZE, file);
        buffer[readBytes] = '\0';
        printf("%s", buffer);
    }
    fclose(file);

    return (EXIT_SUCCESS);
}