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
//generic class
var Item = /** @class */ (function () {
    function Item(id, name, price) {
        this.id = id;
        this.name = name;
        this.price = price;
    }
    Item.prototype.displayInfo = function () {
        return "Id:".concat(this.id, " Name:").concat(this.name, " Price:").concat(this.price);
    };
    return Item;
}());
var PerishableItem = /** @class */ (function (_super) {
    __extends(PerishableItem, _super);
    function PerishableItem(id, name, price, expirationDate) {
        var _this = _super.call(this, id, name, price) || this;
        _this.expirationDate = expirationDate;
        return _this;
    }
    PerishableItem.prototype.isExpired = function () {
        var today = new Date();
        return today > this.expirationDate;
    };
    PerishableItem.prototype.displayInfo = function () {
        var expiryStatus = this.isExpired() ? "Expired" : "Not Expired";
        return "".concat(_super.prototype.displayInfo.call(this), " Expiry Status:").concat(expiryStatus);
    };
    return PerishableItem;
}(Item));
var item1 = new Item(1, "Item 1", 10);
var perishableItem1 = new PerishableItem(2, "Perishable Item 1", 20, new Date("2023-01-01"));
console.log(item1.displayInfo());
console.log(perishableItem1.displayInfo());
