function greet(name) {
    var hello = document.querySelector('.hello');
    hello.innerHTML = "<h1>Hello ".concat(name, "</h1>");
}
function add() {
    var num1 = document.querySelector('#num1');
    var num2 = document.querySelector('#num2');
    var result = Number(num1.value) + Number(num2.value);
    var result_div = document.querySelector('#result');
    result_div.innerHTML = result.toString();
}
function TypeNumGuard() {
    var num_check = Number(document.querySelector('#num-check'));
    var checkResult = document.querySelector('#checkResult');
    if (typeof num_check === 'number') {
        checkResult.innerHTML = 'Number';
    }
    else {
        checkResult.innerHTML = 'Not a Number';
    }
}
function TypeStrGuard() {
    var check = document.querySelector('#check');
    var checkResult = document.querySelector('#checkResult');
    if (typeof check.value === 'string') {
        checkResult.innerHTML = 'String';
    }
    else {
        checkResult.innerHTML = 'Not a String';
    }
}
function displayAge() {
    var age = document.querySelector('#age');
    var age_div = document.querySelector('.ageResult');
    if (typeof age === 'string') {
        age_div.innerHTML = "Age is a string";
    }
}
function displayInfo(info) {
    var info_div = document.querySelector('.info');
    if ('age' in info) {
        info_div.innerHTML = " Person ".concat(info.name, " is accessed");
    }
    else {
        info_div.innerHTML = " Company ".concat(info.name, " is accessed");
    }
}
var person = { name: 'John', age: 30 };
var company = { name: 'John_Company', employees: 30 };
displayInfo(company);
//Assertion DEmo
var someValue = 'this is a string';
var strLength = someValue.length;
function findLength(someValue) {
    var assertionResult = document.querySelector('#assertion-result');
    var strLength = someValue.length;
    assertionResult.innerHTML = strLength.toString();
}
//Class Demo
var Dog = /** @class */ (function () {
    function Dog() {
    }
    Dog.prototype.woof = function () {
        console.log('DOg : woof');
    };
    return Dog;
}());
var Cat = /** @class */ (function () {
    function Cat() {
    }
    Cat.prototype.meow = function () {
        console.log(' Cat : meow');
    };
    return Cat;
}());
function MakeSound(animal) {
    if (animal instanceof Dog) {
        animal.woof();
    }
    else {
        animal.meow();
    }
}
var dog = new Dog();
var cat = new Cat();
function showSound() {
    var animal = document.querySelector('#animal-name');
    if (animal.value == 'dog') {
        var dog = new Dog();
        MakeSound(dog);
    }
    else {
        var cat = new Cat();
        MakeSound(cat);
    }
}
