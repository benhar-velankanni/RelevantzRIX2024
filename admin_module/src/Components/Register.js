import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import '../App.css';

function Register() {
  const [role, setRole] = useState('user');
  const [userData, setUserData] = useState({ name: '', email: '', password: '', aadhar: '' });
  const [adminData, setAdminData] = useState({ name: '', email: '', password: '' });
  const [message, setMessage] = useState('');

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      if (role === 'user') {
        if (userData.password.length < 6) {
          setMessage('Password must be at least 6 characters long.');
          return;
        }
        if (!/^\d{12}$/.test(userData.aadhar)) {
          setMessage('Aadhaar number must be exactly 12 digits.');
          return;
        }
        const { data: users } = await axios.get('http://localhost:8000/users');
        const nameExists = users.some((u) => u.name === userData.name);
        const emailExists = users.some((u) => u.email === userData.email);
        const aadharExists = users.some((u) => u.aadhar === userData.aadhar);
        if (nameExists || emailExists || aadharExists) {
          setMessage('Name, email or Aadhaar already exists.');
          return;
        }
        await axios.post('http://localhost:8000/pendingUsers', { ...userData, approved: false });
        setMessage('User registration request sent for approval.');
        setUserData({ name: '', email: '', password: '', aadhar: '' });
      } else if (role === 'admin') {
        if (adminData.password.length < 6) {
          setMessage('Password must be at least 6 characters long.');
          return;
        }
        const { data: admins } = await axios.get('http://localhost:8000/admins');
        const nameExists = admins.some((a) => a.name === adminData.name);
        const emailExists = admins.some((a) => a.email === adminData.email);
        if (nameExists || emailExists) {
          setMessage('Admin name or email already exists.');
          return;
        }
        await axios.post('http://localhost:8000/admins', adminData);
        setMessage('Admin registered successfully.');
        setAdminData({ name: '', email: '', password: '' });
      }
    } catch (error) {
      setMessage('Registration failed. Try again.');
    }
  };

  return (
    <div className="container">
      <h2>User Registration</h2>
      <select value={role} onChange={(e) => setRole(e.target.value)}>
        <option value="user">User</option>
        <option value="admin">Admin</option>
      </select>
      <form onSubmit={handleRegister}>
        {role === 'user' && (
          <>
            <input
              type="text"
              placeholder="Name"
              value={userData.name}
              onChange={(e) => setUserData({ ...userData, name: e.target.value })}
              required
            />
            <input
              type="email"
              placeholder="Email"
              value={userData.email}
              onChange={(e) => setUserData({ ...userData, email: e.target.value })}
              required
            />
            <input
              type="password"
              placeholder="Password (min 6 chars)"
              value={userData.password}
              onChange={(e) => setUserData({ ...userData, password: e.target.value })}
              required
            />
            <input
              type="text"
              placeholder="Aadhaar Number"
              value={userData.aadhar}
              onChange={(e) => setUserData({ ...userData, aadhar: e.target.value })}
              required
            />
          </>
        )}
        {role === 'admin' && (
          <>
            <input
              type="text"
              placeholder="Admin Name"
              value={adminData.name}
              onChange={(e) => setAdminData({ ...adminData, name: e.target.value })}
              required
            />
            <input
              type="email"
              placeholder="Admin Email"
              value={adminData.email}
              onChange={(e) => setAdminData({ ...adminData, email: e.target.value })}
              required
            />
            <input
              type="password"
              placeholder="Password (min 6 chars)"
              value={adminData.password}
              onChange={(e) => setAdminData({ ...adminData, password: e.target.value })}
              required
            />
          </>
        )}
        <button type="submit">Register</button>
        <p style={{ marginTop: '1rem' }}>
          Already have an account? <Link to="/">Login here</Link>
        </p>
      </form>
      {message && <p style={{ color: 'green', marginTop: '1rem' }}>{message}</p>}
    </div>
  );
}

export default Register;
