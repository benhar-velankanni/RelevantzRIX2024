#include <iostream>

using namespace std;

int linearSearch(int arr[], int &n, int &target)
{
    // Initiation of index variable:
    int index = -1;

    // For loop to search for the target:
    for (int i = 0; i < n; i++)
    {
        if (arr[i] == target)
        {
            index = i;
            break;
        }
    }

    // return index value:
    return index;
}

int main()
{
    // Array creation and definition:
    cout << "Enter array size: ";
    int n;
    cin >> n;
    cout << endl;

    int arr[n];
    cout << "\nEnter array values: " << endl;
    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
    }

    // Obtaining target value:
    cout << "\nEnter the target value: ";
    int target;
    cin >> target;
    cout << endl;

    // Function call for linear searching:
    int index1 = linearSearch(arr, n, target);

    // Print Results:
    if (index1 != -1)
    {
        cout << "\nThe element " << target << " is present in " << index1 << " index position." << endl;
    }
    else
    {
        cout << "\nThe element " << target << " is not present withing the array." << endl;
    }
}