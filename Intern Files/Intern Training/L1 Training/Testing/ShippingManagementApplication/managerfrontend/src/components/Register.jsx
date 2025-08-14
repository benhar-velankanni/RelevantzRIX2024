import React, { useState, useEffect, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import API from '../services/api';
import { AuthContext } from '../context/AuthContext';

function Register() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const { user } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleRegister = async () => {

        if (username == '' || password == '') {
            alert("All credentials are mandatory.");
            return;
        }

        try {
            await API.post('/auth/register', { username, password });
            alert('Registration successful');
            navigate("/");
        } catch {
            alert('Registration failed');
        }
    };

    const handleLogin= () => {
        navigate('/');
    }

    useEffect(() => {
        document.title = "Register";

        if (user?.role == "Admin") {
            navigate("/admin");
        }
        else if (user?.role == "User") {
            navigate("/user")
        }
    });

    return (
        <>
            <div class="container">
                <h2>Register</h2>
                <table>
                    <tr>
                        <td>
                            <div class="input-group input-group-lg mb-3">
                                <input class="form-control" placeholder="Username" onChange={e => setUsername(e.target.value)} />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="input-group input-group-lg mb-3">
                                <input class="form-control" placeholder="Password" type="password" onChange={e => setPassword(e.target.value)} />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button onClick={handleRegister}>Register</button>
                        </td>
                    </tr>
                    <br></br>
                    <tr>
                        <td>
                            <button onClick={handleLogin}>Old User? Login.</button>
                        </td>
                    </tr>
                </table>              
            </div>
        </>
    );
}

export default Register;
