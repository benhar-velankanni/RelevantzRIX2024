
class Item {
  constructor(public name: string, public price: number, public inStock: boolean) {}
}

class Product extends Item {
  constructor(public name: string, public price: number, public inStock: boolean) {
    super(name, price, inStock);
  }
}

const product = new Product("Apple iPhone", 999.99, true);

console.log(`Product: ${product.name} - $${product.price} - In Stock: ${product.inStock}`);

class Item1 {
  constructor(public name: string, public price: number, public inStock: boolean) {}
}

class Book extends Item1 {
  constructor(
    public title: string,
    public author: string,
    public pages: number,
    public isAvailable: boolean,
    public price: number,
    public inStock: boolean
  ) {
    super("Book", price, inStock);
  }
}

const book = new Book("Book Title", "Author Name", 200, true, 19.99, true);

console.log(`Book: ${book.title} by ${book.author} - ${book.pages} pages - Available: ${book.isAvailable}`);
console.log(`Price: $${book.price} - In Stock: ${book.inStock}`);

class Item2 {
  constructor(public name: string, public price: number, public inStock: boolean) {}
}

class Car extends Item2 {
  constructor(
    public make: string,
    public model: string,
    public year: number,
    public isRunning: boolean,
    public price: number,
    public inStock: boolean
  ) {
    super("Car", price, inStock);
  }
}

const car = new Car("Toyota", "Camry", 2022, true, 25000, true);

console.log(`Car: ${car.make} ${car.model} (${car.year}) - Running: ${car.isRunning}`);
console.log(`Price: $${car.price} - In Stock: ${car.inStock}`);

class Item3 {
  constructor(public name: string, public price: number, public inStock: boolean) {}
}

class Employee extends Item3 {
  constructor(
    public name: string,
    public position: string,
    public salary: number,
    public isFullTime: boolean,
    public price: number,
    public inStock: boolean
  ) {
    super("Employee", price, inStock);
  }
}

const employee = new Employee("John Doe", "Software Engineer", 50000, true, 0, true);
console.log(`Employee: ${employee.name} - Position: ${employee.position} - Salary: $${employee.salary}`);
console.log(`Full-time: ${employee.isFullTime} - Price: $${employee.price} - In Stock: ${employee.inStock}`);

class Item4 {
  constructor(public name: string, public price: number, public inStock: boolean) {}
}
class Course extends Item4 {
  constructor(
    public title: string,
    public instructor: string,
    public duration: number,
    public isOnline: boolean,
    public price: number,
    public inStock: boolean
  ) {
    super("Course", price, inStock);
  }
}

const course = new Course("JavaScript Fundamentals", "John Smith", 10, true, 99.99, true);

console.log(`Course: ${course.title} - Instructor: ${course.instructor} - Duration: ${course.duration} hours`);
console.log(`Online: ${course.isOnline} - Price: $${course.price} - In Stock: ${course.inStock}`);
