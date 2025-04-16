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
var Car = /** @class */ (function () {
    function Car(make, model, year, isRunnung) {
        this.make = make;
        this.model = model;
        this.year = year;
        this.isRunnung = isRunnung;
    }
    Car.prototype.getDetails = function () {
        console.log("Make: ".concat(this.make, ", Model: ").concat(this.model, ", Year: ").concat(this.year, ", Is Running: ").concat(this.isRunnung));
    };
    return Car;
}());
var Items = /** @class */ (function (_super) {
    __extends(Items, _super);
    function Items(make, model, year, isRunnung, quantity) {
        var _this = _super.call(this, make, model, year, isRunnung) || this;
        _this.quantity = quantity;
        return _this;
    }
    Items.prototype.getDetails = function () {
        console.log("Make: ".concat(this.make, ", Model: ").concat(this.model, ", Year: ").concat(this.year, ", Is Running: ").concat(this.isRunnung, ", Quantity: ").concat(this.quantity));
    };
    return Items;
}(Car));
var car = new Car("Toyota", "Camry", 2022, true);
var item1 = new Items("Honda", "Civic", 2021, false, 5);
car.getDetails();
item1.getDetails();
