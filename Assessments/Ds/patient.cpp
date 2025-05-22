#include<iostream>
#include<string>
using namespace std;
struct Patient
{
    int id;
    string name;
    int age;
    string diagnosis;
};
class Patientlist{
    private:
     Patient patients[100];
     int count;
    public:
     Patientlist():count(0){}
     void Addpatient(){
        if(count>100){
            cout<<"List is full";
        }
        cout<<"Enter id ";
        cin>>patients[count].id;
        cin.ignore();
        cout<<"Enter name ";
        getline(cin,patients[count].name);
        cout<<"Enter age ";
        cin>>patients[count].age;
        cout<<"Enter diagnosis ";
        cin>>patients[count].diagnosis;
        cout<<"Patient added successfully";
        count++;
     }
     void Searchpatient(){
        int pid;
        cout<<"Enter patient id";
        cin>>pid;
        for(int i=0;i<count;i++){
            if(patients[i].id==pid){
                cout<<"Patient found";
                cout<<"id:"<<patients[i].id;
                cout<<"name:"<<patients[i].name;
                cout<<"age:"<<patients[i].age;
                cout<<"diagnosis"<<patients[i].diagnosis;
            }
        }
     }
     void Displayall(){
        if(count<=0){
            cout<<"No patient record";
        }
        for(int i=0;i<count;i++){
                cout<<"Patient found";
                cout<<"id:"<<patients[i].id;
                cout<<"name:"<<patients[i].name;
                cout<<"age:"<<patients[i].age;
                cout<<"diagnosis"<<patients[i].diagnosis;
        }
     }
     void deletepatient(){
        int pid;
        cout<<"Enter id:";
        cin>>pid;
        for(int i=0;i<count;i++){
        if(pid==patients[i].id){
            patients[i]=patients[i+1];
        }
     }
     cout<<"Patient deleted successfully";
     }
};
int main(){
    Patientlist patientl;
    int choice;
    while(true){
        cout<<"\n-------------------------------------------------------------------";
        cout<<"\nChoose operations";
        cout<<"\n1.Add patient";
        cout<<"\n2.Search patient";
        cout<<"\n3.Remove patient";
        cout<<"\n4.Display all patients";
        cout<<"\n5.Exit";
        cout<<"--------------------------------------------------------------------";
        cout<<"\nEnter your choice:";
        cin>>choice;
        switch (choice)
        {
        case 1:
            /* code */
            patientl.Addpatient();
            break;
        case 2:
            patientl.Displayall();
            break;
        case 3:
            patientl.deletepatient();
        default:
            break;
        }
    }
        
        
       } 
