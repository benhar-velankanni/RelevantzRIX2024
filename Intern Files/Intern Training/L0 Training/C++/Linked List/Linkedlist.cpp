#include <iostream>
#include <string>

using namespace std;

struct Node
{
    int data;
    Node *next; // Pointer to the next node.
};

class linkedList
{
private:
    Node *head; // Pointer to the first node.

public:
    linkedList()
    {
        head = nullptr; // Initializing empty lined list.
    }

    // Insertion at the begining:
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

    // Deletion from start:
    void deleteAtBegin()
    {
        if (head == nullptr)
        {
            return; // List is empty
        }
        
        Node *temp = head;
        head = head->next; // Relocate head node.
        delete temp;       // Delete the previous head.
    }

    // Deletion from end:
    void deleteAtEnd()
    {
        if (head == nullptr)
        {
            return; // List is empty
        }

        if (head->next == nullptr)
        {
            delete head; // Single element list.
            head = nullptr;
            return;
        }

        Node *temp = head;
        while (temp->next->next != nullptr)
        {
            temp = temp->next;
        }
        delete temp->next;
        temp->next = nullptr;
        return;
    }

    // Removal of Duplicates:
    void removeDuplicates()
    {
        if (head == nullptr || head->next == nullptr)
        {
            return; // List is empty or Single element list.
        }

        Node *lag = head;
        Node *lead = head->next;

        while (lead != nullptr)
        {
            if (lag->data == lead->data)
            {
                lag->next = lead->next;
                delete lead;      // Delete Duplicate.
                lead = lag->next; // Important update lead after deletion.
            }
            else
            {
                lag = lead;
                lead = lead->next;
            }
        }
    }

    // Deletion all nodes from the head:
    void deleteAll()
    {
        Node *current = head;
        while (current != nullptr)
        {
            Node *next = current->next; // Pointing to the next non-empty node.
            delete current;             // Deleting current node.
            current = next;             // Updating current to next non-empty node.
        }
        head = nullptr;
        return;
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

    myList.deleteAtBegin();
    cout << "\nAfter deletion from front: ";
    myList.display();
    cout << endl;

    myList.deleteAtEnd();
    cout << "\nAfter deletion from end: ";
    myList.display();
    cout << endl;

    // Duplicates:
    myList.insertAtBegining(10);
    myList.insertAtBegining(10);
    myList.insertAtEnd(40);
    myList.insertAtEnd(40);

    cout << "\nAfter duplicate insertions: ";
    myList.display();
    cout << endl;

    myList.removeDuplicates();
    cout << "\nAfter removal of duplicates: ";
    myList.display();
    cout << endl;

    myList.deleteAll();
    cout << "\nAfter complete deletion: (i.e, The linked list is empty.)";
    myList.display();
    cout << endl;

    return 0;
}