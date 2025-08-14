//Ex : 6 Create a C++ program for Couning number of digits using TreeMap

#include <iostream>
#include <map>
 
void countDigits(int number) {
    std::map<int, int> digitCount;
 
    // Process each digit of the number
    while (number != 0) {
        int digit = number % 10;
        digitCount[digit]++;
        number /= 10;
    }
 
    // Display the count of each digit
    std::cout << "Digit counts:" << std::endl;
    for (const auto& pair : digitCount) {
        std::cout << "Digit: " << pair.first << ", Count: " << pair.second << std::endl;
    }
}
 
int main() {
    int number;
 
    std::cout << "Enter a number: ";
    std::cin >> number;
 
    countDigits(number);
 
    return 0;
} 