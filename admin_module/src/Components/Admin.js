import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './Admin.css';
import CropCards from './CropCards';
const Admin = () => {
 const [requests, setRequests] = useState([]);
 useEffect(() => {
   axios.get('http://localhost:8000/pendingUsers')
     .then(res => setRequests(res.data));
 }, []);
 const handleDecision = async (id, decision) => {
   const user = requests.find(u => u.id === id);
   if (decision === 'approve') {
     await axios.post('http://localhost:8000/users', {
       ...user,
       role: 'user',
       approved: true
     });
   }
   await axios.delete(`http://localhost:8000/pendingUsers/${id}`);
   setRequests(requests.filter(r => r.id !== id));
 };
 return (
<div className="admin-container">
<h2 className="admin-title">Pending User Requests</h2>
     {requests.length === 0 ? (
<p className="no-requests">No pending requests.</p>
     ) : (
<div className="cards-container">
         {requests.map(user => (
<div key={user.id} className="user-card">
<p><strong>Name:</strong> {user.name}</p>
<p><strong>Email:</strong> {user.email}</p>
<p><strong>Aadhaar:</strong> {user.aadhar}</p>
<div className="button-group">
<button className="approve-btn" onClick={() => handleDecision(user.id, 'approve')}>Approve</button>
<button className="reject-btn" onClick={() => handleDecision(user.id, 'reject')}>Reject</button>
</div>
</div>
         ))}
</div>
     )}
     <CropCards />
</div>
 );
};
export default Admin;

