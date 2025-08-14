#include <iostream>
#include <string>

using namespace std;

const int MAX_SIZE = 100;

struct Employee
{
    string name;
    int empid;
    string dept;
    double salaryPerAnnum;
    double exp;
};

// Function to print full structure:
void printArray(Employee arr[], int &n)
{
    // Displaying the list of employees:
    cout << "\nEmployees Report: " << endl;
    cout << "------------------" << endl;

    for (int i = 0; i < n; i++)
    {
        Employee employee = arr[i];
        cout << "\nName: " << employee.name << "\nEmployee ID: " << employee.empid << "\nDepartment: " << employee.dept << "\nYears of Experience: " << employee.exp << "\nSalary Per Annum: " << employee.salaryPerAnnum << endl;
        cout << "\n";
    }
    return;
}

// Function to search and print specific index:
void linearSearch(Employee arr[], int &n)
{
    int index = -1;

    // Obtaining target value:
    cout << "\nEnter the target Employee ID: ";
    int targetID;
    cin >> targetID;
    cout << endl;

    // Search:
    for (int i = 0; i < n; i++)
    {
        if (arr[i].empid == targetID)
        {
            index = i;
        }
    }

    // Print Results:
    if (index != -1)
    {
        Employee employee = arr[index];
        cout << "\nName: " << employee.name << "\nEmployee ID: " << employee.empid << "\nDepartment: " << employee.dept << "\nYears of Experience: " << employee.exp << "\nSalary Per Annum: " << employee.salaryPerAnnum << endl;
        cout << "\n";
    }
    else
    {
        cout << "\nThe employee ID is not present." << endl;
    }
    return;
}

// Function to delete struct entry:
void deleteStruct(Employee arr[], int &n)
{

    // Obtaining target value:
    cout << "\nEnter the target Employee ID: ";
    int targetID;
    cin >> targetID;
    cout << endl;

    // Search the value to delete:
    int pos = -1;
    for (int i = 0; i < n; i++)
    {
        if (arr[i].empid == targetID)
        {
            pos = i;
        }
    }

    // If element is not found:
    if (pos == -1)
    {
        cout << "\nThe employee ID is not present." << endl;
    }

    // Delete the element:
    for (int i = pos; i < n; i++)
    {
        arr[i] = arr[i + 1];
    }

    // Modify the new index:
    n--;

    // Displaying the list of employees:
    cout << "\nNew Employees Report: " << endl;
    cout << "------------------" << endl;

    for (int i = 0; i < n; i++)
    {
        Employee employee = arr[i];
        cout << "\nName: " << employee.name << "\nEmployee ID: " << employee.empid << "\nDepartment: " << employee.dept << "\nYears of Experience: " << employee.exp << "\nSalary Per Annum: " << employee.salaryPerAnnum << endl;
        cout << "\n";
    }
    return;
}

// Function to insert new employee record:
void insertStruct(Employee arr[], int &n)
{
    // Obtain position to insert:
    int index;
    cout << "\nEnter the index to add a record: ";
    cin >> index;
    cout << endl;

    // Checking if the position is valid;
    if (index < 0 || index > n)
    {
        cout << "\nInvalid Index" << endl;
        return;
    }

    // Checking if array is full:
    if (n == MAX_SIZE)
    {
        cout << "\nArray is full!" << endl;
        return;
    }

    // Shifting values from the "pos" index, one to the right:
    for (int i = n - 1; i >= index; i--)
    {
        arr[i + 1] = arr[i];
    }

    // Inserting value and updating "n" value:
    cout << "\nEnter the name of the employee at " << index << " index: ";
    cin.ignore();
    getline(cin, arr[index].name);
    cout << "Enter the employee ID: ";
    cin >> arr[index].empid;
    cout << "Enter the department: ";
    cin.ignore();
    getline(cin, arr[index].dept);
    cout << "Enter the salary per annum: ";
    cin >> arr[index].salaryPerAnnum;
    cout << "Enter the years of experience: ";
    cin >> arr[index].exp;
    cout << endl;

    n++;

    // Displaying the list of employees:
    cout << "\nNew Employees Report: " << endl;
    cout << "------------------" << endl;

    for (int i = 0; i < n; i++)
    {
        Employee employee = arr[i];
        cout << "\nName: " << employee.name << "\nEmployee ID: " << employee.empid << "\nDepartment: " << employee.dept << "\nYears of Experience: " << employee.exp << "\nSalary Per Annum: " << employee.salaryPerAnnum << endl;
        cout << "\n";
    }

    return;
}

int main()
{
    // Creating employee records:
    int n;
    cout << "Enter the number of employees: ";
    cin >> n;
    Employee employees[MAX_SIZE];

    // Obtaining values:
    for (int i = 0; i < n; i++)
    {
        cout << "\nEnter the name of the " << i + 1 << " employee: ";
        cin.ignore();
        getline(cin, employees[i].name);
        cout << "Enter the employee ID: ";
        cin >> employees[i].empid;
        cout << "Enter the department: ";
        cin.ignore();
        getline(cin, employees[i].dept);
        cout << "Enter the salary per annum: ";
        cin >> employees[i].salaryPerAnnum;
        cout << "Enter the years of experience: ";
        cin >> employees[i].exp;
        cout << endl;
    }

    char exit = 'x';
    while (exit != 'n' || exit != 'N')
    {
        cout << "\nActions to perform:  ";
        cout << "\n1.Print Report.";
        cout << "\n2.Search and print by Employee ID.";
        cout << "\n3.Delete by Employee ID.";
        cout << "\n4.Insert new record" << endl;
        cout << "\nEnter your choice:";
        int choice;
        cin >> choice;
        switch (choice)
        {
        case 1:
            printArray(employees, n);
            break;

        case 2:
            linearSearch(employees, n);
            break;

        case 3:
            deleteStruct(employees, n);
            break;

        case 4:
            insertStruct(employees, n);
            break;

        default:
            cout << "Invalid Choice!" << endl;
            break;
        }

cont:
        cout << "\nContinue?(y/n)" << endl;
        cin >> exit;

        if (exit == 'n' || exit == 'N')
        {
            cout << "\nThank You!" << endl;
            break;
        }
        else if (exit == 'y' || exit == 'Y')
        {
            continue;
        }
        else{
            cout << "\nInvalid Choice!" << endl;
            goto cont;
        }
    }
}