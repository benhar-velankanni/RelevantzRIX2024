#include <iostream>
using namespace std;

// Definition for singly-linked list node
struct ListNode {
    int val;
    ListNode *next;
    ListNode(int x) : val(x), next(NULL) {}
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

// Function to remove duplicates from a sorted linked list
void removeDuplicates(ListNode* head) {
    ListNode* current = head;
    ListNode* lead;

    while(current->next != nullptr){
        lead = current->next;
        while(lead->next != nullptr){
            if(lead->val == current->val){
            current->next = lead->next;
            delete(lead);
            lead = current->next;
            }
            else{
                lead = lead->next;
            }
        }
        current = current->next;
    }
}

// Function to merge two sorted linked lists
ListNode* sortedMerge(ListNode* a, ListNode* b) {
    if (!a) return b;
    if (!b) return a;

    if (a->val <= b->val) {
        a->next = sortedMerge(a->next, b);
        return a;
    } else {
        b->next = sortedMerge(a, b->next);
        return b;
    }
}

// Function to split the linked list into two halves
void frontBackSplit(ListNode* source, ListNode** frontRef, ListNode** backRef) {
    ListNode* fast;
    ListNode* slow;
    slow = source;
    fast = source->next;

    while (fast != NULL) {
        fast = fast->next;
        if (fast != NULL) {
            slow = slow->next;
            fast = fast->next;
        }
    }

    *frontRef = source;
    *backRef = slow->next;
    slow->next = NULL;
}

// Function to sort the linked list using Merge Sort
void mergeSort(ListNode** headRef) {
    ListNode* head = *headRef;
    ListNode* a;
    ListNode* b;

    if ((head == NULL) || (head->next == NULL)) {
        return;
    }

    frontBackSplit(head, &a, &b);
    mergeSort(&a);
    mergeSort(&b);

    *headRef = sortedMerge(a, b);
}

int main() {
    ListNode* res = NULL;
    ListNode* a = NULL;

    push(&a, 10);
    push(&a, 15);
    push(&a, 20);
    push(&a, 15);
    push(&a, 10);

    cout << "Linked List before sorting and removing duplicates: \n";
    printList(a);

    mergeSort(&a);
    removeDuplicates(a);

    cout << "\nLinked List after sorting and removing duplicates: \n";
    printList(a);

    return 0;
}
