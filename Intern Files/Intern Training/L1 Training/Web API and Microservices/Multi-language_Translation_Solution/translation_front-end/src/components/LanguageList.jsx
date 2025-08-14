//LanguageList.jsx

import React, { useState } from 'react';

const LanguageList = ({ languages, onEdit, onDelete }) => {
    const [searchTerm, setSearchTerm] = useState('');

    const handleSearch = () => {
        const results = languages.filter(l =>
            l.name.toLowerCase().includes(searchTerm.toLowerCase())
        );
        const message = results.length
            ? 'Search Results:\n' + results.map(l => `Name: ${l.name} \nOrigin: ${l.origin} \nAdditional Notes: ${l.notes}`).join('\n')
            : 'No matching languages found.';
        alert(message);
    };

    if (!languages || languages.length === 0) {
        return <p>No languages found.</p>;
    }

    return (
        <>
            <h2>Language Search:</h2>
            <div style={{ marginBottom: '40px', display: "flex" }}>
                <input
                    type="text"
                    placeholder="Enter the language name."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <button onClick={handleSearch}>Search</button>
            </div>

            <h2>Language List</h2>
            <table className="list" style={{ borderCollapse: 'collapse', width: '100%', marginBottom: '80px' }}>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Origin</th>
                        <th>Additional Notes</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {languages.map((l) => (
                        <tr key={l.id}>
                            <td>{l.name}</td>
                            <td>{l.origin}</td>
                            <td>{l.notes}</td>
                            <td>
                                <button onClick={() => onEdit(l)}>Edit</button>
                            </td>
                            <td>
                                <button onClick={() => onDelete(l.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default LanguageList;
