// Ex : 4	Create a C++ Circular Singly Linked List

#include <iostream>
#include <string>

using namespace std;

struct Node
{
    int data;
    Node *next;
};

class circularList
{
private:
    Node *head;

public:
    circularList()
    {
        head = nullptr;
    }

    void insertAtBegining(int data)
    {
        Node *newNode = new Node;
        newNode->data = data;
        newNode->next = nullptr;

        if (head == nullptr)
        {
            head = newNode;
            head->next = head;
            return;
        }
        else
        {
            Node *temp = head;
            while (temp->next != head)
            {
                temp = temp->next;
            }
            newNode->next = head;
            temp->next = newNode;
            head = newNode;
            return;
        }
    }

    // Insertion at the end:
    void insertAtEnd(int data)
    {
        Node *newNode = new Node;
        newNode->data = data;
        newNode->next = nullptr;

        if (head == nullptr)
        {
            head = newNode;
            head->next = head; // If no head is present, the newNomde is set as the head.
            return;
        }
        else
        {
            Node *temp = head;
            while (temp->next != head)
            {
                temp = temp->next;
            }
            temp->next = newNode;
            newNode->next = head;
            return;
        }
    }

    // Printing the stored data:
    void display()
    {
        Node *temp = head;
        do
        {
            cout << temp->data << " -> ";
            temp = temp->next;
        } while (temp != head);
        cout << endl;
    }
};

int main()
{
    circularList myList;
    myList.insertAtBegining(20);
    myList.insertAtBegining(10);
    myList.insertAtEnd(40);
    myList.insertAtEnd(40);
    myList.insertAtEnd(40);

    cout << "After insertions: ";
    myList.display();
    cout << endl;
    return 0;
}