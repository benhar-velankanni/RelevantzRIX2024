#include <iostream>
#include <string>
using namespace std;

struct Account
{
    int accNo;
    string name;
    double balance;
    Account *next;
};

class Bank
{
private:
    Account *head;

public:
    Bank() { head = nullptr; }

    void createAccount(int accNo, string name, double balance)
    {
        Account *newAcc = new Account{accNo, name, balance, head};
        head = newAcc;
        cout << "Account created successfully!\n";
    }

    void displayAllAccounts()
    {
        if (!head)
        {
            cout << "No accounts found.\n";
            return;
        }
        cout << "\n--- Account List ---\n";
        Account *temp = head;
        while (temp)
        {
            cout << "Acc No: " << temp->accNo << "\nName: " << temp->name
                 << "\nBalance: $" << temp->balance << "\n-------------------\n";
            temp = temp->next;
        }
    }

    void displayOneAccount(int accNo)
    {
        Account *temp = head;
        while (temp)
        {
            if (temp->accNo == accNo)
            {
                cout << "\n--- Account Details ---\n";
                cout << "Acc No: " << temp->accNo << "\nName: " << temp->name
                     << "\nBalance: $" << temp->balance << "\n-------------------\n";
                return;
            }
            temp = temp->next;
        }
        cout << "Account not found!\n";
    }

    void deleteAccount(int accNo)
    {
        if (!head)
        {
            cout << "No accounts to delete.\n";
            return;
        }

        Account *temp = head;
        Account *prev = nullptr;

        // If head node is to be deleted
        if (temp != nullptr && temp->accNo == accNo)
        {
            head = temp->next;
            delete temp;
            cout << "Account deleted successfully!\n";
            return;
        }

        // Search for the account to delete
        while (temp != nullptr && temp->accNo != accNo)
        {
            prev = temp;
            temp = temp->next;
        }

        // If account not found
        if (temp == nullptr)
        {
            cout << "Account not found!\n";
            return;
        }

        // Unlink the node and delete it
        prev->next = temp->next;
        delete temp;
        cout << "Account deleted successfully!\n";
    }

    void searchAccount(int accNo)
    {
        Account *temp = head;
        while (temp)
        {
            if (temp->accNo == accNo)
            {
                cout << "\n--- Account Found ---\n";
                cout << "Acc No: " << temp->accNo << "\nName: " << temp->name
                     << "\nBalance: $" << temp->balance << "\n-------------------\n";
                return;
            }
            temp = temp->next;
        }
        cout << "Account not found!\n";
    }
};

bool login()
{
    string username, password;
    cout << "Enter Username: ";
    cin >> username;
    cout << "Enter Password: ";
    cin >> password;
    return (username == "admin" && password == "12345");
}

int main()
{
    if (!login())
    {
        cout << "Invalid Username or Password. Exiting...\n";
        return 0;
    }

    Bank bank;
    int choice, accNo;
    string name;
    double balance;

    do
    {
        cout << "\n====== BANK MANAGEMENT SYSTEM ======\n";
        cout << "1. Create Account\n";
        cout << "2. Display One Account\n";
        cout << "3. Display All Accounts\n";
        cout << "4. Delete Account\n";
        cout << "5. Search Account\n";
        cout << "6. Exit\n";
        cout << "Enter choice: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
            cout << "Enter Acc No, Name, Balance: ";
            cin >> accNo >> ws;
            getline(cin, name);
            cin >> balance;
            bank.createAccount(accNo, name, balance);
            break;
        case 2:
            cout << "Enter Acc No: ";
            cin >> accNo;
            bank.displayOneAccount(accNo);
            break;
        case 3:
            bank.displayAllAccounts();
            break;
        case 4:
            cout << "Enter Acc No to delete: ";
            cin >> accNo;
            bank.deleteAccount(accNo);
            break;
        case 5:
            cout << "Enter Acc No to search: ";
            cin >> accNo;
            bank.searchAccount(accNo);
            break;
        case 6:
            cout << "Exiting...\n";
            break;
        default:
            cout << "Invalid choice! Try again.\n";
        }
    } while (choice != 6);

    return 0;
}