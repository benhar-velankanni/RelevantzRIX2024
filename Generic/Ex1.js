function identity(value) {
    return value;
}
var numberIdentity = identity(42);
var stringIdentity = identity("Hello");
console.log(numberIdentity);
console.log(stringIdentity);
