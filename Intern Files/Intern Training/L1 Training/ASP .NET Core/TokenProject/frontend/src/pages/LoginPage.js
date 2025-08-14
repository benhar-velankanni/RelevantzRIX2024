import { useState, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { Container, TextField, Button, Typography, Box,Link } from '@mui/material';
import { login } from '../api/beverageApi';
import { AuthContext } from '../context/AuthContext';

const LoginPage = () => {
  const { setToken, setRole } = useContext(AuthContext);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await login({ email, password });
      const { token, role } = response.data;

      if (!token || !role) {
        alert('Login failed: Missing token or role in response.');
        return;
      }

      // Persist in localStorage
      localStorage.setItem('token', token);
      localStorage.setItem('userRole', role);
      localStorage.setItem('email', email);

      // Update context
      setToken(token);
      setRole(role);

      // Navigate to correct page
      if (role === 'admin') {
        navigate('/admin');
      } else if (role === 'User') {
        navigate('/request');
      } else {
        alert('Unknown role: ' + role);
      }
    } catch (error) {
      console.error('Login error:', error);
      alert('Login failed: Invalid credentials or server error.');
    }
  };

  return (
    
    <Container maxWidth="sm">
        <title>TokenZ Login Page</title>
        <Box sx={{ mt: 8, mb: 4, textAlign: 'center' }}>
  <Typography
    variant="h3"
    sx={{
      display: 'inline',
      fontWeight: 'bold',
      fontFamily: `'Segoe UI', 'Helvetica Neue', 'Arial', sans-serif`,
      color: '#251f5a'
    }}
  >
    Token
  </Typography>
  <Typography
    variant="h3"
    sx={{
      display: 'inline',
      fontFamily: `'Playfair Display', 'Georgia', serif`,
      fontStyle: 'italic',
      fontWeight: 600,
      color: '#bf305f',
      ml: 1
    }}
  >
    Z
  </Typography>
</Box>

      <Box sx={{ mt: 8 }}>
        <Typography variant="h4" textAlign={'center'} gutterBottom>Login</Typography>
        <TextField
          label="Email"
          fullWidth
          margin="normal"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <TextField
          label="Password"
          type="password"
          fullWidth
          margin="normal"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <Button
          variant="contained"
          fullWidth
          sx={{ mt: 2 }}
          onClick={handleLogin}
        >
          Login
        </Button>
        <Box sx={{ mt: 2, textAlign: 'center' }}>
          <Link
            component="button"
            variant="body2"
            underline="hover"
            onClick={() => navigate('/register')}
          >
           New User? Register Here.
          </Link>
        </Box>
      </Box>
      
    </Container>
  );
};

export default LoginPage;
