import React, { useContext } from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import Login from './components/Login';
import Register from './components/Register';
import AdminDashboard from './components/AdminDashboard';
import UserDashboard from './components/UserDashboard';
import { AuthContext } from './context/AuthContext';
import "./App.css";

function App() {
    const { user } = useContext(AuthContext);

    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route path="/admin" element={user?.role === 'Admin' ? <AdminDashboard /> : <Navigate to="/" />} />
                <Route path="/user" element={user?.role === 'User' ? <UserDashboard /> : <Navigate to="/" />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
