import React, { useContext, useEffect, useState } from 'react';
import API from '../services/api';
import { AuthContext } from '../context/AuthContext';

function AdminDashboard() {
    const { user } = useContext(AuthContext);
    const [shipments, setShipment] = useState([]);
    const { setUser } = useContext(AuthContext);
    const [searchTerm, setSearchTerm] = useState('');
    const [form, setForm] = useState({ name: '', type: '', address: ''});
    const [editingId, setEditingId] = useState(null);

    const fetchShipments = async () => {
        const res = await API.get('/shipment');
        setShipment(res.data);
    };

    const createOrUpdateShipment = async () => {

        if (form.name == '' || form.type == '' || form.address == '' || form.name == null || form.type == null || form.address == null) {
            alert("All fields Needed!");
            return;
        }


        if (editingId) {
            await API.put(`/shipment/${editingId}?role=${user.role}`, form);
            setEditingId(null);
        } else {
            await API.post(`/shipment?role=${user.role}`, form);
        }
        setForm({ name: '', type: '', address: '' });
        fetchShipments();
    };

    const deleteShipment = async (id) => {
        await API.delete(`/shipment/${id}?role=${user.role}`);
        fetchShipments();
    };

    const startEdit = (shipment) => {
        setForm(shipment);
        setEditingId(shipment.id);
    };

    const filteredShipments = shipments.filter(s =>
        s.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        s.type.toLowerCase().includes(searchTerm.toLowerCase()) ||
        s.address.toString().includes(searchTerm)
    );

    const logout = () => {
        setUser(null);
    };

    useEffect(() => {
        document.title = "Admin Dash";

        fetchShipments();
    }, []);

    return (
        <div className="container">
            <h2 style={{ marginBottom: '3rem' }}>Admin Dashboard</h2>
            <button onClick={logout} style={{ marginBottom: '3rem' }}>
                Logout
            </button>
            <table style={{ marginBottom: '3rem' }}>
                <tbody>
                    <tr>
                        <td>
                            <div className="input-group input-group-lg mb-3">
                                <input id='name-input' className="form-control" placeholder="Name" value={form.name} onChange={e => setForm({ ...form, name: e.target.value })} />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div className="input-group input-group-lg mb-3">
                                <input id='type-input' className="form-control" placeholder="Type" value={form.type} onChange={e => setForm({ ...form, type: e.target.value })} />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style={{ marginBottom: '3rem' }}>
                            <div className="input-group input-group-lg mb-3">
                                <input id='address-input' className="form-control" placeholder="Address" value={form.address} onChange={e => setForm({ ...form, address: e.target.value })} />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style={{ marginBottom: '3rem' }}>
                            <button onClick={createOrUpdateShipment}>
                                {editingId ? 'Update Shipment' : 'Add Shipment'}
                            </button>
                        </td>
                    </tr>
                    <tr>
                        <td style={{ marginBottom: '3rem' }}>
                            <input
                                className="form-control"
                                placeholder="Search by name, type, or address"
                                value={searchTerm}
                                onChange={e => setSearchTerm(e.target.value)}
                            />
                        </td>
                    </tr>
                </tbody>
            </table>
            <ul>
                {filteredShipments.map(s => (
                    <li key={s.id}>
                        <strong>Name:</strong>  {s.name},&nbsp;&nbsp;&nbsp;&nbsp; <strong>Type:</strong>    {s.type},&nbsp;&nbsp;&nbsp;&nbsp; <strong>Addressed To:</strong> {s.address} &nbsp;&nbsp;&nbsp;&nbsp;
                        <button onClick={() => startEdit(s)}>Edit</button> &nbsp;&nbsp;&nbsp;&nbsp;
                        <button onClick={() => deleteShipment(s.id)}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default AdminDashboard;
