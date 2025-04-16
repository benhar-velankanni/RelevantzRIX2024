class CheckBoxEmployeeInput{
    constructor(public checked: Boolean){}
        getValue(){
            return this.checked
        }
    }




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



   var form = document.getElementById("employee-form") as HTMLFormElement
   form.addEventListener('submit',function(e){
    e.preventDefault()
    var name  = document.getElementById('name') as HTMLInputElement
    var position = document.getElementById('position') as HTMLInputElement
    var salary = document.getElementById('salary') as HTMLInputElement
    var fullTime = document.getElementById('fullTime') as HTMLInputElement

    const checkInput = new CheckBoxEmployeeInput(fullTime.checked)


    const emp = new Employee(name.value,position.value,Number(salary.value),Boolean(checkInput.getValue()))
    console.log("--- Employee Details ---")
    console.log(`Name : ${emp.name}`)
    console.log(`Position : ${emp.position}`)
    console.log(`Salary : ${emp.salary}`)
    if(emp.isFullTime == true){
        console.log(`Is Full Time : Yes`)
    }else{
        console.log(`Is Full Time : No`)
    }
   })
    