import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';
import '../App.css';
function Login() {
 const [role, setRole] = useState('user');
 const [email, setEmail] = useState('');
 const [password, setPassword] = useState('');
 const [message, setMessage] = useState('');
 const navigate = useNavigate();
 const handleLogin = async (e) => {
   e.preventDefault();
   try {
     if (role === 'user') {
       const userRes = await axios.get('http://localhost:8000/users');
       const userData = userRes.data;
       const userAccount = userData.find(
         (user) => user.email === email && user.password === password
       );
       if (userAccount) {
         if (userAccount.approved) {
           navigate('/user');
         } else {
           setMessage('Admin approval pending.');
         }
         return;
       }
       const pendingRes = await axios.get('http://localhost:8000/pendingUsers');
       const pendingData = pendingRes.data;
       const pendingAccount = pendingData.find(
         (user) => user.email === email && user.password === password
       );
       if (pendingAccount) {
         setMessage('Admin approval pending.');
       } else {
         setMessage('Invalid credentials.');
       }
     } else {
       const adminRes = await axios.get('http://localhost:8000/admins');
       const adminData = adminRes.data;
       const adminAccount = adminData.find(
         (admin) => admin.email === email && admin.password === password
       );
       if (adminAccount) {
         navigate('/admin');
       } else {
         setMessage('Invalid admin credentials.');
       }
     }
   } catch (error) {
     console.error(error);
     setMessage('Login failed. Please try again.');
   }
 };
 return (
<div className="container">
<h2>Login as</h2>
<select value={role} onChange={(e) => setRole(e.target.value)}>
<option value="user">User</option>
<option value="admin">Admin</option>
</select>
<form onSubmit={handleLogin}>
<input
         type="email"
         placeholder="Email"
         value={email}
         onChange={(e) => setEmail(e.target.value)}
         required
       />
<input
         type="password"
         placeholder="Password"
         value={password}
         onChange={(e) => setPassword(e.target.value)}
         required
       />
<button type="submit">Login</button>
<p style={{ marginTop: '1rem' }}>
         Don’t have an account? <Link to="/register">Register here</Link>
</p>
</form>
     {message && (
<p
         style={{
           color: message.includes('pending') ? 'orange' : 'red',
           marginTop: '1rem',
           fontWeight: 'bold',
           textAlign: 'center'
         }}
>
         {message}
</p>
     )}
</div>
 );
}
export default Login;