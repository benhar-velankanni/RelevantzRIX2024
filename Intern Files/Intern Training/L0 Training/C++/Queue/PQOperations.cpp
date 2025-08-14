// Ex : 5	Write a C++ program to insert a given element into a priority queue.
// Ex : 6	Write a C++ program to remove all elements from a priority queue.
// Ex : 7	Write a C++ program to count the number of elements in a priority queue.
// Ex : 8	Write a C++ program to iterate through all elements in the priority queue.

#include <iostream>
#include <queue>
#include <functional> //To use std::greater (descending.)

using namespace std;

priority_queue<int> removeAll(priority_queue<int> pq)
{
    while (!pq.empty())
    {
        pq.pop();
    }
    return pq;
}

int countElements(priority_queue<int> pq)
{
    int count = 0;
    priority_queue<int> copy = pq;
    while (!copy.empty())
    {
        count++;
        copy.pop();
    }

    return count;
}

int main()
{
    priority_queue<int> dpq;

    int n;
    int value;

    cout << "\nEnter the number of elements: ";
    cin >> n;

    cout << "\nEnter the elements: ";
    for (int i = 0; i < n; i++)
    {
        cin >> value;
        dpq.push(value);
    }

    priority_queue<int> copy = dpq;
    cout << "\nDescending Priority Queue: ";
    while (!copy.empty())
    {
        cout << copy.top() << ' ';
        copy.pop();
    }
    cout << endl;

    int count = countElements(dpq);
    cout << "\nThe number of elements in the priority queue (before removal): " << count << "." << endl;

    dpq = removeAll(dpq);

    cout << "\nDescending Priority Queue after removal: ";
    while (!dpq.empty())
    {
        cout << dpq.top() << ' ';
        dpq.pop();
    }
    cout << endl;

    count = countElements(dpq);
    cout << "\nThe number of elements in the priority queue (after removal): " << count << "." << endl;
}