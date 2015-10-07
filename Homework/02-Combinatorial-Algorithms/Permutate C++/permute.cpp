// Antonii Zlatarov
#include <iostream>
using namespace std;
int numbers[100000];
void swapnumbers(int &a,int &b)
{
    int staroa = a;
    a = b;
    b = staroa;
}
void perm(int broiChisla,int stupka)
{
    if (stupka==broiChisla-1)
    {
        for (int j=0;j<broiChisla;j++)
        {
            cout<<numbers[j];
        }
        cout<<endl;
    }
    else
    {
        for (int j=stupka;j<broiChisla;j++)
        {
            swapnumbers(numbers[stupka],numbers[j]);
            perm(broiChisla,stupka+1);
            swapnumbers(numbers[stupka],numbers[j]);
        }
    }
}
int main()
{
    int broiChisla;
    cin>>broiChisla;
    for (int stupka=0; stupka<broiChisla; stupka++)
    {
        numbers[stupka] = stupka + 1;
    }
    perm(broiChisla,0);
    cin>>broiChisla;
    return 0;
}
