import { useContext, useEffect, useState } from 'react';
import { AuthContext } from '../context/AuthContext';
import {
  Container,
  Typography,
  Paper,
  CircularProgress,
  AppBar,
  Toolbar,
  Button,
  Box,
  List,
  ListItem,
  ListItemText
} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const AdminUsersPage = () => {
  const { token, setToken, setRole } = useContext(AuthContext);
  const navigate = useNavigate();
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!token) {
      navigate('/');
      return;
    }

    const fetchUsers = async () => {
      try {
        const response = await axios.get('http://localhost:5044/api/admin/users', {
          headers: {
            Authorization: `Bearer ${token}`,
            'Content-Type': 'application/json'
          }
        });
        setUsers(response.data || []);
      } catch (error) {
        console.error('Error fetching users:', error);
        alert('Failed to load users.');
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, [token, navigate]);

  const handleLogout = () => {
    setToken(null);
    setRole(null);
    localStorage.clear();
    navigate('/');
  };

  // Helper to extract and format name
  const getNameFromEmail = (email) => {
    const rawName = email.split('@')[0];
    return rawName.charAt(0).toUpperCase() + rawName.slice(1).toLowerCase();
  };

  return (
    <>
      {/* Admin Navbar */}
      <AppBar position="static" color="primary">
        <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
          <Typography variant="h6">TokenZ Admin</Typography>
          <Box sx={{ display: 'flex', gap: 2 }}>
            <Button color="inherit" onClick={() => navigate('/admin')}>
              Dashboard
            </Button>
            <Button color="inherit" onClick={handleLogout}>
              Logout
            </Button>
          </Box>
        </Toolbar>
      </AppBar>

      <Container maxWidth="sm" sx={{ mt: 5 }}>
        <Typography variant="h5" align="center" gutterBottom>
          Registered Users
        </Typography>

        <Paper sx={{ p: 2 }}>
          {loading ? (
            <CircularProgress sx={{ display: 'block', margin: '20px auto' }} />
          ) : users.length === 0 ? (
            <Typography align="center" color="text.secondary">
              No users found.
            </Typography>
          ) : (
            <List>
              {users.map((user, index) => (
                <ListItem key={index}>
                  <ListItemText
                    primary={`Name: ${getNameFromEmail(user.email)}`}
                    secondary={`Email: ${user.email} | Role: ${user.role || 'User'}`}
                  />
                </ListItem>
              ))}
            </List>
          )}
        </Paper>
      </Container>
    </>
  );
};

export default AdminUsersPage;
