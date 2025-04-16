export class Product {
    constructor(public name: string, public price: number,public instock: boolean) {}
    getName() :string {
        return this.name;
    }
    getPrice() :number {
        return this.price;
    }
    getInstock() :boolean {
        return this.instock;
    }
}

export function processForm(input: Product) {
    console.log('Product Name: ' + input.getName());
    console.log('Product Price: ' + input.getPrice());
    console.log('Product Instock: ' + input.getInstock());
}

export class Book{
    constructor (public title: string, public author: string ,public pages: number,public isavailable: boolean) {}
    getTitle() :string {
        return this.title;
    }
    getAuthor() :string {
        return this.author;
    }
    getPages() :number {
        return this.pages;
    }
    getIsavailable() :boolean {
        return this.isavailable;
    }
}
export function bookForm(input: Book) {
    console.log('Book Title: ' + input.getTitle());
    console.log('Book Author: ' + input.getAuthor());
    console.log('Book Pages: ' + input.getPages());
    console.log('Book Instock: ' + input.getIsavailable());
}

export class Car {
    constructor(public make: string, public model: string, public year: number) {}
    getMake() :string {
        return this.make;
    }
    getModel() :string {
        return this.model;
    }
    getYear() :number {
        return this.year;
    }
}

export function carForm(input: Car) {
    console.log('Car Make: ' + input.getMake());
    console.log('Car Model: ' + input.getModel());
    console.log('Car Year: ' + input.getYear());
}

export class Employee {
    constructor(public name: string, public position : string, public salary: number,public isfulltime: boolean) {}
    getName() :string {
        return this.name;
    }
    getPosition() :string {
        return this.position;
    }
    getSalary() :number {
        return this.salary;
    }
    getIsfulltime() :boolean {
        return this.isfulltime;
    }
}

export function employeeForm(input: Employee) {
    console.log('Employee Name: ' + input.getName());
    console.log('Employee Position: ' + input.getPosition());
    console.log('Employee Salary: ' + input.getSalary());
    console.log('Employee Full Time: ' + input.getIsfulltime());
}

export class Course {
    constructor(public title: string ,public instructor: string, public duration: number,public isonline: boolean) {}
    getName() :string {
        return this.title;
    }
    getInstructor() :string {
        return this.instructor;
    }
    getDuration() :number {
        return this.duration;
    }
    getIsonline() :boolean {
        return this.isonline;
    }
}

export function courseForm(input: Course) { 
    console.log('Course Name: ' + input.getName());
    console.log('Course Instructor: ' + input.getInstructor());
    console.log('Course Duration: ' + input.getDuration());
    console.log('Course Online: ' + input.getIsonline());
}