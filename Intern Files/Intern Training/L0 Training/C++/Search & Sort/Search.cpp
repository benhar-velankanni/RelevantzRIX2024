#include <iostream>
#include <array>

using namespace std;

//Ex : 1	Write a C++ program to implement Linear Search using Array.
void linearSearch(int arr[], int &size, int &target)
{
    bool found = false;
    int index;
    for (int i = 0; i < size; i++)
    {
        if (arr[i] == target)
        {
            found = true;
            index = i;
            break;
        }
    }

    if (found)
    {
        cout << "\nThe element " << target << " is found at the index = " << index << "." << endl;
    }
    else
    {
        cout << "\nThe element " << target << " is not found within the array." << endl;
    }
}

//Ex : 3	Write a C++ program to implement Binary Search using Array.
void binarySearch(int arr[], int &size, int &target)
{
    bool found = false;
    int index;

    int low = 0;
    int high = size - 1;
    int middle = low + high / 2;

    while (low <= high)
    {
        middle = low + high / 2;
        if (arr[middle] == target)
        {
            index = middle;
            found = true;
            break;
        }
        else if (arr[middle] < target)
        {
            low = middle + 1;
        }
        else
        {
            high = middle - 1;
        }
    }

    if (found)
    {
        cout << "\nThe element " << target << " is found at the index = " << index << "." << endl;
    }
    else
    {
        cout << "\nThe element " << target << " is not found within the array." << endl;
    }
}

int main()
{
    int arr[] = {10, 40, 20, 50, 38, 57};
    int size = sizeof(arr) / sizeof(arr[0]);
    int target;

    cout << "\nEnter the value to linear search: ";
    cin >> target;

    linearSearch(arr, size, target);

    int arr2[] = {10, 20, 30, 40, 50, 60};
    int size2 = sizeof(arr2) / sizeof(arr2[0]);

    cout << "\nEnter the value to binary search: ";
    cin >> target;

    binarySearch(arr2, size2, target);
}