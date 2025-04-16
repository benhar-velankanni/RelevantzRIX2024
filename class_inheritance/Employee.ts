class Employee{
    name:string;
    position:string;
    salary:number;
    isFullTime:boolean;
    constructor(name:string,position:string,salary:number,isFullTime:boolean){
        this.name=name;
        this.position=position;
        this.salary=salary;
        this.isFullTime=isFullTime;
    }
    getdetails(){   
        console.log(`Name: ${this.name}, Position: ${this.position}, Salary: ${this.salary}, Is Full Time: ${this.isFullTime}`);
    }
}
class Manager extends Employee{
    department:string;
    constructor(name:string,position:string,salary:number,isFullTime:boolean,department:string){
        super(name,position,salary,isFullTime);
        this.department=department;
    }
    getdetails(){
        console.log(`Name: ${this.name}, Position: ${this.position}, Salary: ${this.salary}, Is Full Time: ${this.isFullTime}, Department: ${this.department}`);
    }
}              
const emp1=new Employee("John","Manager",50000,true);
const emp2=new Manager("Jane","Manager",60000,true,"Sales");
emp1.getdetails();
emp2.getdetails();