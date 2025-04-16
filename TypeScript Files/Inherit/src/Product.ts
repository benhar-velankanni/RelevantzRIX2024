class Product {
    name: string;
    price: number;

    constructor(name: string, price: number) {
        this.name = name;
        this.price = price;
    }
}
class Item extends Product {
    inStack: boolean;
    constructor(name: string, price: number, inStack: boolean) {
        super(name, price);
        this.inStack = inStack;
    }
    getDetails() {
        return `Name: ${this.name}, Price: ${this.price}, inStack: ${this.inStack}`;
    }
}
let item = new Item("Laptop", 10000, true);
console.log(item.getDetails());
