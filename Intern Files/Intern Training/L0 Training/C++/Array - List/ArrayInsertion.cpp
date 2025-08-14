#include <iostream>
#include <array>

using namespace std;

const int MAX_SIZE = 100;

void insertElement(int arr[], int &n, int pos, int value){
    //Checking if the position is valid;
    if(pos < 0 || pos > n){
        cout <<"Invalid Position"<< endl;
        return;
    }

    //Checking if array is full:
    if(n == MAX_SIZE){
        cout <<"Array is full!"<< endl;
        return;
    }

    //Shifting values from the "pos" index, one to the right:
    for(int i = n-1; i >= pos; i--){
        arr[i+1] = arr[i];
    }

    //Inserting value and updating "n" value:
    arr[pos] = value;
    n++;
    return;
}
int main(){
    //Array decleration and definition:
    int arr[MAX_SIZE];
    int n;
    cout<< "Enter the array size: ";
    std::cin>> n;
    cout<< endl;

    cout<< "Enter the array elements: ";
    for(int i = 0; i < n; i++){
        cin>> arr[i];
    }

    //Print array:
    cout<< "The original array:";
    for(int i = 0; i < n; i++){
        cout<< arr[i] << ", ";
    }
    cout<< endl;

    //Value and position to insert:
    int pos = 4;
    int value = 70;

    //Call Function for Insert:
    insertElement(arr, n, pos, value);

    //Print array:
    cout<< "The newly modded array:";
    for(int i = 0; i < n; i++){
        cout<< arr[i] << ", ";
    }
    cout<< endl;

}
