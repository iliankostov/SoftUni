#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define LINE_LENGTH 30

int main(int argc, char** argv) {
    
    char line[LINE_LENGTH];
    fgets(line, LINE_LENGTH, stdin);
    int length = strlen(line);
    if (line[length - 1] == '\n') {
        line[length - 1] = '\0';
    }
    
    int isOdd = 1;
    int evenProduct = 1;
    int oddProduct = 1;
    char *token = strtok(line, " ");
    while (token != NULL) {
        int num = atoi(token);
        
        if (isOdd) {
            oddProduct *= num;
        }
        else {
            evenProduct *= num;
        }

        isOdd = !isOdd;
        token = strtok(NULL, " ");
    }
    
    if (oddProduct == evenProduct) {
        printf("yes\nproduct = %d", oddProduct);
    }
    else {
        printf("no\nodd_product = %d\neven_product = %d", oddProduct, evenProduct);
    }

    return (EXIT_SUCCESS);
}