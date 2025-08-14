//Ex : 1	Develop a C++ program to perform the following operations: Insert, Remove , Peek and Searching in Queue.

#include <iostream>
#include <queue>
#include <string>

using namespace std;

int main()
{
    queue<string> myQueue;

    myQueue.push("Alpha");
    myQueue.push("Bravo");
    myQueue.push("Charlie");
    myQueue.push("Delta");
    myQueue.push("Echo");
    myQueue.push("Foxtort");   

    cout << "Queue elements: " << endl;
    queue<string> tempQueue = myQueue;
    while (!tempQueue.empty())
    {
        cout << tempQueue.front() << " ";
        tempQueue.pop();
    }
    cout << endl;

    if (!myQueue.empty())
    {
        cout << "\nRemoving element once: " << myQueue.front() << endl;
        myQueue.pop();
    }
    else
    {
        cout << "\nQueue is empty, insert a few elements first!." << endl;
    }

    cout << "\nQueue elements after removal: " << endl;
    tempQueue = myQueue;
    while (!tempQueue.empty())
    {
        cout << tempQueue.front() << " ";
        tempQueue.pop();
    }
    cout << endl;

    //Ex : 3	Develop a C++ program for Searching element from the Queue.
    // Searh:
    string searchElement = "Bravo";
    bool found = false;

    tempQueue = myQueue;
    while (!tempQueue.empty())
    {
        if (tempQueue.front() == searchElement)
        {
            found = true;
            break;
        }
        tempQueue.pop();
    }

    if (found)
    {
        cout << "\nThe string, " << searchElement << " is present in the queue." << endl;
    }
    else
    {
        cout << "\nThe element is not present in the queue." << endl;
    }
}