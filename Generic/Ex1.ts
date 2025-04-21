//generic function 
function identity<T>(value: T): T {
    return value;
}
const numberIdentity = identity<number>(42);
const stringIdentity = identity<string>("Hello");
console.log(numberIdentity);
console.log(stringIdentity);