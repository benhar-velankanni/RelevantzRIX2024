// Ex : 3	Create a C++ program for Searching the element from the Stack

#include <iostream>
#include <stack>
#include <string>

using namespace std;
template <typename T>
bool searchstack(std::stack<T> s, T key)
{

    while (!s.empty())
    {
        if (s.top() == key)
        {
            return true;
        }
        s.pop();
    }
    return false;
}
int main()
{
    std::stack<std::string> mystack;
    mystack.push("jth");
    mystack.push("vishwa");
    mystack.push("balaji");
    mystack.push("mukesh");
    mystack.push("nitis");

    std::string searchkey = "mukesh";
    if (searchstack(mystack, searchkey))
    {
        cout << "The element " << searchkey << " is found in the stack";
    }
    else
    {
        cout << "The element" << searchkey << " is not found in the stack";
    }
    return 0;
}