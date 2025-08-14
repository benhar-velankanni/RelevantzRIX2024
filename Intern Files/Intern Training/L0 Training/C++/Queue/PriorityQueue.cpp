//Ex : 4	Develop a C++ program to perform Priority Queue Operations [Ascending & Descending].

#include <iostream>
#include <queue>
#include <functional> //To use std::greater (descending.)

using namespace std;

// driver code
int main()
{
    int arr[6] = { 10, 2, 4, 8, 6, 9 };

    // defining priority queue
    priority_queue<int, deque<int>, greater<int>> apq;
    priority_queue<int> dpq;

    // printing array
    cout << "Array: ";
    for (auto i : arr) {
        cout << i << ' ';
    }
    cout << endl;

    // pushing array sequentially one by one
    for (int i = 0; i < 6; i++) {
        apq.push(arr[i]);
    }

    // printing priority queue  
    cout << "\nAscending Priority Queue: ";
    while (!apq.empty()) {
        cout << apq.top() << ' ';
        apq.pop();
    }
    cout<< endl;

    // pushing array sequentially one by one
    for (int i = 0; i < 6; i++) {
        dpq.push(arr[i]);
    }

    // printing priority queue  
    cout << "\nDescending Priority Queue: ";
    while (!dpq.empty()) {
        cout << dpq.top() << ' ';
        dpq.pop();
    }
    cout<< endl;

    return 0;
}