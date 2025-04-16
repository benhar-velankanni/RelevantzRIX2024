"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.CheckboxInput = exports.NumberInput = exports.TextInput = void 0;
exports.processFormInput = processFormInput;
var TextInput = /** @class */ (function () {
    function TextInput(value) {
        this.value = value;
    }
    TextInput.prototype.getValue = function () {
        return this.value;
    };
    return TextInput;
}());
exports.TextInput = TextInput;
var NumberInput = /** @class */ (function () {
    function NumberInput(value) {
        this.value = value;
    }
    NumberInput.prototype.getValue = function () {
        return this.value;
    };
    return NumberInput;
}());
exports.NumberInput = NumberInput;
var CheckboxInput = /** @class */ (function () {
    function CheckboxInput(checked) {
        this.checked = checked;
    }
    CheckboxInput.prototype.getValue = function () {
        return this.checked;
    };
    return CheckboxInput;
}());
exports.CheckboxInput = CheckboxInput;
function processFormInput(input) {
    if (input instanceof TextInput) {
        console.log("Name is: ".concat(input.getValue()));
    }
    else if (input instanceof CheckboxInput) {
        console.log("Terms and Condition: ".concat(input.getValue()));
    }
}
