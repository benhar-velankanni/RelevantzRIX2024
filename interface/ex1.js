var person = {
    name: 'Max',
    age: 30,
    greet: function () {
        console.log('Hello, I am ' + this.name);
    }
};
person.greet();
