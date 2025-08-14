import React, { useState } from 'react';

const TeacherList = ({ teachers, onEdit, onDelete }) => {
    const [searchTerm, setSearchTerm] = useState('');

    const handleSearch = () => {
        const results = teachers.filter(t =>
            t.name.toLowerCase().includes(searchTerm.toLowerCase())
        );
        const message = results.length
            ? 'Search Results:\n' + results.map(t => `Teacher Name: ${t.name} \nSubject: ${t.subject} \nDate Of Joining: ${t.dateOfJoining}`).join('\n')
            : 'No matching students found.';
        alert(message);
    };

    if (!teachers || teachers.length === 0) {
        return <p>No teachers found.</p>;
    }

    return(
        <>
            <h2>Teacher Search:</h2>
            <div style={{ marginBottom: '20px', display: "flex" }}>
                <input
                    type="text"
                    placeholder="Enter teacher name"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <button onClick={handleSearch}>Search</button>
            </div>

            <h2>Teacher List</h2>
            <table className="list" style={{ borderCollapse: 'collapse', width: '100%' }}>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Subject</th>
                        <th>Date of Joining</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {teachers.map((t) => (
                        <tr key={t.id}>
                            <td><strong>{t.name}</strong></td>
                            <td>{t.subject}</td>
                            <td>{t.dateOfJoining}</td>
                            <td>
                                <button onClick={() => onEdit(t)}>Edit</button>
                            </td>
                            <td>
                                <button onClick={() => onDelete(t.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default TeacherList;