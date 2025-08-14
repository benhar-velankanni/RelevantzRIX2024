#include <iostream>

using namespace std;

void selectionSort(int arr[], int &size)
{
    for (int i = 0; i < size - 1; i++)
    {
        int min = 999;
        int index = -1;

        for (int j = i; j < size; j++)
        {
            if (min > arr[j])
            {
                min = arr[j];
                index = j;
            }
        }

        int temp = arr[i];
        arr[i] = arr[index];
        arr[index] = temp;
    }
}

int main()
{
    int arr[] = {45, 34, 67, 23, 98, 54, 9, 12};
    int size = sizeof(arr) / sizeof(arr[0]);

    cout << "\nUnsorted array:";
    for (int x : arr)
    {
        cout << x << ", ";
    }
    cout << endl;

    selectionSort(arr, size);

    cout << "\nSorted array:";
    for (int x : arr)
    {
        cout << x << ", ";
    }
    cout << endl;
}