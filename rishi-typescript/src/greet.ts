//display greet message


// export function greet(name: string) {
//     console.log(`Hello, ${name}!`)
// }

// greet("Rishi")

//check age

// export function checkAge( age: number | string) {
//     if (typeof age === "string") {
//         age = parseInt(age)
//     }
//     if (age < 18) {
//         console.log("Sorry, you're too young to drive this car. Powering off")
//     } else if (age > 18) {
//         console.log("Powering On")
//     }
//     else {
//         console.log("Congratulations on your first year of driving. Enjoy the ride!")   
//     }

// }

// checkAge(16)
// checkAge("17")
// checkAge("18")

//create instance for person and company

// type Person = {
//     name: string,
//     age: number
// }

// type Company = {
//     name: string,
//     ceo: string
// }
// const person :Person = {
//     name: "Rishi",
//     age: 20
// };

// const company :Company = {
//     name: "Google",
//     ceo: person.name
// };
// type Entity = Person | Company;

// function logEntity(entity: Entity) {
//     if ("name" in entity) {
//         console.log(entity.name);
//     }
//     if ("ceo" in entity) {
//         console.log(entity.ceo);    
//     }
// }

// logEntity(person);
// logEntity(company);

//find the string length and number length

// let someValue:any ="Welcome to Typescript";
// let strLength:number = (<string>someValue).length;
// console.log("string length is",strLength);

// function getLength(input: string | number): number {
//         return input.toString().length;
//     }
    
//     console.log(getLength("Welcome to Typescript"));
//     console.log(getLength(100));

//create class dog and cat

export class Dog{
    bark(){
    console.log("Woofff!");
}
}

export class Cat{
    meow(){
    console.log("Meow!");
}}
 
export function makeSound(animal:Dog | Cat)
{
    if(animal instanceof Dog){
        animal.bark();
    }
    else{
        animal.meow();
    }
}
 


