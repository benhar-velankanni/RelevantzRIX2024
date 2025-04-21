//generic interface
interface Box<T>{
    content: T;
}
const numberBox: Box<number> = {content: 42};
const stringBox: Box<string> = {content: "Hello"};
console.log(numberBox);
console.log(stringBox);