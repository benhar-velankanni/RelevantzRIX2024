// Ex : 2	Write a C++ program to implement Linear Search using LinkedList (String).

#include <iostream>
#include <string>
#include <algorithm>

using namespace std;

struct Node
{
    string data;
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

    void insertAtBegining(string data)
    {
        Node *newNode = new Node; // Create a new node.
        newNode->data = data;     // Adding the data.
        newNode->next = head;     // Pointing towards the existinghead node.
        head = newNode;
    }

    // Insertion at the end:
    void insertAtEnd(string data)
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

    void linearSearch(string &value)
    {
        Node *temp = head;
        bool found = false;
        std::transform(value.begin(), value.end(), value.begin(), ::tolower);

        while (temp != nullptr)
        {
            string temp2 = temp->data;
            std::transform(temp2.begin(), temp2.end(), temp2.begin(), ::tolower);
            if (temp2 == value)
            {
                found = true;
                break;
            }
            temp = temp->next;
        }

        if (found)
        {
            cout << "\nThe element '" << value << "' is found."<< endl;
        }
        else
        {
            cout << "\nThe element '" << value << "' is not found within the array." << endl;
        }
    }
};

int main()
{
    linkedList myList;
    myList.insertAtBegining("Alpha");
    myList.insertAtBegining("Beta");
    myList.insertAtBegining("Gamma");
    myList.insertAtBegining("Echo");
    myList.insertAtBegining("Charlie");

    cout << "After insertions: ";
    myList.display();
    cout << endl;

    string value;
    cout << "\nEnter the string to search for in the linked list: ";
    cin >> value;
    cout << endl;

    myList.linearSearch(value);
}