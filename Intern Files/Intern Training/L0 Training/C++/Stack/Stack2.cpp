// Ex : 3	Create a C++ program for Searching the element from the Stack.

#include <iostream>
#include <stack>
#include <stdexcept>

using namespace std;

template <typename T>
class myStack
{
private:
    std::stack<T> s;
    int capacity;

public:
    myStack(int size = -1) : capacity(size) {}

    void pushValue(const T &value)
    {
        if (isFull())
        {
            throw std::overflow_error("Stack is full. Cannot push value.");
        }
        s.push(value);
    }

    bool isEmpty()
    {
        return s.empty();
    }

    bool isFull()
    {
        if (capacity == -1)
            return false;
        return s.size() == capacity;
    }

    void display()
    {
        if (isEmpty())
        {
            std::cout << "\nStack is empty" << std::endl;
            return;
        }
        std::stack<T> copy = s; // Create a copy for display.

        // Ex : 5	Create a C++ program for Reversing the Stack.
        std::stack<T> reversed;

        while (!copy.empty())
        {
            reversed.push(copy.top());
            copy.pop();
        }

        while (!reversed.empty())
        {
            std::cout << reversed.top() << " ";
            reversed.pop();
        }
        std::cout << std::endl;
    }

    void popValue()
    {
        if (isEmpty())
        {
            throw std::underflow_error("Stack is Empty. Cannot Pop!");
        }
        s.pop();
    }

    void search()
    {
        if (isEmpty())
        {
            std::cout << "\nStack is empty" << std::endl;
            return;
        }

        cout << "\nEnter the value to search: ";
        int value;
        cin >> value;
        cout << endl;

        std::stack<T> copy = s;
        std::stack<T> reversed;

        while (!copy.empty())
        {
            reversed.push(copy.top());
            copy.pop();
        }
        int index = -1;
        bool found = false;
        while (!reversed.empty())
        {
            if (reversed.top() == value)
            {
                index++;
                found = true;
                break;
            }
            index++;
            reversed.pop();
        }

        if (found)
        {
            cout << "\nThe element " << value << " is present in the stack at " << index << " index position." << endl;
        }
        else
        {
            cout << "\nThe element " << value << " is not in the stack." << endl;
        }
    }

    // Ex : 2	Create a C++ program for Finding the size of the Stack with out using size() method.
    void sizeOfStack()
    {
        int size = 0;
        std::stack<T> copy = s;
        while (!copy.empty())
        {
            size++;
            copy.pop();
        }

        cout << "\nThe size of the stack is: " << size << "." << endl;
    }
};

int main()
{
    myStack<int> myStack(5);
    myStack.pushValue(10);
    myStack.pushValue(20);
    myStack.pushValue(30);
    myStack.pushValue(40);

    std::cout << "\nStack: ";
    myStack.display();

    myStack.search();

    myStack.sizeOfStack();
}