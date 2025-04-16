class Employee
{
    name :string;
    position :string;
    salary :number;
        constructor(name :string, position :string, salary :number)
    {
        this.name=name;
        this.position=position;
        this.salary=salary;
       
    }
    getDetailsemployee() :string
    {
        return `Name: ${this.name}, Position: ${this.position}, Salary: ${this.salary}, `;
    }
}
class developer extends Employee
{
    language :string;
    constructor(name :string, position :string, salary :number, language :string)
    {
        super(name, position, salary);
        this.language=language;
    }
    getdeveloperDetails() :string
    {   
        return `Name: ${this.name}, Position: ${this.position}, Salary: ${this.salary}, Language: ${this.language}`;
    }
}

document.getElementById("emp_form").addEventListener('submit', function(e) {
    e.preventDefault();
    
})
let  e=new Employee("John", "Manager", 50000);
let  d=new developer("John", "Manager", 50000, "Java");
console.log(e.getDetailsemployee());
console.log(d.getdeveloperDetails());