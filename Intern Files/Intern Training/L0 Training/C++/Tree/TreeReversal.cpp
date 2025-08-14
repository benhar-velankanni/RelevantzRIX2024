//Ex : 4	Create a C++ program to print TreeSet with reverse order

#include <stdio.h>
#include <set>
#include <iostream>
using namespace std;
main()
{
    std::set<int> Tree;
    Tree.insert(1);
    Tree.insert(2);
    Tree.insert(3);
    Tree.insert(4);
    cout << "before reverse the tree (sorted ascending)\n";
    for (int x : Tree)
    {
        cout << x << " ";
    }
    set<int>::reverse_iterator rev;
    cout << "\nAfter reverse the tree (sorted decending)\n";
    for (rev = Tree.rbegin(); rev != Tree.rend(); rev++)
    {
        cout << *rev << " ";
    }
}