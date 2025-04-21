"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CourseItem = exports.EmployeeItem = exports.CarItem = exports.BookItem = exports.ProductItem = void 0;
var ProductItem = /** @class */ (function () {
    // super(id,name,price,inStock);
    function ProductItem(id, name, price, inStock) {
        this.id = id;
        this.name = name;
        this.price = price;
        this.inStock = inStock;
    }
    ProductItem.prototype.dis = function () {
        console.log("id:".concat(this.id, ",name:").concat(this.name, ",price:").concat(this.price, ",inStock:").concat(this.inStock));
    };
    return ProductItem;
}());
exports.ProductItem = ProductItem;
var BookItem = /** @class */ (function () {
    function BookItem(input) {
        this.id = input.id;
        this.name = input.name;
        this.author = input.author;
        this.pages = input.pages;
    }
    BookItem.prototype.dis = function () {
        console.log("id:".concat(this.id, ",name:").concat(this.name, ",author:").concat(this.author, ",pages:").concat(this.pages));
    };
    return BookItem;
}());
exports.BookItem = BookItem;
var CarItem = /** @class */ (function () {
    function CarItem(id, name, make, model, year, isRunning) {
        this.id = id;
        this.name = name;
        this.make = make;
        this.model = model;
        this.year = year;
        this.isRunning = isRunning;
    }
    CarItem.prototype.dis = function () {
        console.log("id:".concat(this.id, ",name:").concat(this.name, ",make:").concat(this.make, ",model:").concat(this.model, ",year:").concat(this.year, ",isRunning:").concat(this.isRunning));
    };
    return CarItem;
}());
exports.CarItem = CarItem;
var EmployeeItem = /** @class */ (function () {
    function EmployeeItem(id, name, position, salary, isFullTime) {
        this.id = id;
        this.name = name;
        this.position = position;
        this.salary = salary;
        this.isFullTime = isFullTime;
    }
    EmployeeItem.prototype.dis = function () {
        console.log("id:".concat(this.id, ",name:").concat(this.name, ",position:").concat(this.position, ",salary:").concat(this.salary, ",isFullTime:").concat(this.isFullTime));
    };
    return EmployeeItem;
}());
exports.EmployeeItem = EmployeeItem;
var CourseItem = /** @class */ (function () {
    function CourseItem(id, name, instructor, duration, isOnline) {
        this.id = id;
        this.name = name;
        this.instructor = instructor;
        this.duration = duration;
        this.isOnline = isOnline;
    }
    CourseItem.prototype.dis = function () {
        console.log("id:".concat(this.id, ",name:").concat(this.name, ",instructor:").concat(this.instructor, ",duration:").concat(this.duration, ",isOnline:").concat(this.isOnline));
    };
    return CourseItem;
}());
exports.CourseItem = CourseItem;
