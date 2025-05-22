class Employee {
    name: string;
    position: string;
    salary: number;
    isFullTime: boolean;
  
    constructor(name: string, position: string, salary: number, isFullTime: boolean) {
      this.name = name;
      this.position = position;
      this.salary = salary;
      this.isFullTime = isFullTime;
    }
  }
  
  function createAndDisplayEmployee(name: string, position: string, salary: number, isFullTime: boolean) {
    const employee = new Employee(name, position, salary, isFullTime);
    console.log(`Employee Details:`);
    console.log(`Name: ${employee.name}`);
    console.log(`Position: ${employee.position}`);
    console.log(`Salary: $${employee.salary.toFixed(2)}`);
    console.log(`Is Full-time: ${employee.isFullTime ? 'Yes' : 'No'}`);
  }
  function getFormInput() {
    const nameInput = document.getElementById('name') as HTMLInputElement;
    const positionInput = document.getElementById('position') as HTMLInputElement;
    const salaryInput = document.getElementById('salary') as HTMLInputElement;
    const isFullTimeInput = document.getElementById('isFullTime') as HTMLInputElement;
  
    const name = nameInput.value;
    const position = positionInput.value;
    const salary = parseFloat(salaryInput.value);
    const isFullTime = isFullTimeInput.checked;
  
    return { name, position, salary, isFullTime };
  }
  
  const form = document.getElementById('employee-form') as HTMLFormElement;
  
  form.addEventListener('submit', (e) => {
    e.preventDefault();
    const input = getFormInput();
    createAndDisplayEmployee(input.name, input.position, input.salary, input.isFullTime);
  });