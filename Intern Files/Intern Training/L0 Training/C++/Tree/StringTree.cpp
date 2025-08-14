//Ex : 2	Create a C++ program for Inserting String elements into the TreeSet

#include <stdio.h>
#include <set>
#include <iostream>
#include <string>
using namespace std;
main()
{
    std::set<string> Tree;
    Tree.insert("Bone");
    Tree.insert("Muscle");
    Tree.insert("Skin");
    // display the string elements
    for (string element : Tree)
    {
        cout << element << " ";
    }
}