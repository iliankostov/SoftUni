#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {

    char *text = "The \"use\" of quotations causes difficulties. \\n, \\t and \\ are also special characters.";

    printf("%s", text);

    return (EXIT_SUCCESS);
}