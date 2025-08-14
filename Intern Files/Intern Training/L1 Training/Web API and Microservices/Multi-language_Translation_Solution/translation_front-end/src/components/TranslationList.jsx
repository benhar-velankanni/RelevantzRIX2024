//TranslationList.jsx

import React, { useState } from 'react';

const TranslationList = ({ translations, onEdit, onDelete }) => {
    const [searchTerm, setSearchTerm] = useState('');

    const handleSearch = () => {
        const results = translations.filter(t =>
            t.translationString.toLowerCase().includes(searchTerm.toLowerCase())
        );
        const message = results.length
            ? 'Search Results:\n' + results.map(t => `Translation String: ${t.translationString} \nTranslate From: ${t.fromLang} \nTranslate To: ${t.toLang}`).join('\n')
            : 'No matching translations found.';
        alert(message);
    };

    if (!translations || translations.length === 0) {
        return <p>No translations found.</p>;
    }

    return (
        <>
            <h2>Translation Search:</h2>
            <div style={{ marginBottom: '40px', display: "flex" }}>
                <input
                    type="text"
                    placeholder="Enter the translation string."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                />
                <button onClick={handleSearch}>Search</button>
            </div>

            <h2>Translation List</h2>
            <table className="list" style={{ borderCollapse: 'collapse', width: '100%', marginBottom: '80px' }}>
                <thead>
                    <tr>
                        <th>Translation String</th>
                        <th>Translate From</th>
                        <th>Translate To</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {translations.map((t) => (
                        <tr key={t.id}>
                            <td>{t.translationString}</td>
                            <td>{t.fromLang}</td>
                            <td>{t.toLang}</td>
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

export default TranslationList;
