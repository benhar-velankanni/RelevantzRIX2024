#include <iostream>
#include <string>

using namespace std;

struct Student
{
    string name;
    int rollno;
    double marks;
};

int main()
{
    // Creating a Student Arrary:
    int n;
    cout << "Enter the number of students: ";
    cin >> n;
    cout << endl;
    Student students[n];
    Student student;

    // Obtaining values:
    for (int i = 0; i < n; i++)
    {
        cout << "Enter the name of the " << i + 1 << " student: ";
        cin.ignore();                   // Helps to clear newline character from last input.
        getline(cin, students[i].name); // For string type input.
        cout << "Enter the roll number: ";
        cin >> students[i].rollno;
        cout << "Enter the marks: ";
        cin >> students[i].marks;
        cout << endl;
    }

    // Printing the values:
    cout << "\nStudent Report: " << endl;
    cout << "------------------" << endl;

    for (int i = 0; i < n; i++)
    {
        student = students[i];
        cout << "\nName: " << student.name << "\nRoll Number: " << student.rollno << "\nMarks: " << student.marks << endl;
        cout << "\n";
    }
}