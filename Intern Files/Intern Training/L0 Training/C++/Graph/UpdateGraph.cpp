//Ex : 5	Create a C++ program for Inserting and Updaing Elements in TreeMap

#include <iostream>
#include <map>
#include <string>
 
void printMap(const std::map<int, std::string>& treeMap) {
    for (const auto& pair : treeMap) {
        std::cout << "Key: " << pair.first << ", Value: " << pair.second << std::endl;
    }
}
 
int main() {
    // Creating a TreeMap (std::map)
    std::map<int, std::string> treeMap;
 
    // Inserting elements
    treeMap[1] = "One";
    treeMap[2] = "Two";
    treeMap[3] = "Three";
 
    // Updating elements
    treeMap[2] = "Updated Two"; // Update value for key 2
 
    // Printing TreeMap
    std::cout << "TreeMap elements after insertion and update:" << std::endl;
    printMap(treeMap);
 
    return 0;
}