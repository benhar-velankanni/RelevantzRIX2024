class Item {
    constructor(public name: string, public price: number, public inStock: boolean) {}

    displayItemInfo(): void {
        console.log(`Name: ${this.name}, Price: ${this.price}, In Stock: ${this.inStock}`);
    }
}
class Product extends Item {
    constructor(name: string, price: number, inStock: boolean) {
        super(name, price, inStock);
    }

}

class Book extends Item {
    constructor(name: string, price: number, inStock: boolean, public title: string, public author: string, public pages: number, public isAvailable: boolean) {
        super(name, price, inStock);
    }

    displayItemInfo(): void {
        super.displayItemInfo();
        console.log(`Title: ${this.title}, Author: ${this.author}, Pages: ${this.pages}, Is Available: ${this.isAvailable}`);
    }
}

class Car extends Item {
    constructor(name: string, price: number, inStock: boolean, public make: string, public model: string, public year: number, public isRunning: boolean) {
        super(name, price, inStock);
    }

    displayItemInfo(): void {
        super.displayItemInfo();
        console.log(`Make: ${this.make}, Model: ${this.model}, Year: ${this.year}, Is Running: ${this.isRunning}`);
    }
}

class Employee extends Item {
    constructor(name: string, price: number, inStock: boolean, public position: string, public salary: number, public isFullTime: boolean) {
        super(name, price, inStock);
    }

    displayItemInfo(): void {
        super.displayItemInfo();
        console.log(`Position: ${this.position}, Salary: ${this.salary}, Is Full Time: ${this.isFullTime}`);
    }
}

class Course extends Item {
    constructor(name: string, price: number, inStock: boolean, public title: string, public instructor: string, public duration: number, public isOnline: boolean) {
        super(name, price, inStock);
    }
    displayItemInfo(): void {
        super.displayItemInfo();
        console.log(`Title: ${this.title}, Instructor: ${this.instructor}, Duration: ${this.duration} hours, Is Online: ${this.isOnline}`);
    }
}



const product = new Product("Laptop", 1500, true);
product.displayItemInfo();

const book = new Book("The Great Gatsby", 10, true, "The Great Gatsby", "F. Scott Fitzgerald", 180, true);
book.displayItemInfo();

const car = new Car("Tesla Model S", 100000, true, "Tesla", "Model S", 2022, true);
car.displayItemInfo();
const employee = new Employee("John Doe", 50000, true, "Developer", 80000, true);
employee.displayItemInfo();

const course = new Course("TypeScript Fundamentals", 200, true, "TypeScript Fundamentals", "Rishi", 4, true);
course.displayItemInfo();


