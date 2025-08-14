//TranslationForm.jsx

import React, { useState, useEffect } from 'react';

const TranslationForm = ({ onSubmit, initial }) => {
    const [form, setForm] = useState(initial);

    useEffect(() => {
        setForm(initial);
    }, [initial]);

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(form);
        setForm({ translationString: '', fromLang: '', toLang: '' });
    };


    return (
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Enter the translation string."
                                value={form.translationString || ''}
                                onChange={(e) => setForm({ ...form, translationString: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Translate From..."
                                value={form.fromLang || ''}
                                onChange={(e) => setForm({ ...form, fromLang: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Translate To..."
                                value={form.toLang || ''}
                                onChange={(e) => setForm({ ...form, toLang: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit">{initial.id ? 'Update' : 'Add'} Translation</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </form>
    );
};

export default TranslationForm;
