import React, { useState, useEffect } from 'react';

const TeacherForm = ({ onSubmit, initial }) => {
    const [form, setForm] = useState(initial);

    useEffect(() => {
        setForm(initial);
    }, [initial]);

    const handleSubmit = (e) => {
        e.preventDefault();

        const dateRegex = /^(?:(?:19|20)\d\d)-(?:0[1-9]|1[0-2])-(?:0[1-9]|1\d|2\d|3[01])$/;

        if (!dateRegex.test(form.dateOfJoining)) {
            alert("Invalid format. Please enter date as YYYY-MM-DD.");
            return;
        }

        onSubmit(form);
        setForm({ name: '', subject: '', dateOfJoining: '' });
    };

    return (
        <form onSubmit={handleSubmit}>
            <table>
                <tbody>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Teacher name"
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
                                placeholder="Subject"
                                value={form.subject || ''}
                                onChange={(e) => setForm({ ...form, subject: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input
                                type="text"
                                placeholder="Date of Joining (YYYY-MM-DD)"
                                value={form.dateOfJoining || ''}
                                onChange={(e) => setForm({ ...form, dateOfJoining: e.target.value })}
                                required
                            />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button type="submit">{initial.id ? 'Update' : 'Add'} Teacher</button>
                        </td>
                     </tr>
                 </tbody>
            </table>
        </form>
    );
};

export default TeacherForm;