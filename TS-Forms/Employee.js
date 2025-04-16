var CheckBoxEmployeeInput = /** @class */ (function () {
    function CheckBoxEmployeeInput(checked) {
        this.checked = checked;
    }
    CheckBoxEmployeeInput.prototype.getValue = function () {
        return this.checked;
    };
    return CheckBoxEmployeeInput;
}());
var Employee = /** @class */ (function () {
    function Employee(name, position, salary, isFullTime) {
        this.name = name;
        this.position = position;
        this.salary = salary;
        this.isFullTime = isFullTime;
    }
    return Employee;
}());
var form = document.getElementById("employee-form");
form.addEventListener('submit', function (e) {
    e.preventDefault();
    var name = document.getElementById('name');
    var position = document.getElementById('position');
    var salary = document.getElementById('salary');
    var fullTime = document.getElementById('fullTime');
    var checkInput = new CheckBoxEmployeeInput(fullTime.checked);
    var emp = new Employee(name.value, position.value, Number(salary.value), Boolean(checkInput.getValue()));
    console.log("--- Employee Details ---");
    console.log("Name : ".concat(emp.name));
    console.log("Position : ".concat(emp.position));
    console.log("Salary : ".concat(emp.salary));
    if (emp.isFullTime == true) {
        console.log("Is Full Time : Yes");
    }
    else {
        console.log("Is Full Time : No");
    }
});
