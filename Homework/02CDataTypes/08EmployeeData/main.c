#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 128

int main(int argc, char** argv) {

    char firstName[BUFFER_SIZE] = "Amanda";
    char lastName[BUFFER_SIZE] = "Jonson";
    char age = 27;
    char gender[1] = "f";
    char personalId[BUFFER_SIZE] = "8306112507";
    char uniqueEmployeeNumber[BUFFER_SIZE] = "27563571";

    printf("First name: %s\n", firstName);
    printf("Last name: %s\n", lastName);
    printf("Age: %d\n", age);
    printf("Gender: %s\n", gender);
    printf("Personal ID: %s\n", personalId);
    printf("Unique Employee number: %s\n", uniqueEmployeeNumber);

    return (EXIT_SUCCESS);
}