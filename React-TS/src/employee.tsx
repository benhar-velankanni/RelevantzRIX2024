import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_URL = 'http://localhost:3000/emp';

type EmployeeType = {
    id: number;
    empname: string;
    empemail: string;
    empnumber: string;
    empaddress: string;
};

const Employee = () => {
    const [employees, setEmployees] = useState<EmployeeType[]>([]);
    const [emp, setEmp] = useState<Omit<EmployeeType, 'id'>>({
        empname: '',
        empemail: '',
        empnumber: '',
        empaddress: '',
    });

    const [isEdit, setIsEdit] = useState<boolean>(false);    
    const [editId, setEditId] = useState<number | null>(null);
    const [searchTerm, setSearchTerm] = useState<string>('');

    const fetchEmployees = async () => {
        const response = await axios.get(API_URL);
        setEmployees(response.data);
    };

    useEffect(() => {
        fetchEmployees();
    }, []);

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (isEdit && editId !== null) {
            await axios.put(`${API_URL}/${editId}`, { id: editId, ...emp });
        } else {
            await axios.post(API_URL, emp);
        }
        resetForm();
        fetchEmployees();
    };

    const handleDelete = async (id: number) => {
        await axios.delete(`${API_URL}/${id}`);
        fetchEmployees();
    };

    const resetForm = () => {
        setEmp({
            empname: '',
            empemail: '',
            empnumber: '',
            empaddress: '',
        });
        setIsEdit(false);
        setEditId(null);
    };

    const searchedEmployees = employees.filter((emp) => emp.empname.toLowerCase().includes(searchTerm.toLowerCase()));

    return (
        <div className="ui container">
            <h2 className="ui header">{isEdit ? 'Update Contact' : 'Add Contact'}</h2>
            <form className="ui form" onSubmit={handleSubmit}>
                <div className="field">
                    <label> Name</label>
                    <input
                        type="text"
                        id="empname"
                        value={emp.empname}
                        onChange={(e) => setEmp({ ...emp, empname: e.target.value })}
                    />
                </div>
                <div className="field">
                    <label> Mail</label>
                    <input type="text" 
                    id="empemail"
                    value={emp.empemail}
                    onChange={(e) => setEmp({...emp, empemail: e.target.value})}
                    />
                </div>
                <div className="field">
                    <label> Number</label>
                    <input type="text"
                    id="empnumber"
                    value={emp.empnumber}
                    onChange={(e) => setEmp({...emp,empnumber: e.target.value})} />
                </div>
                <div className="field">
                    <label>Address</label>
                    <input type="text"
                    id="empaddress"
                    value={emp.empaddress}
                    onChange={(e) => setEmp({...emp, empaddress:e.target.value})} />
                </div>

                <button className="ui primary button" type="submit">
          {isEdit ? 'Update' : 'Submit'}
        </button>
        <button className="ui button" type="button" onClick={resetForm}>
          Cancel
        </button>
      </form>

      <h3>Employee List</h3>
      <table className="ui celled table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Mail</th>
            <th>Number</th>
            <th>Address</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((emp) => (
            <tr key={emp.id}>
              <td>{emp.empname}</td>
              <td>{emp.empemail}</td>
              <td>{emp.empnumber}</td>
              <td>{emp.empaddress}</td>
              <td>

              <div className ="ui buttons">
  <button className="ui green button" onClick={() => {
                  setEmp(emp);
                  setIsEdit(true);
                  setEditId(emp.id);
                }}>Edit</button>
  <div className="or"></div>
  <button className="ui red button" onClick={() => handleDelete(emp.id)}>Delete</button>
</div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>  

      <div className="field">
        <label>Search Employees</label>
        <input
          type="text"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      <h3>Search Results</h3>
      <table className="ui celled table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Mail</th>
            <th>Number</th>
            <th>Address</th>
          </tr>
        </thead>
        <tbody>
          {searchedEmployees.map((emp) => (
            <tr key={emp.id}>
              <td>{emp.empname}</td>
              <td>{emp.empemail}</td>
              <td>{emp.empnumber}</td>
              <td>{emp.empaddress}</td>
            </tr>
          ))}
        </tbody>
      </table>  
        </div>
    );
};

export default Employee;

