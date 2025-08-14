#include <iostream>
#include <array>

using namespace std;

const int MAX_SIZE = 100;

// Ex : 1	 Write a C++ program to sort a numeric array and a string array.
void bubbleSort(int arr[], int &n)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = temp;
            }
        }
    }
    cout << "\nThe sorted array: ";
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << ", ";
    }
    cout << endl;
    return;
}

// Ex : 2	Write a C++ program to sum values of an array.
void addElements(int arr[], int &n)
{
    int sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += arr[i];
    }

    cout << "\nThe sum of all elements of the array is: " << sum << endl;
    return;
}

// Ex : 3	Write a C++ program to calculate the average value of array elements.
void avgOfArray(int arr[], int &n)
{
    int avg = 0;
    for (int i = 0; i < n; i++)
    {
        avg += arr[i];
    }
    avg /= n - 1;

    cout << "\nThe average of all elements of the array is: " << avg << endl;
    return;
}

// Ex : 4	Write a C++ Program Traversing the elements from the Array
void display(int arr[], int &n)
{
    cout << "\nArray: ";
    for (int i = 0; i < n; i++)
    {
        cout << arr[i] << ", ";
    }
    cout << endl;
}

// Ex : 5	Write a C++ program to test if an array contains a specific value.
// Ex : 6	Write a C++ program to find the index of an array element.
// Ex : 11	Write a C++ Searching the element from the Array.
void linearSearch(int arr[], int &n)
{
    int value;
    cout << "\nEnter the target value to search: ";
    std::cin >> value;
    cout << endl;

    int index = -1;
    for (int i = 0; i < n; i++)
    {
        if (arr[i] == value)
        {
            index = i;
            break;
        }
    }

    if (index != -1)
    {
        cout << "\nThe element " << value << " is present in " << index << " index position." << endl;
    }
    else
    {
        cout << "\nThe element " << value << " is not present withing the array." << endl;
    }
}

// Ex : 7	Write a C++ program to remove a specific element from an array.
void deleteValue(int arr[], int &n)
{
    int value;
    cout << "\nEnter the target value to delete: ";
    std::cin >> value;
    cout << endl;

    int index = -1;
    for (int i = 0; i < n; i++)
    {
        if (arr[i] == value)
        {
            index = i;
            break;
        }
    }

    if (index != -1)
    {
        for (int i = index; i < n; i++)
        {
            arr[i] = arr[i + 1];
        }
    }
    else
    {
        cout << "\nThe element " << value << " is not present withing the array." << endl;
    }
}

// Ex : 8	Write a C++ program to copy an array by iterating the array.
void copyArray(int arr[], int &n)
{
    int arr1[n];

    for (int i = 0; i < n; i++)
    {
        arr1[i] = arr[i];
    }

    cout << "\nResults after copying:";
    display(arr1, n);
}

// Ex : 9	Write a c++  Inserting an element into the Array
void insertElement(int arr[], int &n)
{
    int value;
    cout << "\nEnter the target value to insert: ";
    std::cin >> value;

    int index;
    cout << "\nEnter the index value for insertion: ";
    std::cin >> index;
    cout << endl;

    for (int i = n; i >= index; i--)
    {
        arr[i] = arr[i - 1];
    }

    arr[index] = value;
    n++;

    cout << "\nResults after inserting:";
    display(arr, n);
}

// Ex : 10	Write a  C++ Deleting  the element from the Array.
void deleteElement(int arr[], int &n)
{
    int value;
    cout << "\nEnter the target value to delete: ";
    std::cin >> value;

    int index = -1;
    for (int i = 0; i < n; i++)
    {
        if (arr[i] == value)
        {
            index = i;
            break;
        }
    }

    if (index != -1)
    {
        for (int i = index; i < n; i++)
        {
            arr[i] = arr[i + 1];
        }
        n--;
    }
    else
    {
        cout << "\nThe element " << value << " is not present withing the array." << endl;
    }

    cout << "\nResults after deletion:";
    display(arr, n);
}

// Ex : 15	Write a C++ program to find the maximum and minimum value of an array.
void minMax(int arr[], int &n)
{
    int min = 999;
    int max = -1;

    for (int i = 0; i < n; i++)
    {
        if (min > arr[i])
        {
            min = arr[i];
        }
    }

    for (int i = 0; i < n; i++)
    {
        if (max < arr[i])
        {
            max = arr[i];
        }
    }

    cout << "\nThe minimum and maximum of the array are: " << min << " & " << max << " respectively." << endl;
}

int main()
{
    // Array decleration and definition:
    int arr[MAX_SIZE];
    int n;
    cout << "Enter the array size: ";
    std::cin >> n;
    cout << endl;

    cout << "Enter the array elements: ";
    for (int i = 0; i < n; i++)
    {
        cin >> arr[i];
    }

    char cont = 'x';
    while (cont != 'n' || cont != 'N')
    {
        cout << "\nActions to perform:";
        cout << "\n---------------------" << endl;
        cout << "\n1.Print Array.";
        cout << "\n2.Search by value.";
        cout << "\n3.Delete by value.";
        cout << "\n4.Sort Array.";
        cout << "\n5.Sum of array elements.";
        cout << "\n6.Average of array elements.";
        cout << "\n7.Copying an array.";
        cout << "\n8.Insert an element.";
        cout << "\n9.Delete an element.";
        cout << "\n10.Maximum and minimum of the array.";
        cout << endl;
        cout << "\nEnter your choice: ";
        int choice;
        cin >> choice;
        switch (choice)
        {
        case 1:
            display(arr, n);
            break;

        case 2:
            linearSearch(arr, n);
            break;

        case 3:
            deleteValue(arr, n);
            break;

        case 4:
            bubbleSort(arr, n);
            break;

        case 5:
            addElements(arr, n);
            break;

        case 6:
            avgOfArray(arr, n);
            break;

        case 7:
            copyArray(arr, n);
            break;

        case 8:
            insertElement(arr, n);
            break;

        case 9:
            deleteElement(arr, n);
            break;

        case 10:
            minMax(arr, n);
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