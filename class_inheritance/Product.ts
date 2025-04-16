class Product {
    name: string;
    price: number;
    inStock: boolean;
    constructor(name: string, price: number, inStock: boolean) {
      this.name = name;
      this.price = price;
      this.inStock = inStock;
    }
    getDetails(){
        console.log(`Name: ${this.name}, Price: ${this.price}, In Stock: ${this.inStock}`);
    }
}
class Item extends Product {
    quantity: number;
    constructor(name: string, price: number, inStock: boolean, quantity: number) {
      super(name, price, inStock);
      this.quantity = quantity;
    }
    getDetails(): void {
        console.log(`Name: ${this.name}, Price: ${this.price}, In Stock: ${this.inStock}, Quantity: ${this.quantity}`);
    }
}
const item = new Item("Product A", 10, true, 5);
item.getDetails();
const product = new Product("Product B", 20, false);
product.getDetails();