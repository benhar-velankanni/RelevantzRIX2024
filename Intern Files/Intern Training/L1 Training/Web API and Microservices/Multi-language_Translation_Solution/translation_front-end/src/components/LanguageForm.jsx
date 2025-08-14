//LanguageForm.jsx

import React, { useState, useEffect } from 'react';

const LanguageForm = ({ onSubmit, initial }) => {
    const [form, setForm] = useState(initial);

    useEffect(() => {
        setForm(initial);
    }, [initial]);

    const handleSubmit = (e) => {
        e.preventDefault();

        if (form.origin == null || form.origin == "") {
            form.origin = "Not Given."
        }

        if (form.notes == null || form.notes == "") {
            form.notes = "No Notes."
        }

        onSubmit(form);
        setForm({ name: '', origin: '', notes: '' });
    };


    return (
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Enter the name."
                                value={form.name || ''}
                                onChange={(e) => setForm({ ...form, name: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Enter the origin."
                                value={form.origin || ''}
                                onChange={(e) => setForm({ ...form, origin: e.target.value })}
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
                            <button type="submit">{initial.id ? 'Update' : 'Add'} Language</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </form>
    );
};

export default LanguageForm;
