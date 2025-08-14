//Ex : 8 Develop a C++ program for Creating factorial table using TreeMap

#include <iostream>
#include <map>
 
// Function to calculate factorial
long long factorial(int n) {
    long long fact = 1;
    for (int i = 1; i <= n; ++i) {
        fact *= i;
    }
    return fact;
}
 
// Function to print the factorial table
void printFactorialTable(const std::map<int, long long>& factorialMap) {
    std::cout << "Factorial Table:" << std::endl;
    for (const auto& pair : factorialMap) {
        std::cout << pair.first << "! = " << pair.second << std::endl;
    }
}
 
int main() {
    // Creating a TreeMap (std::map)
    std::map<int, long long> factorialMap;
   
    // Number of entries in the table
    int numEntries;
 
    std::cout << "Enter the number of entries in the factorial table: ";
    std::cin >> numEntries;
 
    // Inserting factorials into the map
    for (int i = 0; i <= numEntries; ++i) {
        factorialMap[i] = factorial(i);
    }
 
    // Printing the factorial table
    printFactorialTable(factorialMap);
 
    return 0;
}