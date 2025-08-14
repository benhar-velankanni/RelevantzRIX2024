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

    // Printing the stored data:
    void display()
    {
        Node *temp = head;
        while (temp != nullptr)
        {
            std::cout << temp->data << " -> ";
            temp = temp->next;
        }
        cout << endl;
    }

    void reversal()
    {
        Node *curr = head;
        Node *prev = NULL;
        Node *next = curr->next;
        while (curr != NULL)
        {
            // Store next
            next = curr->next;

            // Reverse current node's next pointer
            curr->next = prev;

            // Move pointers one position ahead
            prev = curr;
            curr = next;
        }

        // Return the head of reversed linked list
        head = prev;
    }
};

int main()
{
    linkedList myList;
    myList.insertAtBegining(20);
    myList.insertAtBegining(10);
    myList.insertAtEnd(30);
    myList.insertAtEnd(40);

    cout << "After insertions: ";
    myList.display();
    cout << endl;

    myList.reversal();

    cout << "After reversal: ";
    myList.display();
    cout << endl;
    return 0;
}