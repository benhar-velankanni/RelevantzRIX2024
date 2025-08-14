// Ex : 4	Write a C++ program to implement Binary Search Using LinkedList.

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

    // Function to find out middle element:
    Node *middle(Node *start, Node *last)
    {
        if (start == NULL)
        {
            return NULL;
        }

        if (start == last)
            return start;

        Node *slow = start;
        Node *fast = start->next;

        while (fast != last)
        {
            fast = fast->next;
            slow = slow->next;
            if (fast != last)
            {
                fast = fast->next;
            }
        }

        return slow;
    }

    void binarySearch(string &value)
    {
        Node *start = head;
        Node *last = NULL;
        bool found = false;
        std::transform(value.begin(), value.end(), value.begin(), ::tolower);

        while (true)
        {
            // Finding middle
            Node *mid = middle(start, last);
            string temp = mid->data;
            std::transform(temp.begin(), temp.end(), temp.begin(), ::tolower);

            // If middle is empty:
            if (mid == NULL)
            {
                break;
            }

            if (temp == value)
            {
                found = true;
                break;
            }
            else if (start == last)
            {
                break;
            }
            else if (temp < value)
            {
                start = mid->next;
            }
            else if (temp > value)
            {
                last = mid;
            }
        }

        if (found)
        {
            cout << "\nThe element '" << value << "' is found." << endl;
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
    myList.insertAtEnd("Alpha");
    myList.insertAtEnd("Beta");
    myList.insertAtEnd("Gamma");
    myList.insertAtEnd("Echo");
    myList.insertAtEnd("Charlie");

    cout << "After insertions: ";
    myList.display();
    cout << endl;

    string value;
    cout << "\nEnter the string to search for in the linked list: ";
    cin >> value;
    cout << endl;

    myList.binarySearch(value);
}