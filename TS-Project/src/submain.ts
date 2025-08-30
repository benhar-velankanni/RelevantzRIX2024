type pro={
    name:string,
    price:number,
    isStock:boolean
}
export class Product {
    prodis(input :pro){
        console.log("Product Section!!");
        console.log(`Product name is ${input.name} and price is ${input.price} and stock is ${input.isStock}`);
    }
   }
type boo={
    title:string,
    author:string,
    pages:number,
    isAvailable:boolean
}
    
    
export class book{
    bookdis(input:boo){
        console.log("Book Section!!");
        console.log(`Book title is ${input.title} and author is ${input.author} and pages are ${input.pages} and book is ${input.isAvailable}`);
    }
}

type ca={
    make:string,
    model:string,
    year:number,
    isRunning:boolean
}
    
export class car{
    cardis(input:ca){
        console.log("Car Section!!");
        console.log(`Car make is ${input.make} and model is ${input.model} and year is ${input.year} and car is ${input.isRunning}`);
    }
}
    
    
type emp={
    name:string,
    position:string,
    salary:number,
    isFullTime:boolean
} 
export class employee{
    empdis(input:emp){
        console.log("Employee Section!!");
        console.log(`Employee name is ${input.name} and position is ${input.position} and salary is ${input.salary} and employee is ${input.isFullTime}`);
    }
}

type cou={
    title:string,
    instructor:string,
    duration:number,
    isOnline:boolean
}
    
export class course{
    courdis(input:cou){
        console.log("Course Section!!");
        console.log(`Course title is ${input.title} and instructor is ${input.instructor} and duration is ${input.duration} and course is ${input.isOnline}`);
    }
}
