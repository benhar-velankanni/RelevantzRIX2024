interface Item{
    id:number,
    name:string,
    dis():void
}

interface Product extends Item{
    price:number,
    inStock:boolean,
    
}

export class ProductItem implements Product{
    id: number;
    name: string;
    price: number;
    inStock: boolean;
    // super(id,name,price,inStock);
    constructor(id:number,name:string,price:number,inStock:boolean){
        this.id=id;
        this.name=name;
        this.price=price;
        this.inStock=inStock;
    }
    dis(){
        console.log(`id:${this.id},name:${this.name},price:${this.price},inStock:${this.inStock}`);
    }
}

interface Book extends Item{
    author:string,
    pages:number,
}
type bc={
    id:number,name:string,author:string,pages:number,
}

export class BookItem implements Book{
    id:number;
    name:string;
    author:string;
    pages:number;
    constructor(input: bc){
        this.id=input.id;
        this.name=input.name;
        this.author=input.author;
        this.pages=input.pages;
        
    }
    dis(){
        console.log(`id:${this.id},name:${this.name},author:${this.author},pages:${this.pages}`);
    }
}

interface Car extends Item{
    make:string,
    model:string,
    year:string,
    isRunning:boolean,
}

export class CarItem implements Car{
    id:number;
    name:string;
    make:string;
    model:string;
    year:string;
    isRunning:boolean;
    constructor(id:number,name:string,make:string,model:string,year:string,isRunning:boolean){
        this.id=id;
        this.name=name;
        this.make=make;
        this.model=model;
        this.year=year;
        this.isRunning=isRunning;
    }
    dis(){
        console.log(`id:${this.id},name:${this.name},make:${this.make},model:${this.model},year:${this.year},isRunning:${this.isRunning}`);
    }
}

interface Employee extends Item{
    position:string,
    salary:number,
    isFullTime:boolean,
}

export class EmployeeItem implements Employee{
    id:number;
    name:string;
    position:string;
    salary:number;
    isFullTime:boolean;
    constructor(id:number,name:string,position:string,salary:number,isFullTime:boolean){
        this.id=id;
        this.name=name;
        this.position=position;
        this.salary=salary;
        this.isFullTime=isFullTime;
    }
    dis(){
        console.log(`id:${this.id},name:${this.name},position:${this.position},salary:${this.salary},isFullTime:${this.isFullTime}`);
    }
}

interface Course extends Item{
    instructor:string,
    duration:number,
    isOnline:boolean,
}

export class CourseItem implements Course{
    id:number;
    name:string;
    instructor:string;
    duration:number;
    isOnline:boolean;
    constructor(id:number,name:string,instructor:string,duration:number,isOnline:boolean){
        this.id=id;
        this.name=name;
        this.instructor=instructor;
        this.duration=duration;
        this.isOnline=isOnline;
    }
    dis(){
        console.log(`id:${this.id},name:${this.name},instructor:${this.instructor},duration:${this.duration},isOnline:${this.isOnline}`);
    }
}