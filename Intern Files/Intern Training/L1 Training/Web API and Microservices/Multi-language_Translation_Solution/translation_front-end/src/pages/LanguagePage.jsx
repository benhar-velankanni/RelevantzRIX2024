//LanguagePage.jsx

import React, { useEffect, useState } from 'react';
import axios from 'axios';
import LanguageForm from '../components/LanguageForm';
import LanguageList from '../components/LanguageList';
import '../App.css'
const LanguageAPI_BASE = 'http://localhost:5082/gateway/LanguageDetection';

function LanguagePage() {
    const [languages, setlanguages] = useState([]);
    const [editing, setEditing] = useState(null);
    const [version, setVersion] = useState(0);

    useEffect(() => {
        fetchlanguages();

        document.title = "Language Manager";

    }, [version]);

    const fetchlanguages = () => {
        axios.get(LanguageAPI_BASE).then(res => setlanguages(res.data));
    };

    const addLanguage = (Language) => {
        axios.post(LanguageAPI_BASE, Language).then(res => {
            setlanguages([...languages, res.data]);
        });
    };

    const updateLanguage = (id, updated) => {
        axios.put(`${LanguageAPI_BASE}/${id}`, updated).then(res => {
            setlanguages(languages.map(p => (p.id === id ? res.data : p)));
            setVersion(prev => prev + 1);
            setEditing(null);
        });
    };

    const deleteLanguage = (id) => {
        axios.delete(`${LanguageAPI_BASE}/${id}`).then(() => {
            setlanguages(languages.filter(p => p.id !== id));
        });
    };

    return (
        <div className="container">
            <div style={{ marginBottom: '40px' }} >
                <h2>Language Manager</h2>
                <LanguageForm
                    onSubmit={editing ? (data) => updateLanguage(editing.id, data) : addLanguage}
                    initial={editing || { name: '', origin: '', notes: '' }}
                />
            </div>
            <div>
                <LanguageList
                    key={version}
                    languages={languages}
                    onEdit={setEditing}
                    onDelete={deleteLanguage}
                />
            </div>
        </div>
    );
}

export default LanguagePage;
