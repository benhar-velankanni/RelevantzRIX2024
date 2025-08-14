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

        if (form.name == '' || form.type == '' || form.address == '') {
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
        <div class="container">
            <h2>Admin Dashboard</h2>
            <br></br>
            <button onClick={logout} style={{ marginBottom: '1rem' }}>
                Logout
            </button>
            <br></br>
            <br></br>
            <table>
                <tr>
                    <td>
                        <div class="input-group input-group-lg mb-3">
                            <input class="form-control" placeholder="Name" value={form.name} onChange={e => setForm({ ...form, name: e.target.value })} />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="input-group input-group-lg mb-3">
                            <input class="form-control" placeholder="Type" value={form.type} onChange={e => setForm({ ...form, type: e.target.value })} />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="input-group input-group-lg mb-3">
                            <input class="form-control" placeholder="Address" value={form.address} onChange={e => setForm({ ...form, address: e.target.value })} />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button onClick={createOrUpdateShipment}>
                            {editingId ? 'Update Shipment' : 'Add Shipment'}
                        </button>
                    </td>
                </tr>
                <br></br>
                <br></br>
                <br></br>
                <tr>
                    <td>
                        <input
                            class="form-control"
                            placeholder="Search by name, type, or address"
                            value={searchTerm}
                            onChange={e => setSearchTerm(e.target.value)}
                        />
                    </td>
                </tr>
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
