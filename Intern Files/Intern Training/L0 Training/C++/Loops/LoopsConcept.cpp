#include <iostream>

using namespace std;

int main()
{
    // Array Creation:
    int arr[] = {10, 2, 3, 4, 5};
    int len = sizeof(arr) / sizeof(arr[0]);

    // Using Loops:
    // For:
    cout << "\nUsing FOR Loop:" << endl;
    for (int i = 0; i < len; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;

    // Finding MIN and MAX:
    int min = arr[0];
    int max = arr[0];

    for (int i = 0; i < len; i++)
    {
        if (min > arr[i])
        {
            min = arr[i];
        }
    }

    for (int i = 0; i < len; i++)
    {
        if (max < arr[i])
        {
            max = arr[i];
        }
    }

    cout << "\nMinimum of the Array: " << min << endl;
    cout << "Maximum of the Array: " << max << endl;

    // Finding the total number of digits:
    int count = 0;

    for (int i = 0; i < len; i++)
    {
        int temp = arr[i];
        while(temp > 0){
            count++;
            temp = temp/10;
        }
    }

    cout << "\nThe total number of digits in the array are: " << count << endl;

    // While:
    cout << "\nUsing WHILE Loop:" << endl;
    int j = 0;
    while (j < len)
    {
        cout << arr[j] << " ";
        j++;
    }
    cout << endl;
    return 0;
}
