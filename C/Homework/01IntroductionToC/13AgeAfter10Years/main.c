#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(int argc, char** argv) {

    int day, month, year;
    printf("Type your birthdate in format dd.mm.yyyy: ");
    scanf("%d.%d.%d", &day, &month, &year);

    time_t t = time(NULL);
    struct tm tm = *localtime(&t);

    int yearNow = tm.tm_year + 1900;
    int monthNow = tm.tm_mon + 1;
    int dayNow = tm.tm_mday;

    int yourAge = yearNow - year;

    if (monthNow <= month) {
        if (dayNow < day) {
            yourAge -= 1;
        }
    }

    printf("Now: %d\n", yourAge);
    printf("After 10 years: %d", yourAge + 10);

    return (EXIT_SUCCESS);
}