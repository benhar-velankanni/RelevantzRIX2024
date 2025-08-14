//Ex : 7	Create a C++ program for Removing elements from TreeMap

#include<stdio.h>
#include<map>
#include<iostream>
#include<string>
using namespace std;
void printMap(const std::map<int,std::string>&treeMap){
    for(const auto& pair:treeMap){
        std::cout << "Key: " << pair.first << ", Value: " << pair.second << std::endl;
    }
}
main(){
    // Creating a TreeMap (std::map)
    std::map<int, std::string> treeMap;
 
    // Inserting elements
    treeMap[1] = "One";
    treeMap[2] = "Two";
    treeMap[3] = "Three";
 
    // Removing elements
    int keyToRemove;
    std::cout << "Enter the key of the element to remove: ";
    std::cin >> keyToRemove;
 
    auto it = treeMap.find(keyToRemove);
    if (it != treeMap.end()) {
        treeMap.erase(it);
        std::cout << "Element with key " << keyToRemove << " removed." << std::endl;
    } else {
        std::cout << "Key " << keyToRemove << " not found." << std::endl;
    }
}