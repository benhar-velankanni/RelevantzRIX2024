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
var Product = /** @class */ (function () {
    function Product(name, price, inStock) {
        this.name = name;
        this.price = price;
        this.inStock = inStock;
    }
    Product.prototype.getDetails = function () {
        console.log("Name: ".concat(this.name, ", Price: ").concat(this.price, ", In Stock: ").concat(this.inStock));
    };
    return Product;
}());
var Item = /** @class */ (function (_super) {
    __extends(Item, _super);
    function Item(name, price, inStock, quantity) {
        var _this = _super.call(this, name, price, inStock) || this;
        _this.quantity = quantity;
        return _this;
    }
    Item.prototype.getDetails = function () {
        console.log("Name: ".concat(this.name, ", Price: ").concat(this.price, ", In Stock: ").concat(this.inStock, ", Quantity: ").concat(this.quantity));
    };
    return Item;
}(Product));
var item = new Item("Product A", 10, true, 5);
item.getDetails();
var product = new Product("Product B", 20, false);
product.getDetails();
