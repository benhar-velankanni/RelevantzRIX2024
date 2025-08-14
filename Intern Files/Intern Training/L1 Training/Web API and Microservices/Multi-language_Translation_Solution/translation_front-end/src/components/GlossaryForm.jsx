//GlossaryForm.jsx

import React, { useState, useEffect } from 'react';

const GlossaryForm = ({ onSubmit, initial }) => {
    const [form, setForm] = useState(initial);

    useEffect(() => {
        setForm(initial);
    }, [initial]);

    const handleSubmit = (e) => {
        e.preventDefault();

        if (form.notes == null || form.notes == "") {
            form.notes = "No Notes."
        }

        onSubmit(form);
        setForm({ word: '', meaning: '', notes: '' });
    };


    return (
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Enter the word."
                                value={form.word || ''}
                                onChange={(e) => setForm({ ...form, word: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Enter the meaning."
                                value={form.meaning || ''}
                                onChange={(e) => setForm({ ...form, meaning: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Any additional notes?"
                                value={form.notes || ''}
                                onChange={(e) => setForm({ ...form, notes: e.target.value })}
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit">{initial.id ? 'Update' : 'Add'} Glossary</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </form>
    );
};

export default GlossaryForm;
