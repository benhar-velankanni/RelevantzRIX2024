export class Product {
    constructor(public name: string, public price: number, public inStock: boolean) {}
    getName(): string {
        return this.name      
    }
    getPrice(): number {
        return this.price
    }
    getInStock(): boolean {
        return this.inStock
    }
}

export function processForm(input: Product) {
    console.log("Product Name: " + input.getName());
    console.log("Product Price: " + input.getPrice());
    console.log("In Stock: " + input.getInStock());
}

export class Book{
    constructor(public title: string, public author: string, public pages: number, public isavailable: boolean) {}
    getTitle(): string {
        return this.title
    }
    getAuthor(): string {
        return this.author
    }
    getPages(): number {
        return this.pages
    }
    getIsAvailable(): boolean {
        return this.isavailable
    }
}

export function processBook(input: Book) {
    console.log("Book Title: " + input.getTitle());
    console.log("Book Author: " + input.getAuthor());
    console.log("Book Pages: " + input.getPages());
    console.log("Book Available: " + input.getIsAvailable());
}

export class Car{
    constructor(public make: string, public model: string, public year: number, public isrunning: boolean) {}
    getMake(): string {
        return this.make
    }
    getModel(): string {
        return this.model
    }
    getYear(): number {
        return this.year
    }
    getIsRunning(): boolean {
        return this.isrunning
    }
}

export function processCar(input: Car) {
    console.log("Car Make: " + input.getMake());
    console.log("Car Model: " + input.getModel());
    console.log("Car Year: " + input.getYear());
    console.log("Car Running: " + input.getIsRunning());
}

export class Employee{
    constructor(public name: string, public position: number, public salary: number, public isfulltime: boolean) {}
    getName(): string {
        return this.name
    }
    getPosition(): number {
        return this.position
    }
    getSalary(): number {
        return this.salary
    }
    getIsFullTime(): boolean {
        return this.isfulltime
    }
}

export function processEmployee(input: Employee) {
    console.log("Employee Name: " + input.getName());
    console.log("Employee Position: " + input.getPosition());
    console.log("Employee Salary: " + input.getSalary());
    console.log("Employee Full Time: " + input.getIsFullTime());
}

export class Course{
    constructor(public name: string,public instructor: string,public duration: number,public isonline: boolean) {}
    getName(): string {
        return this.name
    }
    getInstructor(): string {
        return this.instructor
    }
    getDuration(): number {
        return this.duration
    }
    getIsOnline(): boolean {
        return this.isonline
    }
}

export function processCourse(input: Course) {
    console.log("Course Name: " + input.getName());
    console.log("Course Instructor: " + input.getInstructor());
    console.log("Course Duration: " + input.getDuration());
    console.log("Course Online: " + input.getIsOnline());
}