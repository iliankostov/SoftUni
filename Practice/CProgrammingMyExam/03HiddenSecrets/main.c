#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

#define BUFFER_SIZE 64
#define SIGN_SIZE 4
#define APPLE "3456"
#define LEAF "!\"#$"
#define CROSS "+,-."

const char *get_filename_ext(const char *);
void kill(const char *);

int main(int argc, char** argv) {
    
    if (argc < 3) {
        kill("Usage: [<src-file-1> <src-file-2> ...]\n");
    }
    
    const char *fileExt = get_filename_ext(argv[1]); 
    
    char fileName[BUFFER_SIZE];
    sprintf(fileName, "merged.%s", fileExt);

    FILE *destFile = fopen(fileName, "w");
    if (!destFile) {
        kill("");
    }

    char buffer[BUFFER_SIZE];
    size_t i;
    for (i = 1; i < argc; i++) {

        FILE *currentPart = fopen(argv[i], "r");
        if (!currentPart) {
            kill(argv[i]);
        }

        while (!feof(currentPart) && !ferror(destFile) && !ferror(currentPart)) {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, currentPart);
            if (readBytes == 0) {
                break;
            }

            size_t dataSize = readBytes - SIGN_SIZE;
            char sign[SIGN_SIZE];
            char temp[dataSize];

            int i, j = 0;
            for (i = 0; i <= readBytes; i++) {
                if (i >= dataSize) {
                    sign[j] = buffer[i];
                    j++;
                }
            }

            if (memcmp(sign, APPLE, SIGN_SIZE) == 0) {
                //// Debug
                //printf("apple - %ld\n", dataSize);
                memcpy(temp, buffer, dataSize);
            }
            if (memcmp(sign, LEAF, SIGN_SIZE) == 0) {
                //// Debug
                //printf("leaf - %ld\n", dataSize);
                dataSize /= 2;
                memcpy(temp, buffer, dataSize);
            }
            if (memcmp(sign, CROSS, SIGN_SIZE) == 0) {
                //// Debug
                //printf("cross - %ld\n", dataSize);
                dataSize = 0;
                memcpy(temp, buffer, dataSize);
            }

            fwrite(temp, 1, dataSize, destFile);
        }

        fclose(currentPart);
    }

    fclose(destFile);

    printf("Eureka!\n");

    return (EXIT_SUCCESS);
}

const char *get_filename_ext(const char *filename) {
    const char *dot = strrchr(filename, '.');
    if(!dot || dot == filename) return "";
    return dot + 1;
}

void kill(const char *msg) {
    if (errno) {
        perror(msg);
    } else {
        fprintf(stderr, "%s", msg);
    }

    exit(EXIT_FAILURE);
}