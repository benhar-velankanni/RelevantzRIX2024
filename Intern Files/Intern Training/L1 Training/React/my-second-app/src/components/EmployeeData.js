import "../App.css";
import Employee from "./Employee";

function EmployeeData() {
  return (
    <div className="App">
      <header className="App-header">
        <Employee
          Name="Nisanth Saravanan"
          Designation="Intern Software Engineer"
          Age="21"
          Department="IT"
        />
      </header>
    </div>
  );
}

export default EmployeeData;
