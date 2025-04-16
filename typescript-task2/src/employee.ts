class Employee{
    id:number;
    name:string;
    salary:number;
    constructor(id:number,name:string,salary:number){
        this.id=id;
        this.name=name;
        this.salary=salary;
    }
    getDetails():string{
        return `${this.id} ${this.name} ${this.salary}`;
    }
}
class Manager extends Employee{
    isfulltime:boolean;
    constructor(id:number,name:string,salary:number,isfulltime:boolean){
        super(id,name,salary);
        this.isfulltime=isfulltime;
    }
    getDetails():string{
        return `Id:${this.id} Name:${this.name} Salary:${this.salary} Status:${this.isfulltime}`;
    }
}
let emp=new Manager(1,"Mukesh",5000,true);
console.log(emp.getDetails());
    
