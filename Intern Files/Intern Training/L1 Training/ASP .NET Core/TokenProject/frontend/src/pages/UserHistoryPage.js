import { useContext, useEffect, useState } from 'react';
import { AuthContext } from '../context/AuthContext';
import {
  Container,
  Typography,
  List,
  ListItem,
  ListItemText,
  Paper,
  CircularProgress,
  AppBar,
  Toolbar,
  Button,
  Box
} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const UserHistoryPage = () => {
  const { token, setToken, setRole } = useContext(AuthContext);
  const navigate = useNavigate();
  const [history, setHistory] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!token) {
      navigate('/');
      return;
    }

    const fetchHistory = async () => {
      try {
        const response = await axios.get('http://localhost:5044/api/token/history', {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setHistory(response.data || []);
      } catch (error) {
        console.error('Error fetching history:', error);
        alert('Failed to load token history.');
      } finally {
        setLoading(false);
      }
    };

    fetchHistory();
  }, [token, navigate]);

  const handleLogout = () => {
    setToken(null);
    setRole(null);
    localStorage.clear();
    navigate('/');
  };

  return (
    <>
      {/* Navbar */}
      <AppBar position="static" color="primary">
        <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
          <Typography variant="h6">TokenZ</Typography>
          <Box sx={{ display: 'flex', gap: 2 }}>
            <Button color="inherit" onClick={() => navigate('/request')}>
              Request Token
            </Button>
            <Button color="inherit" onClick={handleLogout}>
              Logout
            </Button>
          </Box>
        </Toolbar>
      </AppBar>

      <Container maxWidth="sm" sx={{ mt: 5 }}>
        <Typography variant="h5" align="center" gutterBottom>
          Your Beverage Claim History
        </Typography>

        <Paper sx={{ p: 2 }}>
          {loading ? (
            <CircularProgress sx={{ display: 'block', margin: '20px auto' }} />
          ) : history.length === 0 ? (
            <Typography align="center" color="text.secondary">
              No token claims found.
            </Typography>
          ) : (
            <List>
              {history.map((item, index) => (
                <ListItem key={index}>
                  <ListItemText
                    primary={`Beverage: ${item.beverageType}`}
                    secondary={
                      <>
                        <div>Requested At: {new Date(item.requestTime).toLocaleString()}</div>
                        <div>Claim: {item.isClaimed ? 'True' : 'False'}</div>
                      </>
                    }
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

export default UserHistoryPage;
