import React, { useContext, useEffect, useState } from 'react';
import API from '../services/api';
import { AuthContext } from '../context/AuthContext';

function UserDashboard() {
    const [shipments, setShipment] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const { setUser } = useContext(AuthContext);

    useEffect(() => {
        document.title = "User Dash";

        API.get('/shipment').then(res => setShipment(res.data));
    }, []);

    const logout = () => {
        setUser(null);
    };

    const filteredShipments = shipments.filter(s =>
        s.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        s.type.toLowerCase().includes(searchTerm.toLowerCase()) ||
        s.address.toString().includes(searchTerm)
    );

    return (
        <div className="container">
            <h2 style={{ marginBottom: '3rem' }}>User Dashboard</h2>
            <button onClick={logout} style={{ marginBottom: '3rem' }}>
                Logout
            </button>
            <table style={{ marginBottom: '3rem' }}>
                <tbody>
                    <tr>
                        <td>
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
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default UserDashboard;
