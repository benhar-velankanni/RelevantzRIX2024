"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var form_1 = require("./form");
var form = document.getElementById('exampleform');
form.addEventListener('submit', function (event) {
    event.preventDefault();
    var textInput = new form_1.TextInput(document.getElementById('name').value);
    var numberInput = new form_1.NumberInput(document.getElementById('price').value);
    var checkboxInput = new form_1.CheckboxInput(document.getElementById('quantity').checked);
    (0, form_1.processFormInput)(textInput);
    (0, form_1.processFormInput)(numberInput);
    (0, form_1.processFormInput)(checkboxInput);
});
