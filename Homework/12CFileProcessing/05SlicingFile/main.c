#include <stdio.h>
#include <stdlib.h>
#include <errno.h>

#define BUFFER_SIZE 4096
#define PARTS 5

void slice(const char *, const char *, size_t);
void assemble(const char **, const char *);
void die(const char *);

int main(int argc, char** argv) {

    slice("source.png", "", PARTS);

    const char *parts[] = {"Part-1.png", "Part-2.png", "Part-3.png", "Part-4.png", "Part-5.png"};

    assemble(parts, "destination.png");

    return (EXIT_SUCCESS);
}

void slice(const char *sourceFilePath, const char *destinationDirectory, size_t parts) {

    FILE *sourceFile = fopen(sourceFilePath, "r");
    if (!sourceFile) {
        die("Cannot open source file");
    }

    fseek(sourceFile, 0, SEEK_END);
    long long possition = ftell(sourceFile);
    fseek(sourceFile, 0, SEEK_SET);

    long long partSize = (possition / parts) + 1;
    char buffer[BUFFER_SIZE];
    size_t i;
    for (i = 0; i < parts; i++) {

        char name[128];
        sprintf(name, "%sPart-%ld.png", destinationDirectory, i + 1);

        FILE *currentDestinationFile = fopen(name, "w");
        if (!currentDestinationFile) {
            die("Cannot open part file");
        }

        size_t writtenBytes = 0;
        while (writtenBytes <= partSize && !feof(sourceFile)) {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, sourceFile);
            fwrite(buffer, 1, readBytes, currentDestinationFile);
            writtenBytes += readBytes;
        }

        fclose(currentDestinationFile);
    }

    fclose(sourceFile);
    printf("Sliced Done!\n");
}

void assemble(const char **parts, const char *destinationFilePath) {

    FILE *destinationFile = fopen(destinationFilePath, "w");
    if (!destinationFile) {
        die("Cannot open destination file");
    }

    char buffer[BUFFER_SIZE];
    size_t i;
    for (i = 0; i < PARTS; i++) {
        FILE *currentPart = fopen(*(parts + i), "r");
        if (!currentPart) {
            die("Cannot open current part");
        }

        while (!feof(currentPart) && !ferror(destinationFile) && !ferror(currentPart)) {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, currentPart);
            fwrite(buffer, 1, readBytes, destinationFile);
        }

        fclose(currentPart);
    }

    fclose(destinationFile);

    printf("Assembling Done!\n");
}

void die(const char *msg) {
    if (errno) {
        perror(msg);
    } else {
        fprintf(stderr, msg);
    }

    exit(EXIT_FAILURE);
}