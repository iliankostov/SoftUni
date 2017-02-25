#include <stdio.h>
#include <stdlib.h>

#define STR_CAPACITY 32

int main(int argc, char** argv) {

    int choose, n;
    double d;
    char str[STR_CAPACITY];
    printf("1 --> int\n2 --> double\n3 --> string\nPlease choose a type: ");
    scanf("%d", &choose);

    switch (choose) {
        case 1:
            printf("Please enter a int: ");
            scanf("%d", &n);
            n += 1;
            printf("%d", n);
            break;
        case 2:
            printf("Please enter a double: ");
            scanf("%lf", &d);
            d += 1;
            printf("%.1lf", d);
            break;
        case 3:
            printf("Please enter a string: ");
            scanf("%s", str);
            int i;
            for (i = 0; i < STR_CAPACITY; i++) {
                if (str[i] == '\0') {
                    str[i] = '*';
                    str[i + 1] = '\0';
                    break;
                }
            }
            printf("%s", str);
            break;
        default: printf("invalid choose");
            break;
    }

    return (EXIT_SUCCESS);
}