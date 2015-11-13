0#include <stdio.h>
1#include <stdlib.h>
2
3 int main(int argc, char** argv) {
    4
    5 FILE *sourceFile = fopen("main.c", "r");
    6 if (!sourceFile) {
        7 return (EXIT_FAILURE);
        8    }
    9
    10 FILE *modifiedFile = fopen("modified.c", "w");
    11 if (!modifiedFile) {
        12 return (EXIT_FAILURE);
        13    }
    14
    15
    16 int count = 0;
    17 while (!feof(sourceFile) && !ferror(sourceFile)) {
        18
        19 char *line = NULL;
        20 size_t size = 0;
        21 ssize_t length = getline(&line, &size, sourceFile);
        22
        23 fprintf(modifiedFile, "%d %s", count, line);
        24
        25 free(line);
        26 count++;
        27    }
    28
    29 fclose(sourceFile);
    30 fclose(modifiedFile);
    31
    32 printf("Done!");
    33
    34 return (EXIT_SUCCESS);
    35
}