#include <iostream>

using namespace std;

void bubbleSort(int arr[], int &size){
    for(int i = 0 ; i < size - 1 ; i++){
        for(int j = 0; j< size - 1; j++){
            if(arr[j] > arr[j+1]){
                int temp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = temp;
            }
        }
    }
}

int main(){
    int arr[] = {45, 34, 67, 23, 98, 54, 9, 12};
    int size = sizeof(arr) / sizeof(arr[0]);

    cout<<"\nUnsorted array:";
    for(int x: arr){
        cout<< x << ", ";
    }
    cout<< endl;

    bubbleSort(arr, size);

    cout<<"\nSorted array:";
    for(int x: arr){
        cout<< x << ", ";
    }
    cout<< endl;
}