class Employee
{
    name: string;
    position:string;
    salary: number;
    isPosition: Boolean;
    constructor(name: string, position:string, salary: number, isPosition: boolean)
    {
        this.name = name;
        this.position = position;
        this.salary = salary;
        this.isPosition = isPosition;
    }

    
}
class checkboxempInput 
{
    constructor(public checked:Boolean)
    {}
    getChecked()
    {
        return this.checked;
    }
}

var emp_form = document.querySelector("#emp_form") as HTMLFormElement
emp_form.addEventListener('submit', function(e) {
    e.preventDefault();
    const name = (document.getElementById("name") as HTMLInputElement);
    const position = (document.getElementById("position") as HTMLInputElement);
    const salary = (document.getElementById("salary") as HTMLInputElement);
    const Position = (document.getElementById("isPosition") as HTMLInputElement)

    const checkemp=new checkboxempInput(Position.checked);
const employee = new Employee(name.value, position.value, Number(salary.value), Boolean(checkemp.getChecked()));


console.log(employee.name);
console.log(employee.position);
console.log(employee.salary);
console.log(employee.isPosition);
}); 



