import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { register } from '../api/beverageApi';
import {
  Container,
  TextField,
  Button,
  Typography,
  Box,
  Link
} from '@mui/material';

const RegisterPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleRegister = async () => {
    const trimmedEmail = email.trim().toLowerCase();

    if (!trimmedEmail.endsWith('@relevantz.com')) {
      alert("Please use a valid @relevantz.com email address.");
      return;
    }

    try {
      await register({ email: trimmedEmail, password });
      alert("Registered successfully! Redirecting to login...");
      setTimeout(() => {
        navigate('/');
      }, 500);
    } catch (error) {
      console.error('Registration error:', error);
      alert("Registration failed. Please try again.");
    }
  };

  return (
    
    <Container maxWidth="sm">
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
        <Typography variant="h4" textAlign="center" gutterBottom>
          Register
        </Typography>
        <TextField
          label="Email"
          fullWidth
          margin="normal"
          type="email"
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
          onClick={handleRegister}
        >
          Register
        </Button>
        <Box sx={{ mt: 2, textAlign: 'center' }}>
          <Link
            component="button"
            variant="body2"
            underline="hover"
            onClick={() => navigate('/')}
          >
            Already registered? Go to Login
          </Link>
        </Box>
      </Box>
      <title>TokenZ Register Page</title>
    </Container>
  );
};

export default RegisterPage;
