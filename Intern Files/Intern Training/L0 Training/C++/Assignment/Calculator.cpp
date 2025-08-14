#include <iostream>

using namespace std;

void divideValue(int a, int b)
{
    if (b == 0)
    {
        cout << "\nCannot perform zero division.";
        cout << endl;
    }
    else
    {
        cout << "\nThe remainder is: " << a / b;
        cout << endl;
    }
}

void powerOf(int a, int b)
{
    int result = 1;
    for (int i = 0; i < b; i++)
    {
        result *= a;
    }

    cout << "\nThe result is: " << result;
    cout << endl;
}

int main()
{

start:

    cout << "\n---------------------";
    cout << "\nEnter your 1st operand: ";
    cout << "\n---------------------" << endl;
    cout << endl;
    int a = 0;
    cin >> a;
    cout << endl;

    cout << "\n---------------------";
    cout << "\nEnter your 2nd operand: ";
    cout << "\n---------------------" << endl;
    cout << endl;
    int b = 0;
    cin >> b;
    cout << endl;

    char cont = 'x';
    while (cont != 'n' || cont != 'N')
    {
        cout << "\nActions to perform:";
        cout << "\n---------------------" << endl;
        cout << "\n0.Reset (AC).";
        cout << "\n1.Addition.";
        cout << "\n2.Subtraction.";
        cout << "\n3.Multiplication.";
        cout << "\n4.Division.";
        cout << "\n5.Square of a.";
        cout << "\n6.Square of b.";
        cout << "\n7.Cube of a.";
        cout << "\n8.Cube of b.";
        cout << "\n9.'a' raised to the power of 'b'.";
        cout << endl;
        cout << "\nEnter your choice: ";
        int choice;
        cin >> choice;
        switch (choice)
        {
        case 0:
            goto start;
            break;

        case 1:
            cout << "\nThe sum is: " << a + b;
            cout << endl;
            break;

        case 2:
            cout << "\nThe difference is: " << a - b;
            cout << endl;
            break;

        case 3:
            cout << "\nThe product is: " << a * b;
            cout << endl;
            break;

        case 4:
            divideValue(a, b);
            break;

        case 5:
            cout << "\nThe square of " << a << " is: " << a * a;
            cout << endl;
            break;

        case 6:
            cout << "\nThe square of " << b << " is: " << b * b;
            cout << endl;
            break;

        case 7:
            cout << "\nThe cube of " << a << " is: " << a * a * a;
            cout << endl;
            break;

        case 8:
            cout << "\nThe square of " << b << " is: " << b * b * b;
            cout << endl;
            break;

        case 9:
            powerOf(a, b);
            break;

        default:
            cout << "Invalid Choice!" << endl;
            break;
        }

    cont:
        cout << "\nContinue?(y/n)" << endl;
        cin >> cont;

        if (cont == 'n' || cont == 'N')
        {
            cout << "\n----------";
            cout << "\nThank You!";
            cout << "\n----------" << endl;
            break;
        }
        else if (cont == 'y' || cont == 'Y')
        {
            continue;
        }
        else
        {
            cout << "\nInvalid Choice!" << endl;
            goto cont;
        }
    }
}