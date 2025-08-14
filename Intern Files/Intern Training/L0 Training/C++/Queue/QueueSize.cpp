//Ex : 2	Develop a C++ program for Finding the Queue size without using size().

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

    tempQueue = myQueue;
    int size = 0;
    while(!tempQueue.empty()){
        size++;
        tempQueue.pop();
    }

    cout<<"\nThe size of the queue: "<< size<< endl;
}