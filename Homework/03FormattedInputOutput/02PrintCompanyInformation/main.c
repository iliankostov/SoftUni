#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 128

int main(int argc, char** argv) {

    char companyName[BUFFER_SIZE],
            companyAddress[BUFFER_SIZE],
            phoneNumber[BUFFER_SIZE],
            faxNumber[BUFFER_SIZE],
            webSite[BUFFER_SIZE],
            managerFirstName[BUFFER_SIZE],
            managerLastName[BUFFER_SIZE],
            managerAge,
            managerPhone[BUFFER_SIZE];

    printf("Company name: ");
    scanf(" %[^\n]s", companyName);

    printf("Company address: ");
    scanf(" %[^\n]s", companyAddress);

    printf("Phone number: ");
    scanf(" %[^\n]s", phoneNumber);

    printf("Fax number: ");
    scanf(" %[^\n]s", faxNumber);

    printf("Web site: ");
    scanf(" %[^\n]s", webSite);

    printf("Manager first name: ");
    scanf(" %[^\n]s", managerFirstName);

    printf("Manager last name: ");
    scanf(" %[^\n]s", managerLastName);

    printf("Manager age: ");
    scanf("%d", &managerAge);

    printf("Manager phone: ");
    scanf(" %[^\n]s", managerPhone);

    printf("%s\n", companyName);
    printf("Address: %s\n", companyAddress);
    printf("Tel: %s\n", phoneNumber);
    printf("Fax: %s\n", faxNumber);
    printf("Web site: %s\n", webSite);
    printf("Manager: %s %s (age: %d, tel: %s)", managerFirstName, managerLastName, managerAge, managerPhone);

    return (EXIT_SUCCESS);
}