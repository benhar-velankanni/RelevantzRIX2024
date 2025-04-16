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
    function Product(name, price, instock) {
        this.name = name;
        this.price = price;
        this.instock = instock;
    }
    Product.prototype.getDetails = function () {
        return "Name: ".concat(this.name, ", Price: ").concat(this.price, ", Instock: ").concat(this.instock);
    };
    return Product;
}());
var Mobile = /** @class */ (function (_super) {
    __extends(Mobile, _super);
    function Mobile(name, price, instock, description) {
        var _this = _super.call(this, name, price, instock) || this;
        _this.description = description;
        return _this;
    }
    Mobile.prototype.getMobile = function () {
        return "Name: ".concat(this.name, ", Price: ").concat(this.price, ", Instock: ").concat(this.instock, " , Description: ").concat(this.description);
    };
    return Mobile;
}(Product));
var p = new Product("Laptop", 50000, true);
var m = new Mobile("Laptop", 50000, true, "good");
console.log(p.getDetails());
console.log(m.getMobile());
var Book = /** @class */ (function () {
    function Book(title, author, pages) {
        this.title = title;
        this.author = author;
        this.pages = pages;
    }
    Book.prototype.getBookDetails = function () {
        return "Title: ".concat(this.title, ", Author: ").concat(this.author, ", Pages: ").concat(this.pages);
    };
    return Book;
}());
var Novel = /** @class */ (function (_super) {
    __extends(Novel, _super);
    function Novel(title, author, pages, genre, isAvailable) {
        var _this = _super.call(this, title, author, pages) || this;
        _this.genre = genre;
        _this.isAvailable = isAvailable;
        return _this;
    }
    Novel.prototype.getNovelDetails = function () {
        return "Title: ".concat(this.title, ", Author: ").concat(this.author, ", Pages: ").concat(this.pages, ", Genre: ").concat(this.genre, " this. isAvailable: ").concat(this.isAvailable);
    };
    return Novel;
}(Book));
var b = new Book("Wings of fire", "Abdulkalam", 50);
var n = new Novel("Marvel", "james", 80, "Fantasy", true);
console.log(b.getBookDetails());
console.log(n.getNovelDetails());
