#include <iostream>
#include <stack>
#include <stdexcept>

using namespace std;

template <typename T>
class myStack
{
private:
    std::stack<T> s;
    int capacity; // Maximum capacity of the stack.

public:
    myStack(int size = -1) : capacity(size) {} // Constructor with optional size.

    //Ex : 1	Create a C++ Insert and Remove elements using Stack
    void pushValue(const T &value)
    {
        if (isFull())
        {
            throw std::overflow_error("Stack is full. Cannot push value.");
        }
        s.push(value);
    }

    //Ex : 6	Create a C++ program for performing isEmpty,size operations in stack
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

    void popValue(){
        if(isEmpty()){
            throw std::underflow_error("Stack is Empty. Cannot Pop!");
        }
        s.pop();
    }
};

int main()
{
    myStack<int> myStack(100);
    myStack.pushValue(567);
    myStack.pushValue(34);
    myStack.pushValue(12);
    myStack.pushValue(20);

    std::cout << "\nStack: ";
    myStack.display();

    std::cout << "\nStack after pop: ";
    myStack.popValue();
    myStack.display();
}