export class Product{
    constructor(public name:string,public price:number,public instock:boolean){}
    getName():string{
        return this.name
    }
    getPrice():number{
        return this.price
    }
    getInstock():boolean{
        return this.instock
    }
}
export class Book{
    constructor (public title: string,public author: string,public pages: number,public isAvailable: boolean) {}
    getTitle():string{
        return this.title
    }
    getAuthor():string{
        return this.author
    }
    getPages():number{
        return this.pages
    }
    getIsAvailable():boolean{
        return this.isAvailable
    }

}
export function processForm(input:Product){
    console.log('Product name: ' + input.getName());
    console.log('Product price: ' + input.getPrice());
    console.log('Product instock: ' + input.getInstock());
}

export function processBookForm(input:Book){
    
    console.log('Book title: ' + input.getTitle());
    console.log('Book author: ' + input.getAuthor());
    console.log('Book pages: ' + input.getPages());
    console.log('Book isAvailable: ' + input.getIsAvailable());
}
export class Car{
    constructor(public name:string,public model:string,public year:number,public isRunning:boolean){}
    getName():string{
        return this.name
    }
    getModel():string{
        return this.model
    }
    getYear():number{
        return this.year
    }
    getIsRunning():boolean{
        
        return this.isRunning
    }
}
export function processCarForm(input:Car){
    
    console.log('Car name: ' + input.getName());
    console.log('Car model: ' + input.getModel());
    console.log('Car year: ' + input.getYear());
    console.log('Car isRunning: ' + input.getIsRunning());

}
export class Employee{
    constructor(public name:string,public position:string,public salary:number,public isFulltime:boolean){}
    getName():string{
        return this.name
    }
    getPosition():string{
        return this.position
    }
    getSalary():number{
        return this.salary
    }
    getIsFulltime():boolean{
        return this.isFulltime
    }
}
export function processEmployeeForm(input:Employee){
    
    console.log('Employee name: ' + input.getName());
    console.log('Employee position: ' + input.getPosition());
    console.log('Employee salary: ' + input.getSalary());
    console.log('Employee isFulltime: ' + input.getIsFulltime());
}
export class Course{
    constructor(public title:string,public instructor:string,public duration:number,public isOnline:boolean){}
    getTitle():string{
        return this.title
    }
    getInstructor():string{
        return this.instructor
    }
    getDuration():number{
        return this.duration
    }
    getIsOnline():boolean{
        return this.isOnline
    }
}
export function processCourseForm(input:Course){
    
    console.log('Course title: ' + input.getTitle());
    console.log('Course instructor: ' + input.getInstructor());
    console.log('Course duration: ' + input.getDuration());
    console.log('Course isOnline: ' + input.getIsOnline());
}