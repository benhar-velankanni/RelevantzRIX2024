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
var Person = /** @class */ (function () {
    function Person(name, age) {
        this.name = name;
        this.age = age;
    }
    Person.prototype.getDetails = function () {
        return "Name: ".concat(this.name, ", Age: ").concat(this.age);
    };
    return Person;
}());
var employee = /** @class */ (function (_super) {
    __extends(employee, _super);
    function employee(name, age, salary) {
        var _this = _super.call(this, name, age) || this;
        _this.salary = salary;
        return _this;
    }
    employee.prototype.getDetailsemployee = function () {
        return "Name: ".concat(this.name, ", Age: ").concat(this.age, " , Salary: ").concat(this.salary);
    };
    return employee;
}(Person));
var obj1 = new Person("Rahul", 22);
var obj2 = new employee("Ranjith", 22, 10000);
console.log(obj1.getDetails());
console.log(obj2.getDetailsemployee());
