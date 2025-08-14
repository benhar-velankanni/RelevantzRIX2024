#include <iostream>
#include <string>
#include <list>
#include <algorithm> //For using std::find

using namespace std;

int main()
{
    list<int> myList = {10, 20, 30, 40, 50};
    list<int> myList1;

    // Insertion at the begining:
    myList.push_front(-10);

    // Insertion at the back:
    myList.push_back(60);

    cout << "After Pushing: ";
    for (int i : myList)
    {
        cout << i << " ";
    }
    cout << endl;

    // Deletion from front:
    myList.pop_front();

    // Deletion from back:
    myList.pop_back();

    cout << "\nAfter Popping: ";
    for (int i : myList)
    {
        cout << i << " ";
    }
    cout << endl;

    // Finding an element and insering after "it":
    auto it1 = std::find(myList.begin(), myList.end(), 40);
    if (it1 != myList.end())
    {
        myList.insert(next(it1), 45);
    }

    cout << "\nAfter Insertion: ";
    for (int i : myList)
    {
        cout << i << " ";
    }
    cout << endl;

    // Finding an element and erasing after "it":
    auto it2 = std::find(myList.begin(), myList.end(), 40);
    if (it2 != myList.end())
    {
        myList.erase(next(it2));
    }

    cout << "\nAfter Erasing: ";
    for (int i : myList)
    {
        cout << i << " ";
    }
    cout << endl;

    // Finding an element and replacing "it":
    auto it3 = std::find(myList.begin(), myList.end(), 50);
    if (it3 != myList.end())
    {
        *it3 = 45;
    }

    cout << "\nAfter Replacing: ";
    for (int i : myList)
    {
        cout << i << " ";
    }
    cout << endl;

    // Printing using *it:
    cout << "\nPrinting using *it: ";
    for (auto it4 = myList.begin(); it4 != myList.end(); ++it4)
    {
        cout << *it4 << " ";
    }
    cout << endl;
}
