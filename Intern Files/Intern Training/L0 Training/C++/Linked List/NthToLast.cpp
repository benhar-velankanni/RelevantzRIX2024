//Ex : 7	Create a C++ Delete nth element from headnode.

//Ex : 3	Create a C++ Singly LinkedList Traversal

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

    void nThToLast(){
        int pos;
        cout<<"\nEnter the Nth position: ";
        cin>> pos;
        cout<< endl;

        Node* temp = head;
        int n = 0;

        while(temp -> next != nullptr){
            n++;
            temp = temp -> next;
        }

        if(pos > n){
            cout<<"ERROR: Out of bounds!"<< endl;
            return;
        }

        temp = head;
        for(int i = 0; i <= n-pos; i++){
            temp = temp -> next;
        }

        cout<< "The Nth to last element: ";
        while (temp != nullptr)
        {
            std::cout << temp->data << " -> ";
            temp = temp->next;
        }
        cout << endl;

    }
};

int main()
{
    linkedList myList;
    myList.insertAtBegining(10);
    myList.insertAtBegining(20);
    myList.insertAtBegining(30);
    myList.insertAtBegining(40);
    myList.insertAtBegining(50);
    myList.insertAtBegining(60);
    myList.insertAtBegining(70);
    myList.insertAtBegining(80);
    myList.insertAtBegining(90);
    myList.insertAtBegining(100);

    cout << "After insertions: ";
    myList.display();
    cout << endl;
    
    myList.nThToLast();
    return 0;
}