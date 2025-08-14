//StudentList.jsx

import React, { useState } from 'react';

const StudentList = ({ students, onEdit, onDelete }) => {
    const [searchTerm, setSearchTerm] = useState('');

    const handleSearch = () => {
        const results = students.filter(s =>
            s.name.toLowerCase().includes(searchTerm.toLowerCase())
        );
        const message = results.length
            ? 'Search Results:\n' + results.map(s => `Student Name: ${s.name} \nClass and Section: ${s.classAndSection} \nDate Of Birth: ${s.dateOfBirth}`).join('\n')
            : 'No matching students found.';
        alert(message);
    };

    if (!students || students.length === 0) {
        return <p>No students found.</p>;
    }

    return (
        <>
            <h2>Student Search:</h2>
            <div style={{ marginBottom: '20px', display: "flex" }}>
                <input
                    type="text"
                    placeholder="Enter student name"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <button onClick={handleSearch}>Search</button>
            </div>

            <h2>Student List</h2>
            <table className="list" style={{ borderCollapse: 'collapse', width: '100%' }}>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Class & Section</th>
                        <th>Date of Birth</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {students.map((s) => (
                        <tr key={s.id}>
                            <td>{s.name}</td>
                            <td>{s.classAndSection}</td>
                            <td>{s.dateOfBirth}</td>
                            <td>
                                <button onClick={() => onEdit(s)}>Edit</button>
                            </td>
                            <td>
                                <button onClick={() => onDelete(s.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default StudentList;