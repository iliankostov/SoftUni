#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_DATA 25
#define BIT_COUNT 64
#define END_COMMAND "end"
#define LEFT_COMMAND "left"

void ProcessInput();
void ProcessGame();
void ProcessCommand(char * command, int position);
void MoveLeft(int position);
void MoveRight(int position);
void PrintNumbers();
void PrintNumbersInBinary();
void PrintBinary(long long number);
int GetBitAtPosition(long long number, int position);
void SetBitAtPosition(long long * number, int position, int bit);

static long long numbers[MAX_DATA];

static int numbersCount;

int main()
{
    ProcessInput();
    ProcessGame();
    PrintNumbers();

    return 0;
}

void ProcessGame()
{
    char command[MAX_DATA];
    int position;

    scanf("%s", command);

    while (strcmp(command, END_COMMAND) != 0)
    {
        scanf("%d", &position);
        ProcessCommand(command, position);
        scanf("%s", command);
    }
}

void ProcessCommand(char * command, int position)
{
    if (strcmp(command, LEFT_COMMAND) == 0)
    {
        MoveLeft(position);

        // Debug
        // PrintNumbersInBinary();
    }
    else
    {
        MoveRight(position);

        // Debug
        // PrintNumbersInBinary();
    }
}

void MoveLeft(int position)
{
    for (int index = 0; index < numbersCount; ++index)
    {
        long long number = numbers[index];
        int onesCount = 0;

        for (int bit = position; bit < BIT_COUNT; ++bit)
        {
            int currentBit = GetBitAtPosition(number, bit);
            if (currentBit == 1)
            {
                ++onesCount;
                SetBitAtPosition(&number, bit, 0);
            }
        }

        for (int bit = BIT_COUNT - 1; bit >= BIT_COUNT - onesCount; --bit)
        {
            SetBitAtPosition(&number, bit, 1);
        }

        numbers[index] = number;
    }
}

void MoveRight(int position)
{
    for (int index = 0; index < numbersCount; ++index)
    {
        long long * number = &numbers[index];
        int onesCount = 0;

        for (int bit = position; bit >= 0; --bit)
        {
            int currentBit = GetBitAtPosition(*number, bit);
            if (currentBit == 1)
            {
                ++onesCount;
                SetBitAtPosition(number, bit, 0);
            }
        }

        for (int bit = 0; bit < onesCount; ++bit)
        {
            SetBitAtPosition(number, bit, 1);
        }
    }
}

int GetBitAtPosition(long long number, int position)
{
    return (number >> position) & 1;
}

void SetBitAtPosition(long long * number, int position, int bit)
{
    if (bit == 0)
    {
        (*number) &= ( ~((long long)1 << position));
    }
    else
    {
        (*number) |= (long long)1 << position;
    }
}

void ProcessInput()
{
    scanf("%d", &numbersCount);

    for (int index = 0; index < numbersCount; ++index)
    {
        scanf("%d", &numbers[index]);
    }
}

void PrintNumbers()
{
    for (int index = 0; index < numbersCount; ++index)
    {
        // The numbers may be kept as signed longs but
        // it does not matter for the output
        printf("%llu\n", numbers[index]);
    }
}

void PrintNumbersInBinary()
{
    for (int index = 0; index < numbersCount; ++index)
    {
        PrintBinary(numbers[index]);
    }
}

void PrintBinary(long long number)
{
    int bit;

    // Pad with zeroes
    for (bit = BIT_COUNT - 1; bit >= 0; --bit)
    {
        if ((number >> bit) & 1)
        {
            break;
        }

        printf("0");
    }

    while (bit >= 0)
    {
        printf("%d", ( (number >> bit) & 1));
        --bit;
    }

    printf("\n");
}