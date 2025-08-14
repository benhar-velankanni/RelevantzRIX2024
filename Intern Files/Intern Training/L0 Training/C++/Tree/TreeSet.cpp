#include <iostream>
#include <set> // for std :: set.

int main()
{

    std::set<int> myTreeset;

    // Creates a Treeset (elements are sorted and unique)
    // Inserting elements
    myTreeset.insert(1);
    myTreeset.insert(2);
    myTreeset.insert(3);
    myTreeset.insert(4);
    myTreeset.insert(5);
    myTreeset.insert(2); // Duplicate element - will not be inserted
    myTreeset.insert(6);

    // Iterating and printing elements (elements are printed in sorted order)
    std::cout << "\nElements in the Treeset (sorted order) :\n";
    for (int element : myTreeset)
    {
        std::cout << element << " ";
    }
    std ::cout << std ::endl;

    // Checking if an element exist in tree
    if (myTreeset.count(4))
    {
        std::cout << "\n4 exists in the tree\n";
    }
    if (myTreeset.count(55))
    {
        std::cout << "\n55 exist in the tree\n";
    }
    else
    {
        std::cout << "\n55 does not exist in the tree\n";
    }

    // Erasing elements
    myTreeset.erase(3);
    std::cout << "\nElements in the Treeset after erasing 3: \n";
    for (int element : myTreeset)
    {
        std::cout << element << " ";
    }
    std ::cout << std ::endl;

    // Finding an element (return an Iterator to the element)
    int b;
    std::cout << "\nEnter the element to be found:";
    std::cin >> b;
    auto it = myTreeset.find(b);

    if (it != myTreeset.end())
    {
        std::cout << "\nThe element " << *it << " is found\n";
    }

    // size of the set
    std::cout << "\nSize of the tree:" << myTreeset.size() << "\n";
    std::cout << std::endl;
    // clear the set
    myTreeset.clear();

    std::cout << "\nSize of the tree after clearing:" << myTreeset.size() << "\n";
    std::cout << std::endl;
}