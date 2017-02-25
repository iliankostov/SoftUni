#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 128

int main(int argc, char** argv) {

    char firstName[BUFFER_SIZE] = "Pesho";
    char middleName[BUFFER_SIZE] = "Peshev";
    char lastName[BUFFER_SIZE] = "Peshev";
    double balance = 10000.00;
    char bankName[BUFFER_SIZE] = "First Investment Bank";
    char iban[BUFFER_SIZE] = "BG101520THISISFAKEIBAN";
    char cardOneNumber[BUFFER_SIZE] = "1234567890123456";
    char cardTwoNumber[BUFFER_SIZE] = "5678901234561234";
    char cardThreeNumber[BUFFER_SIZE] = "9012345612345678";

    char holderName[BUFFER_SIZE];
    sprintf(holderName, "%s %s %s", firstName, middleName, lastName);

    printf("Holder name: %s\n", holderName);
    printf("Balance: %.2f\n", balance);
    printf("Bank: %s\n", bankName);
    printf("IBAN: %s\n", iban);
    printf("Card one number: %s\n", cardOneNumber);
    printf("Card two number: %s\n", cardTwoNumber);
    printf("Card three number: %s\n", cardThreeNumber);

    return (EXIT_SUCCESS);
}