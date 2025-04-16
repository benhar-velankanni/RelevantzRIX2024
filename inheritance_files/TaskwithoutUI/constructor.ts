class Person
{
    name: string;
    age: number;
    constructor(name: string, age: number)
    {
        this.name = name;
        this.age = age;
    }
    getDetails(): string
    {
        return `Name: ${this.name}, Age: ${this.age}`
    }
}
class employee extends Person
{
   salary : number;
   constructor( name: string, age: number, salary : number)
   {
       super(name,age);
       this.salary=salary

   }
    getDetailsemployee(): string 
    {
            return `Name: ${this.name}, Age: ${this.age} , Salary: ${this.salary}`    
    }

}
let  obj1=new Person("Rahul", 22);
let obj2 =new employee("Ranjith", 22, 10000);
console.log(obj1.getDetails());
console.log(obj2.getDetailsemployee());



 












































































































































































































































































