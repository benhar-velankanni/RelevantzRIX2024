var DataStorage = /** @class */ (function () {
    function DataStorage() {
        this.items = [];
    }
    DataStorage.prototype.addItem = function (item) {
        this.items.push(item);
    };
    DataStorage.prototype.removeItem = function (item) {
        this.items = this.items.filter(function (i) { return i !== item; });
    };
    DataStorage.prototype.getItems = function () {
        return this.items;
    };
    return DataStorage;
}());
var stringStorage = new DataStorage();
stringStorage.addItem("Hello");
stringStorage.addItem("World");
stringStorage.removeItem("Hello");
console.log(stringStorage.getItems());
