//TranslationPage.jsx

import React, { useEffect, useState } from 'react';
import axios from 'axios';
import TranslationForm from '../components/TranslationForm';
import TranslationList from '../components/TranslationList';
import '../App.css'
const TranslationAPI_BASE = 'http://localhost:5082/gateway/TranslationEngine';

function TranslationPage() {
    const [translations, settranslations] = useState([]);
    const [editing, setEditing] = useState(null);
    const [version, setVersion] = useState(0);

    useEffect(() => {
        fetchtranslations();

        document.title = "Translation Manager";

    }, [version]);

    const fetchtranslations = () => {
        axios.get(TranslationAPI_BASE).then(res => settranslations(res.data));
    };

    const addTranslation = (Translation) => {
        axios.post(TranslationAPI_BASE, Translation).then(res => {
            settranslations([...translations, res.data]);
        });
    };

    const updateTranslation = (id, updated) => {
        axios.put(`${TranslationAPI_BASE}/${id}`, updated).then(res => {
            settranslations(translations.map(p => (p.id === id ? res.data : p)));
            setVersion(prev => prev + 1);
            setEditing(null);
        });
    };

    const deleteTranslation = (id) => {
        axios.delete(`${TranslationAPI_BASE}/${id}`).then(() => {
            settranslations(translations.filter(p => p.id !== id));
        });
    };

    return (
        <div className="container">
            <div style={{ marginBottom: '40px' }} >
                <h2>Translation Manager</h2>
                <TranslationForm
                    onSubmit={editing ? (data) => updateTranslation(editing.id, data) : addTranslation}
                    initial={editing || { translationString: '', fromLang: '', toLang: '' }}
                />
            </div>
            <div>
                <TranslationList
                    key={version}
                    translations={translations}
                    onEdit={setEditing}
                    onDelete={deleteTranslation}
                />
            </div>
        </div>
    );
}

export default TranslationPage;
