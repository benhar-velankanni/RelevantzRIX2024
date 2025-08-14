import { useContext, useEffect } from 'react';
import { requestToken } from '../api/beverageApi';
import { AuthContext } from '../context/AuthContext';
import {
  AppBar,
  Toolbar,
  Typography,
  Container,
  Button,
  Box,
  Grid,
  Card,
  CardActionArea,
  CardMedia,
  CardContent
} from '@mui/material';
import { useNavigate } from 'react-router-dom';

const TokenRequestPage = () => {
  const { token, setToken, setRole } = useContext(AuthContext);
  const navigate = useNavigate();

  useEffect(() => {
    document.title = 'TokenZ User Page';
  }, []);

  const handleRequest = async (beverage) => {
    const confirmed = window.confirm(`Are you sure you want to order ${beverage}?`);
    if (!confirmed) return;

    try {
      const res = await requestToken(beverage, token);
      alert(res.data);
    } catch (error) {
      console.error('Token request error:', error);
      alert('Request failed. Make sure the day is valid.');
    }
  };

  const handleLogout = () => {
    setToken(null);
    setRole(null);
    localStorage.removeItem('token');
    localStorage.removeItem('userRole');
    localStorage.removeItem('email');
    navigate('/');
  };

  // Greeting logic
  const userEmail = localStorage.getItem('email') || 'user@example.com';
  const rawName = userEmail.split('@')[0];
  const userName =
    rawName.charAt(0).toUpperCase() + rawName.slice(1).toLowerCase();

  const hours = new Date().getHours();
  let greeting = 'hello';
  if (hours >= 5 && hours < 12) greeting = 'good morning';
  else if (hours >= 12 && hours < 17) greeting = 'good afternoon';
  else if (hours >= 17 && hours < 21) greeting = 'good evening';
  else greeting = 'welcome';
  greeting = greeting.charAt(0).toUpperCase() + greeting.slice(1);

  return (
    <>
      {/* Navbar */}
      <AppBar position="static" color="primary">
        <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
          <Typography variant="h6">TokenZ</Typography>
          <Box sx={{ display: 'flex', gap: 2 }}>
            <Button color="inherit" onClick={() => navigate('/user-history')}>
              History
            </Button>
            <Button color="inherit" onClick={handleLogout}>
              Logout
            </Button>
          </Box>
        </Toolbar>
      </AppBar>

      {/* Main Content */}
      <Container maxWidth="sm" sx={{ mt: 4 }}>
        <Typography variant="h6" align="center" gutterBottom>
          {greeting}, <strong>{userName}</strong> 👋
        </Typography>

        <Typography variant="h5" textAlign="center" sx={{ mt: 4 }}>
          Choose Your Beverage
        </Typography>

        <Grid container spacing={3} justifyContent="center" sx={{ mt: 2 }}>
          {/* Tea Card */}
          <Grid item>
            <Card sx={{ width: 200, height: 240 }}>
              <CardActionArea onClick={() => handleRequest('tea')}>
                <CardMedia
                  component="img"
                  height="140"
                  image="/images/tea.png"
                  alt="Tea"
                />
                <CardContent>
                  <Typography variant="h6" align="center">Tea</Typography>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>

          {/* Coffee Card */}
          <Grid item>
            <Card sx={{ width: 200, height: 240 }}>
              <CardActionArea onClick={() => handleRequest('coffee')}>
                <CardMedia
                  component="img"
                  height="140"
                  image="/images/coffee.png"
                  alt="Coffee"
                />
                <CardContent>
                  <Typography variant="h6" align="center">Coffee</Typography>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>

          {/* Milk Card */}
          <Grid item>
            <Card sx={{ width: 200, height: 240 }}>
              <CardActionArea onClick={() => handleRequest('milk')}>
                <CardMedia
                  component="img"
                  height="140"
                  image="/images/milk.png"
                  alt="Milk"
                />
                <CardContent>
                  <Typography variant="h6" align="center">Milk</Typography>
                </CardContent>
              </CardActionArea>
            </Card>
          </Grid>
        </Grid>
      </Container>
    </>
  );
};

export default TokenRequestPage;
