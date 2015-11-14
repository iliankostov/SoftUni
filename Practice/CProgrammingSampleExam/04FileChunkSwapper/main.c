#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

#define BUFFER_SIZE 4096

void die(const char *);

int main(int argc, char** argv) {

    if (argc < 3) {
        die("Usage: <src-file> <dest-file>");
    }

    FILE *sourceFile = fopen(argv[1], "r");
    if (!sourceFile) {
        die(argv[1]);
    }

    FILE *destinationFile = fopen(argv[2], "r+");
    if (!destinationFile) {
        die(argv[2]);
    }

    char buffer[BUFFER_SIZE];

    while (!feof(sourceFile)) {
        size_t readBytes = fread(buffer, 1, BUFFER_SIZE, sourceFile);
        if (readBytes == 0) {
            break;
        }
        
        size_t firstHalf = readBytes / 2;
        size_t secondHalf = readBytes - firstHalf;
        char tempBuffer[firstHalf];

        memcpy(tempBuffer, buffer, firstHalf);
        memmove(buffer, buffer + firstHalf, secondHalf);
        memcpy(buffer + secondHalf, tempBuffer, firstHalf);
        
        size_t writtenBytes = fwrite(buffer, 1, readBytes, destinationFile);
        if (writtenBytes == 0) {
            break;
        }
    }
    
    if (ferror(sourceFile)) {
        die("Cannot read from source file");
    }
    
    if (ferror(destinationFile)) {
        die("Cannot write to destination file");
    }

    fclose(sourceFile);
    fclose(destinationFile);
    
    printf("Success!\n");
    return 0;
}

void die(const char *msg) {
    if (errno) {
        perror(msg);
    } else {
        fprintf(stderr, "%s", msg);
    }

    exit(EXIT_FAILURE);
}