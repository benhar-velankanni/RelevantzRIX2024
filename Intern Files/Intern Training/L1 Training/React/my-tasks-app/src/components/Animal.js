import "../App.css";
import React, { useState } from "react";

class Animal {
  constructor(name) {
    this.name = name;
  }

  eat() {
    return `${this.name} is eating.`;
  }

  sleep() {
    return `${this.name} is sleeping.`;
  }
}

const App = () => {
  const [animalName, setAnimalName] = useState("");
  const [action, setAction] = useState("");

  const createAnimal = () => {
    const name = prompt("Enter animal name:");
    if (!name) return;
    setAnimalName(name);
    setAction("");
  };

  const handleEat = () => {
    if (!animalName) return;
    const animal = new Animal(animalName);
    setAction(animal.eat());
  };

  const handleSleep = () => {
    if (!animalName) return;
    const animal = new Animal(animalName);
    setAction(animal.sleep());
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Animal Action Simulator</h1>
        <p>
          <i>{action}</i>
        </p>
        <div>
          <button onClick={createAnimal}>Create Animal</button>
          <button onClick={handleEat}>Eat</button>
          <button onClick={handleSleep}>Sleep</button>
        </div>
      </header>
    </div>
  );
};

export default App;
