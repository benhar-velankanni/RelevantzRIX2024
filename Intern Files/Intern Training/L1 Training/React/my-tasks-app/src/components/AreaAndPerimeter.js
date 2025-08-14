import "../App.css";
import React, { useState } from "react";

const App = () => {
  const [info, setInfo] = useState({ result: 0, shape: "", type: "" });

  const knowshape = (type) => {
    const shape = prompt("Enter shape (circle, square, rectangle, triangle):");

    let result = 0;

    if (type === "area") {
      if (shape === "circle") {
        const radius = parseFloat(prompt("Enter radius:"));
        result = Math.PI * radius * radius;
      } else if (shape === "square") {
        const side = parseFloat(prompt("Enter side:"));
        result = side * side;
      } else if (shape === "rectangle") {
        const length = parseFloat(prompt("Enter length:"));
        const width = parseFloat(prompt("Enter width:"));
        result = length * width;
      } else if (shape === "triangle") {
        const base = parseFloat(prompt("Enter base:"));
        const height = parseFloat(prompt("Enter height:"));
        result = (base * height) / 2;
      } else {
        alert("Invalid shape");
        return;
      }
    } else if (type === "perimeter") {
      if (shape === "circle") {
        const radius = parseFloat(prompt("Enter radius:"));
        result = 2 * Math.PI * radius;
      } else if (shape === "square") {
        const side = parseFloat(prompt("Enter side:"));
        result = 4 * side;
      } else if (shape === "rectangle") {
        const length = parseFloat(prompt("Enter length:"));
        const width = parseFloat(prompt("Enter width:"));
        result = 2 * (length + width);
      } else if (shape === "triangle") {
        const side1 = parseFloat(prompt("Enter side 1:"));
        const side2 = parseFloat(prompt("Enter side 2:"));
        const side3 = parseFloat(prompt("Enter side 3:"));
        result = side1 + side2 + side3;
      } else {
        alert("Invalid shape");
        return;
      }
    }

    setInfo({
      result: result.toFixed(2),
      shape: shape,
      type: type,
    });
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Calculate Area and Perimeter</h1>
        <p>
          {info.result !== 0 &&
            `The ${info.type} of a ${info.shape} is ${info.result}.`}
        </p>
        <div>
          <button onClick={() => knowshape("area")}>Calculate Area</button>
          <button onClick={() => knowshape("perimeter")}>
            Calculate Perimeter
          </button>
        </div>
      </header>
    </div>
  );
};

export default App;
