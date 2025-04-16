var TextInput = /** @class */ (function () {
    function TextInput(value) {
        this.value = value;
    }
    TextInput.prototype.getValue = function () {
        return this.value;
    };
    return TextInput;
}());
var NumberInput = /** @class */ (function () {
    function NumberInput(value) {
        this.value = value;
    }
    NumberInput.prototype.getValue = function () {
        return this.value;
    };
    return NumberInput;
}());
var DateInput = /** @class */ (function () {
    function DateInput(value) {
        this.value = value;
    }
    DateInput.prototype.getValue = function () {
        return this.value;
    };
    return DateInput;
}());
var CheckBoxInput = /** @class */ (function () {
    function CheckBoxInput(checked) {
        this.checked = checked;
    }
    CheckBoxInput.prototype.getValue = function () {
        return this.checked;
    };
    return CheckBoxInput;
}());
function processInput(input) {
    if (input instanceof TextInput) {
        console.log("Text input value : ".concat(input.getValue()));
    }
    else if (input instanceof DateInput) {
        console.log("Date input : ".concat(input.getValue()));
    }
    else if (input instanceof CheckBoxInput) {
        console.log("Checkbox input : ".concat(input.getValue()));
    }
    else if (input instanceof NumberInput) {
        console.log("Number input : ".concat(input.getValue()));
    }
}
var form = document.getElementById('example-form');
form.addEventListener('submit', function (event) {
    event.preventDefault();
    var name = document.getElementById('name');
    var age = document.getElementById('age');
    var dob = document.getElementById('dob');
    var check = document.getElementById('check');
    var nameInput = new TextInput(name.value);
    var ageInput = new NumberInput(Number(age.value));
    var birthInput = new DateInput(new Date(dob.value));
    var checkInput = new CheckBoxInput(check.checked);
    processInput(nameInput);
    processInput(ageInput);
    processInput(birthInput);
    processInput(checkInput);
});
