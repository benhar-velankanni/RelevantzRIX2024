var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Employee = /** @class */ (function () {
    function Employee(name, position, salary, isFullTime) {
        this.name = name;
        this.position = position;
        this.salary = salary;
        this.isFullTime = isFullTime;
    }
    Employee.prototype.getdetails = function () {
        console.log("Name: ".concat(this.name, ", Position: ").concat(this.position, ", Salary: ").concat(this.salary, ", Is Full Time: ").concat(this.isFullTime));
    };
    return Employee;
}());
var Manager = /** @class */ (function (_super) {
    __extends(Manager, _super);
    function Manager(name, position, salary, isFullTime, department) {
        var _this = _super.call(this, name, position, salary, isFullTime) || this;
        _this.department = department;
        return _this;
    }
    Manager.prototype.getdetails = function () {
        console.log("Name: ".concat(this.name, ", Position: ").concat(this.position, ", Salary: ").concat(this.salary, ", Is Full Time: ").concat(this.isFullTime, ", Department: ").concat(this.department));
    };
    return Manager;
}(Employee));
var emp1 = new Employee("John", "Manager", 50000, true);
var emp2 = new Manager("Jane", "Manager", 60000, true, "Sales");
emp1.getdetails();
emp2.getdetails();
