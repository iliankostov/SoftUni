#include <stdio.h>
#include <stdlib.h>
#include <errno.h>

#define BUFFER_SIZE 4096

void copy(const char *, const char *);
void die(const char *);

int main(int argc, char** argv) {

    if (argc == 1) {
        copy("source.png", "destination.png");
    }

    if (argc == 3) {
        copy(argv[1], argv[2]);
    }

    return (EXIT_SUCCESS);
}

void copy(const char *sourceFilePath, const char *destinationFilePath) {
    FILE *sourceFile = fopen(sourceFilePath, "r");
    if (!sourceFile) {
        die("Cannot open source file");
    }

    FILE *destinationFile = fopen(destinationFilePath, "w");
    if (!destinationFile) {
        die("Cannot open destination file");
    }

    char buffer[BUFFER_SIZE];
    while (!feof(sourceFile) && !ferror(sourceFile) && !ferror(destinationFile)) {
        size_t readBytes = fread(buffer, 1, BUFFER_SIZE, sourceFile);
        fwrite(buffer, 1, readBytes, destinationFile);
    }

    fclose(sourceFile);
    fclose(destinationFile);
    
    printf("Done!");
}

void die(const char *msg) {
    if (errno) {
        perror(msg);
    } else {
        fprintf(stderr, msg);
    }

    exit(EXIT_FAILURE);
}