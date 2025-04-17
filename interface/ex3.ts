interface AddFunction{
    (a: number, b: number): number;
}
const add: AddFunction = (a: number, b: number): number => a + b;

console.log(add(1, 2));

//interface to interface implements
//interface to class extends