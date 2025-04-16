class Employee{
    employeename: string;
    position: string;
    salary: number;

    constructor(employeename: string, position: string, salary: number){
        this.employeename = employeename;
        this.position = position;
        this.salary = salary;
    }
}
class Manager extends Employee{
    isFullTime: boolean;

    constructor(employeename: string, position: string, salary: number, isFullTime: boolean){
        super(employeename, position, salary);
        this.isFullTime = isFullTime;
    }
    getDetails(){
        return `Name: ${this.employeename}, Position: ${this.position}, Salary: ${this.salary}, Full Time: ${this.isFullTime}`;
    }
}

let manager = new Manager("Arul Naveen Arulthomas", "Manager", 250000, true);
console.log(manager.getDetails());