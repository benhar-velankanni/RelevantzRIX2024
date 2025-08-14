#include <iostream>
#include <array>

using namespace std;

const int MAX_SIZE = 100;

bool deleteElement(int arr[], int &n, int value)
{
    // Search the value to delete:
    int i;
    int pos = -1;
    for (i = 0; i < n; i++)
    {
        if (arr[i] == value)
        {
            pos = i;
            break;
        }
    }

    // If element is not found:
    if (pos == -1)
    {
        return false;
    }

    // Delete the element:
    for (int i = pos; i < n; i++)
    {
        arr[i] = arr[i + 1];
    }

    // Modify the new index:
    n--;

    return true;
}

int main()
{
    // Array decleration and definition:
    int arr[MAX_SIZE] = {10, 20, 30, 40, 50};
    int n = 5;

    // Value to delete:
    int value = 40;

    // Print array:
    cout << "The original array:";
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << ", ";
    }
    cout << endl;

    // Funtion call for deletion:
    deleteElement(arr, n, value);

    // Print array:
    cout << "The newly modded array:";
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << ", ";
    }
    cout << endl;
}