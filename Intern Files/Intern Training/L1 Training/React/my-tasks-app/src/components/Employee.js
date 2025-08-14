import "../App.css";
import React, { useState } from "react";

class Employee {
  constructor(name, email, age, designation, department) {
    this.name = name;
    this.email = email;
    this.age = age;
    this.designation = designation;
    this.department = department;
  }
}

const initialData = [];

function DisplayDetails({ employee }) {
  if (!employee) return <p>No Employee Data</p>;
  return (
    <div className="table">
      <table>
        <tbody>
          <tr>
            <td className="var">Full Name:</td>
            <td className="varValue">{employee.name}</td>
          </tr>
          <tr>
            <td className="var">Email:</td>
            <td className="varValue">{employee.email}</td>
          </tr>
          <tr>
            <td className="var">Age:</td>
            <td className="varValue">{employee.age}</td>
          </tr>
          <tr>
            <td className="var">Designation:</td>
            <td className="varValue">{employee.designation}</td>
          </tr>
          <tr>
            <td className="var">Department:</td>
            <td className="varValue">{employee.department}</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

const App = () => {
  const [employees, setEmployees] = useState(initialData);
  const [currentIndex, setCurrentIndex] = useState(0);

  const addEmployee = () => {
    const name = prompt("Enter name:");
    const email = prompt("Enter email:");
    const age = prompt("Enter age:");
    const designation = prompt("Enter designation:");
    const department = prompt("Enter department:");

    if (!name || !email || !age || !designation || !department) return;

    const newEmp = new Employee(name, email, age, designation, department);
    const newList = [...employees, newEmp];
    setEmployees(newList);
    setCurrentIndex(newList.length - 1);
  };

  const nextEmployee = () => {
    setCurrentIndex((currentIndex + 1) % employees.length);
  };

  const prevEmployee = () => {
    setCurrentIndex((currentIndex - 1 + employees.length) % employees.length);
  };

  const calculateSalary = () => {
    if (!employees[currentIndex]) return;
    const employee = employees[currentIndex];
    const salary = employee.age * 1000;
    alert(`Salary of ${employee.name} is ${salary}`);
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>Employee Details</h1>
        <DisplayDetails employee={employees[currentIndex]} />
        <div>
          <button onClick={prevEmployee}>Previous</button>
          <button onClick={addEmployee}>Add</button>
          <button onClick={calculateSalary}>Calculate Salary</button>
          <button onClick={nextEmployee}>Next</button>
        </div>
      </header>
    </div>
  );
};

export default App;
