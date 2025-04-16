var CheckBoxInput = /** @class */ (function () {
    function CheckBoxInput(checked) {
        this.checked = checked;
    }
    CheckBoxInput.prototype.getValue = function () {
        return this.checked;
    };
    return CheckBoxInput;
}());
var Product = /** @class */ (function () {
    function Product(name, price, inStock) {
        this.name = name;
        this.price = price;
        this.inStock = inStock;
    }
    return Product;
}());
var form = document.getElementById("products-form");
form.addEventListener('submit', function (e) {
    e.preventDefault();
    var name = document.getElementById('name');
    var price = document.getElementById('price');
    var stock = document.getElementById('stock');
    var checkInput = new CheckBoxInput(stock.checked);
    var prod = new Product(name.value, Number(price.value), Boolean(checkInput.getValue()));
    console.log("--- Product Details ---");
    console.log("Product name : ".concat(prod.name));
    console.log("Price : ".concat(prod.price));
    if (prod.inStock == true) {
        console.log("In Stock : Yes");
    }
    else {
        console.log("In Stock : No");
    }
});
