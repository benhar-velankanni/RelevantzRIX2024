//Ex : 8	Create a C++ program to find Sum of Singly Linkedlist.

#include <iostream>
#include <string>

using namespace std;

struct Node
{
    int data;
    Node *next;
};

class linkedList
{
private:
    Node *head;

public:
    linkedList()
    {
        head = nullptr;
    }

    void insertAtBegining(int data)
    {
        Node *newNode = new Node; // Create a new node.
        newNode->data = data;     // Adding the data.
        newNode->next = head;     // Pointing towards the existinghead node.
        head = newNode;
    }

    // Insertion at the end:
    void insertAtEnd(int data)
    {
        Node *newNode = new Node;
        newNode->data = data;
        newNode->next = nullptr;

        if (head == nullptr)
        {
            head = newNode; // If no head is present, the newNomde is set as the head.
            return;
        }

        Node *temp = head;
        while (temp->next != nullptr)
        {
            temp = temp->next;
        }
        temp->next = newNode; // Linking th elast node to the first.
    }

    void sumOfElements()
    {
        Node *temp = head;
        int sum = 0;
        while (temp != nullptr)
        {
            sum += temp->data;
            temp = temp -> next;
        }
        cout << "\nThe sum of the array elements is: " << sum << "." << endl;
    }
};

int main()
{
    linkedList myList;
    myList.insertAtBegining(10);
    myList.insertAtBegining(20);
    myList.insertAtBegining(30);
    myList.insertAtBegining(40);
    myList.sumOfElements();
}