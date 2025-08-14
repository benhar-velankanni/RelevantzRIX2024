#include <iostream>
#include <array>

using namespace std;

int main()
{
    // Array Decleration and Definition:
    int arr1[] = {10, 20, 30, 40, 50};
    int len1 = sizeof(arr1) / sizeof(arr1[0]);

    // Using std::array - fixed size and more modern C++:
    std::array<int, 5> arr2;
    arr2[0] = 12;
    arr2[1] = 13;
    arr2[2] = 14;
    arr2[3] = 15;
    arr2[4] = 16;

    std::array<int, 5> arr3 = {34, 45, 56, 67, 67};

    // Print Array:

    cout << "The Array 1 elements are: ";
    for (int i = 0; i < len1; i++)
    {
        cout << arr1[i] << ", ";
    }
    cout << endl;

    // Size of array:
    cout << "\nThe size of the arr3 is: " << arr3.size() << endl;
    cout << "\nThe size of the arr1 is: " << arr3.size() << endl;

    // Size from user:
    int len2;
    cout << "\nEnter length of the array: ";
    std::cin >> len2;
    int arr4[len2];
    for (int i = 0; i < len2; i++)
    {
        cin >> arr4[i];
    }
    cout << "\nThe Array 4 elements are: ";
    for (int i = 0; i < len2; i++)
    {
        cout << arr4[i] << ", ";
    }
    cout << endl;
}