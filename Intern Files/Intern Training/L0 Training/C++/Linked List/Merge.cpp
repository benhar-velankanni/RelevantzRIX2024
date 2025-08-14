//Ex : 2	Create a C++ Merge two sorted Linkedlist


#include <bits/stdc++.h>
using namespace std;

class Node
{
public:
    int data;
    Node *next;
    Node(int key)
    {
        this->data = key;
        this->next = NULL;
    }
};

Node *mergeInPlace(Node *h1, Node *h2)
{

    // Return NULL when both of the linked list are empty
    if (!h1 && !h2)
        return NULL;

    // If one list ends, returns the remaining one.
    if (!h1)
        return h2;
    if (!h2)
        return h1;

    // Return and set the next pointer of the smaller node
    if (h1->data < h2->data)
    {
        h1->next = mergeInPlace(h1->next, h2);
        return h1;
    }
    else
    {
        h2->next = mergeInPlace(h1, h2->next);
        return h2;
    }
}

int main()
{

    // First Linked List: 1 -> 3 -> 5
    Node *list1 = new Node(1);
    list1->next = new Node(3);
    list1->next->next = new Node(5);

    // Second Linked List: 0 ->2 -> 4
    Node *list2 = new Node(0);
    list2->next = new Node(2);
    list2->next->next = new Node(4);

    Node *result = mergeInPlace(list1, list2);

    // Printing the resultant list
    Node *temp = result;
    while (temp != NULL)
    {
        printf("%d  ", temp->data);
        temp = temp->next;
    }
    return 0;
}