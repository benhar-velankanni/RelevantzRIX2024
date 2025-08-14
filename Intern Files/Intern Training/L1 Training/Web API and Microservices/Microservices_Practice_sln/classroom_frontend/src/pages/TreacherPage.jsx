import React, { useEffect, useState } from 'react';
import axios from 'axios';
import TeacherForm from '../components/TeacherForm';
import TeacherList from '../components/TeacherList';
import '../App.css'
const TeacherAPI_BASE = 'http://localhost:5166/gateway/TeacherAPI';

function TeacherPage() {
    const [teachers, setTeachers] = useState([]);
    const [editing, setEditing] = useState(null);
    const [version, setVersion] = useState(0);

    useEffect(() => {
        fetchTeachers();
    }, [version]);

    const fetchTeachers = () => {
        axios.get(TeacherAPI_BASE).then(res => setTeachers(res.data));
    };

    const addTeacher = (teacher) => {
        axios.post(TeacherAPI_BASE, teacher).then(res => {
            setTeachers([...teachers, res.data]);
        });
    };

    const updateTeacher = (id, updated) => {
        axios.put(`${TeacherAPI_BASE}/${id}`, updated).then(res => {
            setTeachers(teachers.map(p => (p.id === id ? res.data : p)));
            setVersion(prev => prev + 1);
            setEditing(null);
        });
    };

    const deleteTeacher = (id) => {
        axios.delete(`${TeacherAPI_BASE}/${id}`).then(() => {
            setTeachers(teachers.filter(p => p.id !== id));
        });
    };

    return (
        <div className="container">
            <div>
                <h2>Teacher Manager</h2>
                <TeacherForm
                    onSubmit={editing ? (data) => updateTeacher(editing.id, data) : addTeacher}
                    initial={editing || { name: '', subject: '', dateOfJoining: '' }}
                />
            </div>
            <br></br>
            <br></br>
            <div>
                <TeacherList
                    key={teachers }
                    teachers={teachers}
                    onEdit={setEditing}
                    onDelete={deleteTeacher}
                />
            </div>
        </div>
    );
}

export default TeacherPage;