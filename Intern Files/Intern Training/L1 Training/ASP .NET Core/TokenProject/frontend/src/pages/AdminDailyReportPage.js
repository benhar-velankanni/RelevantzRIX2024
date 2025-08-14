import {
    AppBar,
    Toolbar,
    Typography,
    Button,
    Container,
    TextField,
    Paper,
    Table,
    TableHead,
    TableRow,
    TableCell,
    TableBody,
    Box,
    CircularProgress
  } from '@mui/material';
  import { useContext, useEffect, useState } from 'react';
  import { AuthContext } from '../context/AuthContext';
  import { useNavigate } from 'react-router-dom';
  import axios from 'axios';
  
  const AdminDailyReportPage = () => {
    const { token, setToken, setRole } = useContext(AuthContext);
    const navigate = useNavigate();
  
    const [reportDate, setReportDate] = useState('');
    const [loading, setLoading] = useState(false);
    const [reportData, setReportData] = useState([]);
  
    const handleLogout = () => {
      setToken(null);
      setRole(null);
      localStorage.clear();
      navigate('/');
    };
  
    const fetchReport = async () => {
      setLoading(true);
      try {
        const query = reportDate ? `?date=${reportDate}` : '';
        const response = await axios.get(
          `http://localhost:5044/api/admin/daily-report${query}`,
          {
            headers: {
              Authorization: `Bearer ${token}`
            }
          }
        );
        setReportData(response.data || []);
      } catch (error) {
        console.error('Error fetching daily report:', error);
        alert(
          error.response?.data || 'Failed to fetch report. Please try again after 5:00 PM IST.'
        );
      } finally {
        setLoading(false);
      }
    };
  
    useEffect(() => {
      if (!token) navigate('/');
      else fetchReport();
    }, [token]);
  
    return (
      <>
        <AppBar position="static">
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
  
        <Container maxWidth="md" sx={{ mt: 4 }}>
          <Typography variant="h5" gutterBottom align="center">
            Daily Token Claim Report
          </Typography>
  
          <Paper sx={{ p: 3, mb: 3 }}>
            <Box display="flex" gap={2} alignItems="center">
              <TextField
                type="date"
                label="Select Date"
                InputLabelProps={{ shrink: true }}
                value={reportDate}
                onChange={(e) => setReportDate(e.target.value)}
              />
              <Button variant="contained" onClick={fetchReport}>
                Get Report
              </Button>
            </Box>
          </Paper>
  
          {loading ? (
            <CircularProgress sx={{ display: 'block', margin: '20px auto' }} />
          ) : reportData.length === 0 ? (
            <Typography align="center" color="text.secondary">
              No data available for this date.
            </Typography>
          ) : (
            <Paper sx={{ p: 2 }}>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell><strong>Email</strong></TableCell>
                    <TableCell align="center">Morning</TableCell>
                    <TableCell align="center">Evening</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {reportData.map((user, i) => (
                    <TableRow key={i}>
                      <TableCell>{user.email}</TableCell>
                      <TableCell align="center">
                        {user.sessions.find(s => s.session === 'Morning')?.claimed ? '✅' : '❌'}
                      </TableCell>
                      <TableCell align="center">
                        {user.sessions.find(s => s.session === 'Evening')?.claimed ? '✅' : '❌'}
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </Paper>
          )}
        </Container>
      </>
    );
  };
  
  export default AdminDailyReportPage;
  