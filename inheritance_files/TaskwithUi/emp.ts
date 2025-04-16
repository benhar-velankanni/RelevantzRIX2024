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
        return `
        <table>
            <tr>
                <td>Name:</td>
                <td>${this.name}</td>
            </tr>
            <tr>
                <td>Position:</td>
                <td>${this.position}</td>
            </tr>
            <tr>
                <td>Salary:</td>
                <td>${this.salary}</td>
            </tr>
            <tr>
                <td>Language:</td>
                <td>${this.language}</td>
            </tr>
        </table>
        `
    }
}

document.getElementById("empform")?.addEventListener("submit", (event) => {
    event.preventDefault();
    const name = (document.getElementById("name") as HTMLInputElement).value;
    const position = (document.getElementById("position") as HTMLInputElement).value;
    const salary = parseInt((document.getElementById("salary") as HTMLInputElement).value);

    const language = (document.getElementById("language") as HTMLInputElement).value;
  
    let output: string;
    if(language.trim()!=="")
    {
        const d = new developer(name, position, salary, language);
        output = d.getdeveloperDetails();
    }
    else
    {
        const employee = new Employee(name, position, salary);
        output = employee.getDetailsemployee();
    }
    (document.getElementById("output")as HTMLParagraphElement).innerHTML = output;





});