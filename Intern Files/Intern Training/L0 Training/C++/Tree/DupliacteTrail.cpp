//Ex : 3	Create a C++ program for Adding Duplicate values to TreeSet [Checking]

#include <stdio.h>
#include <set>
#include <iostream>
using namespace std;
main()
{
    std::set<int> tree;
    tree.insert(1);
    tree.insert(2);
    tree.insert(3);
    tree.insert(4);

    // trying to insert duplicate elements
    tree.insert(4);
    for (int ele : tree)
    {
        cout << ele << " ";
    }
}