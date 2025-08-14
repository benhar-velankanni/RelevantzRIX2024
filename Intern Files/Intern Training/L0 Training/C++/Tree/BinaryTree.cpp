#include<stdio.h>
#include<stdexcept>
#include<set>
#include<iostream>
using namespace std;
template <typename T>
class BinaryTree{
    private:
        struct Node{
            T data;
            Node* left;
            Node* right;
            Node (const T& val):data(val),left(nullptr),right(nullptr){}
        };
Node* root;

    Node* insertRecursive(Node* node,const T& value){
        if(node==nullptr){
            return new Node(value);

        }
        if(value<node->data){
            node->left=insertRecursive(node->left,value);
        }
        else if(value>node->data){
            node->right=insertRecursive(node->right,value);
        }
        return node;
    }
    void preorderRecursive(Node* node)const{
        if(node==nullptr){
            return;
        }
        std::cout<<node->data<<" ";
        preorderRecursive(node->left);
        preorderRecursive(node->right);
        std::cout<<node->data<<" ";
    }
    void postorderRecursive(Node* node)const{
        if(node==nullptr){
            return;
        }
        postorderRecursive(node->left);
        postorderRecursive(node->right);
        std::cout<<node->data<<" ";

    }
    public:
        BinaryTree():root(nullptr){}
        ~BinaryTree(){
            clearRecursive(root);
        }
        void insert(const T& value){
            root=insertRecursive(root,value);
        }
        void preorder()const{
            preorderRecursive(root);
            std::cout<<std::endl;
        }
        void postorder()const{
            postorderRecursive(root);
            std::cout<<std::endl;
        }
};

int main(){
    BinaryTree<int>tree;
    tree.insert(50);
    tree.insert(40);
    tree.insert(50);
    tree.insert(60);
    tree.insert(70);
    cout<<"preorder traversal ";
    tree.preorder();
    cout<<"postorder traversal ";
    tree.postorder(); 

}