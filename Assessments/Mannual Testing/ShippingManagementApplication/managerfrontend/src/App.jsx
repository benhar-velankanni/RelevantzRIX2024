import React, { useContext } from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/Login';
import Register from './components/Register';
import AdminDashboard from './components/AdminDashboard';
import UserDashboard from './components/UserDashboard';
import { AuthContext } from './context/AuthContext';
import "./App.css";

function App() {
    const { user } = useContext(AuthContext);

    return (
        <Router>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route path="/admin" element={user?.role === 'Admin' ? <AdminDashboard /> : <Navigate to="/" />} />
                <Route path="/user" element={user?.role === 'User' ? <UserDashboard /> : <Navigate to="/" />} />
            </Routes>
        </Router>
    );
}

export default App;
