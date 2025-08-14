// src/components/Logout.js
import { useContext, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';

const Logout = () => {
  const { setToken, setRole } = useContext(AuthContext);
  const navigate = useNavigate();

  useEffect(() => {
    // Clear context and localStorage
    setToken(null);
    setRole(null);
    localStorage.removeItem('token');
    localStorage.removeItem('userRole');
    navigate('/');
  }, [navigate, setToken, setRole]);

  return null; // No visual output
};

export default Logout;
