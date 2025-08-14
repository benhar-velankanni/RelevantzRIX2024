//StudentForm.jsx

import React, { useState, useEffect } from 'react';

const StudentForm = ({ onSubmit, initial }) => {
    const [form, setForm] = useState(initial);

    useEffect(() => {
        setForm(initial);
    }, [initial]);

    const handleSubmit = (e) => {
        e.preventDefault();
        
        const dateRegex = /^(?:(?:19|20)\d\d)-(?:0[1-9]|1[0-2])-(?:0[1-9]|1\d|2\d|3[01])$/;

        if (!dateRegex.test(form.dateOfBirth)) {
            alert("Invalid format. Please enter date as YYYY-MM-DD.");
            return;
        }

        onSubmit(form);
        setForm({ name: '', classAndSection: '', dateOfBirth: '' });
    };


    return (
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Student name"
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
                                placeholder="Class And Section"
                                value={form.classAndSection || ''}
                                onChange={(e) => setForm({ ...form, classAndSection: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Date of Birth (YYYY-MM-DD)"
                                value={form.dateOfBirth || ''}
                                onChange={(e) => setForm({ ...form, dateOfBirth: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit">{initial.id ? 'Update' : 'Add'} Student</button>
                        </td>
                </tr>
                 </tbody>
            </table>
        </form>
    );
};

export default StudentForm;