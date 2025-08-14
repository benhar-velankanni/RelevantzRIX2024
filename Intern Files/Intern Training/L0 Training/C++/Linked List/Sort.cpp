#include <iostream>
using namespace std;

// Definition for singly-linked list node
struct ListNode {
    int val;
    ListNode *next;
    ListNode(int x){
        this->val = x;
        this->next = NULL;
    }
};

// Function to insert node at the beginning of linked list
void push(ListNode** head_ref, int new_data) {
    ListNode* new_node = new ListNode(new_data);
    new_node->next = (*head_ref);
    (*head_ref) = new_node;
}

// Function to print the linked list
void printList(ListNode *node) {
    while (node != NULL) {
        cout << node->val << " ";
        node = node->next;
    }
}

// Function to bubble sort the linked list
void bubbleSort(ListNode* head) {
    bool swapped;
    ListNode *ptr1;

    if (head == NULL)
        return;

    do {
        swapped = false;
        ptr1 = head;

        while (ptr1->next != NULL) {
            if (ptr1->val > ptr1->next->val) {
                int temp = ptr1->val;
                ptr1->val = ptr1->next->val;
                ptr1->next->val = temp;
                swapped = true;
            }
            ptr1 = ptr1->next;
        }
    } while (swapped);
}

int main() {
    ListNode* head = NULL;

    push(&head, 10);
    push(&head, 15);
    push(&head, 5);
    push(&head, 20);
    push(&head, 3);

    cout << "Linked List before sorting: \n";
    printList(head);

    bubbleSort(head);

    cout << "\nLinked List after sorting: \n";
    printList(head);

    return 0;
}
