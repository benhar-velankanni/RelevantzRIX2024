import React from "react";
import { useState, useEffect } from "react";
import "./EmployeeForm.css";

interface EmployeeFormProps {
  fetchEmployees: () => void;
  isEditing: boolean;
  editId: number | null;
  initialData: {
    empId: number;
    empName: string;
    empAge: number;
    empDesignation: string;
  };
  handleUpdate: (id: number, empData: any) => Promise<void>;
  handleCreate: (empData: any) => Promise<void>;
}

const EmployeeForm: React.FC<EmployeeFormProps> = ({
  fetchEmployees,
  isEditing,
  editId,
  initialData = { empId: 0, empName: "", empAge: 0, empDesignation: "" },
  handleUpdate,
  handleCreate,
}) => {
  const [empId, setEmpId] = useState(initialData.empId);
  const [empName, setEmpName] = useState(initialData.empName);
  const [empAge, setEmpAge] = useState(initialData.empAge);
  const [empDesignation, setEmpDesignation] = useState(
    initialData.empDesignation
  );

  useEffect(() => {
    setEmpId(initialData.empId || 0);
    setEmpName(initialData.empName || "");
    setEmpAge(initialData.empAge || 0);
    setEmpDesignation(initialData.empDesignation || "");
  }, [initialData]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (isEditing && editId !== null) {
      await handleUpdate(editId, { empId, empName, empAge, empDesignation });
    } else {
      await handleCreate({ empId, empName, empAge, empDesignation });
    }
    fetchEmployees();
    setEmpId(0);
    setEmpName("");
    setEmpAge(0);
    setEmpDesignation("");
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit} noValidate>
        <div className="form-group">
          <table>
            <tr>
              <td style={{ textAlign: "left" }}>
                <label htmlFor="empId">Employee ID:</label>
              </td>
              <td>
                <input
                  type="number"
                  id="empId"
                  value={empId}
                  onChange={(e) => setEmpId(parseInt(e.target.value))}
                />
              </td>
            </tr>
            <tr>
              <td style={{ textAlign: "left" }}>
                <label htmlFor="empName">Employee Name:</label>
              </td>
              <td>
                <input
                  type="text"
                  id="empName"
                  value={empName}
                  onChange={(e) => setEmpName(e.target.value)}
                />
              </td>
            </tr>
            <tr>
              <td style={{ textAlign: "left" }}>
                <label htmlFor="empAge">Employee Age:</label>
              </td>
              <td>
                <input
                  type="number"
                  id="empAge"
                  value={empAge}
                  onChange={(e) => setEmpAge(parseInt(e.target.value))}
                />
              </td>
            </tr>
            <tr>
              <td style={{ textAlign: "left" }}>
                <label htmlFor="empDesignation">Employee Designation:</label>
              </td>
              <td>
                <input
                  type="text"
                  id="empDesignation"
                  value={empDesignation}
                  onChange={(e) => setEmpDesignation(e.target.value)}
                />
              </td>
            </tr>
            <br />
            <br />
            <tr>
              <td colSpan={2}>
                <button className="submit-button" type="submit">
                  {isEditing ? "Update Employee" : "Add Employee"}
                </button>
              </td>
            </tr>
          </table>
        </div>
      </form>
    </div>
  );
};

export default EmployeeForm;
