// Ex : 4	Write a C++ program to implement Selection Sort using LinkedList

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

    void selectionSort()
    {
        for (Node *i = head; i && i->next; i = i->next)
        {
            Node *minNode = i;
            for (Node *j = i->next; j; j = j->next)
            {
                if (j->data < minNode->data)
                    minNode = j;
            }
            swap(i->data, minNode->data);
        }
    }

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

    list.selectionSort();

    cout << "\nAfter Sorting: ";
    list.print();

    return 0;
}
