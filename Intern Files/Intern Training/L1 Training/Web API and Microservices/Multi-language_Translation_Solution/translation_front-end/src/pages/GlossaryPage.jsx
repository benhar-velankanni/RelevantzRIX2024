//GlossaryPage.jsx

import React, { useEffect, useState } from 'react';
import axios from 'axios';
import GlossaryForm from '../components/GlossaryForm';
import GlossaryList from '../components/GlossaryList';
import '../App.css'
const GlossaryAPI_BASE = 'http://localhost:5082/gateway/GlossaryManagement';

function GlossaryPage() {
    const [glossaries, setglossaries] = useState([]);
    const [editing, setEditing] = useState(null);
    const [version, setVersion] = useState(0);

    useEffect(() => {
        fetchglossaries();

        document.title = "Glossary Manager";

    }, [version]);

    const fetchglossaries = () => {
        axios.get(GlossaryAPI_BASE).then(res => setglossaries(res.data));
    };

    const addGlossary = (Glossary) => {
        axios.post(GlossaryAPI_BASE, Glossary).then(res => {
            setglossaries([...glossaries, res.data]);
        });
    };

    const updateGlossary = (id, updated) => {
        axios.put(`${GlossaryAPI_BASE}/${id}`, updated).then(res => {
            setglossaries(glossaries.map(p => (p.id === id ? res.data : p)));
            setVersion(prev => prev + 1);
            setEditing(null);
        });
    };

    const deleteGlossary = (id) => {
        axios.delete(`${GlossaryAPI_BASE}/${id}`).then(() => {
            setglossaries(glossaries.filter(p => p.id !== id));
        });
    };

    return (
        <div className="container">
            <div style={{ marginBottom: '40px' }} >
                <h2>Glossary Manager</h2>
                <GlossaryForm
                    onSubmit={editing ? (data) => updateGlossary(editing.id, data) : addGlossary}
                    initial={editing || { word: '', meaning: '', notes: '' }}
                />
            </div>
            <div>
                <GlossaryList
                    key={version}
                    glossaries={glossaries}
                    onEdit={setEditing}
                    onDelete={deleteGlossary}
                />
            </div>
        </div>
    );
}

export default GlossaryPage;
