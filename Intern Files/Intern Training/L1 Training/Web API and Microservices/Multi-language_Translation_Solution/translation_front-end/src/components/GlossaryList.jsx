//GlossaryList.jsx

import React, { useState } from 'react';

const GlossaryList = ({ glossaries, onEdit, onDelete }) => {
    const [searchTerm, setSearchTerm] = useState('');

    const handleSearch = () => {
        const results = glossaries.filter(g =>
            g.word.toLowerCase().includes(searchTerm.toLowerCase())
        );
        const message = results.length
            ? 'Search Results:\n' + results.map(g => `Word: ${g.word} \nMeaning: ${g.meaning} \nAdditional Notes: ${g.notes}`).join('\n')
            : 'No matching glossaries found.';
        alert(message);
    };

    if (!glossaries || glossaries.length === 0) {
        return <p>No glossaries found.</p>;
    }

    return (
        <>
            <h2>Glossary Search:</h2>
            <div style={{ marginBottom: '40px', display: "flex" }}>
                <input
                    type="text"
                    placeholder="Enter the word."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <button onClick={handleSearch}>Search</button>
            </div>

            <h2>Glossary List</h2>
            <table className="list" style={{ borderCollapse: 'collapse', width: '100%', marginBottom: '80px' }}>
                <thead>
                    <tr>
                        <th>Word</th>
                        <th>Meaning</th>
                        <th>Additional Notes</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {glossaries.map((g) => (
                        <tr key={g.id}>
                            <td>{g.word}</td>
                            <td>{g.meaning}</td>
                            <td>{g.notes}</td>
                            <td>
                                <button onClick={() => onEdit(g)}>Edit</button>
                            </td>
                            <td>
                                <button onClick={() => onDelete(g.id)}>Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </>
    );
};

export default GlossaryList;
