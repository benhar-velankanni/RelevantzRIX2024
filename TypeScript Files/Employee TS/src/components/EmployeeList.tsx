import React, { useState, useEffect } from "react";
import {
  fetchEmployees,
  deleteEmployee,
  updateEmployee,
  createEmployee,
} from "../services/api";
import EmployeeForm from "./EmployeeForm";
import "./EmployeeList.css";

const EmployeeList: React.FC = () => {
  const [employees, setEmployees] = useState<any[]>([]);
  const [editingEmployee, setEditingEmployee] = useState<any | null>(null);

  useEffect(() => {
    fetchEmployees().then(setEmployees);
  }, []);

  const handleDelete = async (id: number) => {
    await deleteEmployee(id);
    fetchEmployees().then(setEmployees);
  };

  const handleEdit = (employee: any) => {
    setEditingEmployee(employee);
  };

  const handleUpdate = async (id: number, employee: any) => {
    if (
      employee.empId === 0 ||
      employee.empName === "" ||
      employee.empAge === 0 ||
      employee.empDesignation === ""
    ) {
      alert("All fields are required!");
      return;
    }
    if (!employee.empName) {
      alert("Employee name is required");
      return;
    }
    if (employee.empAge < 0) {
      alert("Employee age must be a positive number");
      return;
    }
    if (!employee.empDesignation) {
      alert("Employee designation is required");
      return;
    }
    await updateEmployee(id, employee);
  };

  const handleCreate = async (employee: any) => {
    if (
      employee.empId === 0 ||
      employee.empName === "" ||
      employee.empAge === 0 ||
      employee.empDesignation === ""
    ) {
      alert("All fields are required!");
      return;
    }
    if (!employee.empName) {
      alert("Employee name is required");
      return;
    }
    if (employee.empAge < 0) {
      alert("Employee age must be a positive number");
      return;
    }
    if (!employee.empDesignation) {
      alert("Employee designation is required");
      return;
    }
    await createEmployee(employee);
    fetchEmployees().then(setEmployees);
  };

  if (employees.length === 0) {
    return (
      <div>
        <h2>Employee List</h2>
        <EmployeeForm
          fetchEmployees={() => fetchEmployees().then(setEmployees)}
          isEditing={!!editingEmployee}
          editId={editingEmployee !== null ? editingEmployee.id : null}
          initialData={
            editingEmployee || {
              empId: 0,
              empName: "",
              empAge: 0,
              empDesignation: "",
            }
          }
          handleUpdate={handleUpdate}
          handleCreate={handleCreate}
        />
        <h2>Employee List</h2>
        <p>No employees found.</p>
      </div>
    );
  } else {
    return (
      <div>
        <h2>Employee Form</h2>
        <EmployeeForm
          fetchEmployees={() => fetchEmployees().then(setEmployees)}
          isEditing={!!editingEmployee}
          editId={editingEmployee !== null ? editingEmployee.id : null}
          initialData={
            editingEmployee || {
              empId: 0,
              empName: "",
              empAge: 0,
              empDesignation: "",
            }
          }
          handleUpdate={handleUpdate}
          handleCreate={handleCreate}
        />
        <br />
        <h2>Employee List</h2>
        <table className="user-table">
          <thead>
            <tr>
              <th>Employee ID</th>
              <th>Name</th>
              <th>Age</th>
              <th>Designation</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {employees.map((employee: any) => (
              <tr key={employee.id}>
                <td>{employee.empId}</td>
                <td>{employee.empName}</td>
                <td>{employee.empAge}</td>
                <td>{employee.empDesignation}</td>
                <td>
                  <button
                    className="edit-button"
                    onClick={() => handleEdit(employee)}
                  >
                    Edit
                  </button>
                  <button
                    className="delete-button"
                    onClick={() => handleDelete(employee.id)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
};

export default EmployeeList;
