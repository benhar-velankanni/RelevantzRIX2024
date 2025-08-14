// Ex : 2	Write a C++ program to implement Bubble Sort using LinkedList

#include <iostream>
using namespace std;

struct Node
{
    int data;
    Node *next;
};

class LinkedList
{
public:
    Node *head;

    LinkedList()
    {
        head = nullptr;
    }

    void insert(int val)
    {
        Node *newNode = new Node{val, nullptr};
        if (!head)
        {
            head = newNode;
            return;
        }
        Node *temp = head;
        while (temp->next)
            temp = temp->next;
        temp->next = newNode;
    }

    // Bubble Sort for Linked List
    void bubbleSort()
    {
        if (!head || !head->next)
            return;

        bool swapped;
        Node *temp;
        do
        {
            swapped = false;
            temp = head;
            while (temp->next)
            {
                if (temp->data > temp->next->data)
                {
                    swap(temp->data, temp->next->data);
                    swapped = true;
                }
                temp = temp->next;
            }
        } while (swapped);
    }

    // Print the list
    void print()
    {
        Node *temp = head;
        while (temp)
        {
            cout << temp->data << " -> ";
            temp = temp->next;
        }
    }
};

int main()
{
    LinkedList list;
    list.insert(5);
    list.insert(3);
    list.insert(8);
    list.insert(1);
    list.insert(7);

    cout << "\nBefore Sorting: ";
    list.print();

    list.bubbleSort();

    cout << "\nAfter Sorting: ";
    list.print();

    return 0;
}