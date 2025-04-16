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
var Course = /** @class */ (function () {
    function Course(title, instuction, duration, isOnline) {
        this.title = title;
        this.instuction = instuction;
        this.duration = duration;
        this.isOnline = isOnline;
    }
    Course.prototype.getDetails = function () {
        console.log("Title: ".concat(this.title, ", Instructor: ").concat(this.instuction, ", Duration: ").concat(this.duration, ", Is Online: ").concat(this.isOnline));
    };
    return Course;
}());
var Person = /** @class */ (function (_super) {
    __extends(Person, _super);
    function Person(title, instuction, duration, isOnline, instructor) {
        var _this = _super.call(this, title, instuction, duration, isOnline) || this;
        _this.instructor = instructor;
        return _this;
    }
    Person.prototype.getDetails = function () {
        console.log("Title: ".concat(this.title, ", Instructor: ").concat(this.instuction, ", Duration: ").concat(this.duration, ", Is Online: ").concat(this.isOnline, ", Instructor: ").concat(this.instructor));
    };
    return Person;
}(Course));
var person = new Person("Java", "John", 2, true, "John");
person.getDetails();
var course = new Course("Java", "John", 2, true);
course.getDetails();
