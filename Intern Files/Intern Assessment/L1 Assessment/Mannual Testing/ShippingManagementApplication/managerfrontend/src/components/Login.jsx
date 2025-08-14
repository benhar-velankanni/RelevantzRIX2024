import React, { useState, useContext, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import API from '../services/api';
import { AuthContext } from '../context/AuthContext';

function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const { setUser } = useContext(AuthContext);
    const { user } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogin = async () => {

        if (username == '' || password == '') {
            alert("All credentials are mandatory.");
            return;
        }

        try {
            const res = await API.post('/auth/login', { username, password });
            setUser(res.data);
            res.data.role === 'Admin' ? navigate('/admin') : navigate('/user');
        } catch {
            alert('Invalid credentials');
        }
    };

    const handleRegister = () => {
        navigate('/register');
    }

    useEffect(() => {
        document.title = "Login";

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
                <h2>Login</h2>
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
                            <button onClick={handleLogin}>Login</button>
                        </td>
                    </tr>
                    <br></br>
                    <tr>
                        <td>
                            <button onClick={handleRegister}>New User? Register.</button>
                        </td>
                    </tr>
                </table>              
            </div>
        </>
    );
}

export default Login;
