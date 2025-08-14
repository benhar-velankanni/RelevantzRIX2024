//StudentPage.jsx

import React, { useEffect, useState } from 'react';
import axios from 'axios';
import StudentForm from '../components/StudentForm';
import StudentList from '../components/StudentList';
import '../App.css'
const StudentAPI_BASE = 'http://localhost:5066/gateway/StudentAPI';

function StudentPage() {
    const [students, setStudents] = useState([]);
    const [editing, setEditing] = useState(null);
    const [version, setVersion] = useState(0);

    useEffect(() => {
        fetchStudents();
    }, [version]);

    const fetchStudents = () => {
        axios.get(StudentAPI_BASE).then(res => setStudents(res.data));
    };

    const addStudent = (student) => {
        axios.post(StudentAPI_BASE, student).then(res => {
            setStudents([...students, res.data]);
        });
    };

    const updateStudent = (id, updated) => {
        axios.put(`${StudentAPI_BASE}/${id}`, updated).then(res => {
            setStudents(students.map(p => (p.id === id ? res.data : p)));
            setVersion(prev => prev + 1);
            setEditing(null);
        });
    };

    const deleteStudent = (id) => {
        axios.delete(`${StudentAPI_BASE}/${id}`).then(() => {
            setStudents(students.filter(p => p.id !== id));
        });
    };

    return (
        <div className="container">
            <div style={{ marginBottom: '20px' }} >
                <h2>Student Manager</h2>
                <StudentForm
                    onSubmit={editing ? (data) => updateStudent(editing.id, data) : addStudent}
                    initial={editing || { name: '', classAndSection: '', dateOfBirth: '' }}
                />
            </div>
            <div>
                <StudentList
                    key={version}
                    students={students}
                    onEdit={setEditing}
                    onDelete={deleteStudent}
                />
            </div>
        </div>
    );
}

export default StudentPage;