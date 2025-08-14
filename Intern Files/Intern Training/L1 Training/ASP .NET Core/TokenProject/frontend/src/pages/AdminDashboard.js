import {
    AppBar,
    Toolbar,
    Typography,
    Button,
    Container,
    TextField,
    Paper,
    List,
    ListItem,
    ListItemText,
    IconButton,
    Divider,
    Grid,
    Box
  } from '@mui/material';
  import DeleteIcon from '@mui/icons-material/Delete';
  import { useNavigate } from 'react-router-dom';
  import { useEffect, useState, useContext } from 'react';
  import {
    addWorkingDays,
    getWorkingDays,
    deleteWorkingDay,
    getReport,
    getTokens
  } from '../api/beverageApi';
  import { AuthContext } from '../context/AuthContext';
  
  const AdminDashboard = () => {
    const { token, setToken, setRole } = useContext(AuthContext);
    const navigate = useNavigate();
    const [newDays, setNewDays] = useState('');
    const [workingDays, setWorkingDays] = useState([]);
    const [reportRange, setReportRange] = useState({ start: '', end: '' });
    const [report, setReport] = useState([]);
    const [tokenDate, setTokenDate] = useState('');
    const [tokens, setTokens] = useState([]);
  
    useEffect(() => {
      if (token) {
        getWorkingDays(token).then(res => setWorkingDays(res.data));
      }
    }, [token]);
  
    const handleAddDays = async () => {
      const daysArray = newDays.split(',').map(d => d.trim());
      await addWorkingDays(daysArray, token);
      setNewDays('');
      const res = await getWorkingDays(token);
      setWorkingDays(res.data);
    };
  
    const handleDeleteDay = async (date) => {
      await deleteWorkingDay(date, token);
      const res = await getWorkingDays(token);
      setWorkingDays(res.data);
    };
  
    const handleGetReport = async () => {
      const res = await getReport(reportRange.start, reportRange.end, token);
      setReport(res.data);
    };
  
    const handleGetTokens = async () => {
      const res = await getTokens(tokenDate, token);
      setTokens(res.data);
    };
  
    const handleLogout = () => {
      setToken(null);
      setRole(null);
      localStorage.removeItem('token');
      localStorage.removeItem('userRole');
      navigate('/');
    };
  
    return (
      <>
        {/* Top Navigation Bar */}
        <AppBar position="static">
  <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
    <Typography variant="h6">TokenZ</Typography>
    <Box sx={{ display: 'flex', gap: 2 }}>
      <Button color="inherit" onClick={() => navigate('/admin/users')}>
        View Users
      </Button>
      <Button color="inherit" onClick={() => navigate('/admin/report')}>
        Daily Report
      </Button>
      <Button color="inherit" onClick={handleLogout}>
        Logout
      </Button>
    </Box>
  </Toolbar>
</AppBar>

  
        {/* Main Dashboard Container */}
        <Container maxWidth="md" sx={{ mt: 4 }}>
        <title>TokenZ Admin Panel</title>
          <Typography variant="h4" gutterBottom align="center">
            Admin Dashboard
          </Typography>
  
          {/* Working Days Section */}
          <Paper sx={{ p: 3, mb: 4 }}>
            <Typography variant="h6" gutterBottom>Manage Working Days</Typography>
            <Box display="flex" gap={2} alignItems="center" mb={2}>
              <TextField
                fullWidth
                label="Enter dates (YYYY-MM-DD), comma separated"
                value={newDays}
                onChange={(e) => setNewDays(e.target.value)}
              />
              <Button variant="contained" onClick={handleAddDays}>Add Days</Button>
            </Box>
            <List>
              {workingDays.map((day, i) => (
                <ListItem
                  key={i}
                  secondaryAction={
                    <IconButton edge="end" onClick={() => handleDeleteDay(day)}>
                      <DeleteIcon />
                    </IconButton>
                  }
                >
                  <ListItemText primary={day} />
                </ListItem>
              ))}
            </List>
          </Paper>
  
          {/* Report Section */}
          <Paper sx={{ p: 3, mb: 4 }}>
            <Typography variant="h6" gutterBottom>Generate Beverage Report</Typography>
            <Grid container spacing={2} alignItems="center">
              <Grid item xs={5}>
                <TextField
                  fullWidth
                  type="date"
                  label="Start Date"
                  InputLabelProps={{ shrink: true }}
                  value={reportRange.start}
                  onChange={(e) => setReportRange({ ...reportRange, start: e.target.value })}
                />
              </Grid>
              <Grid item xs={5}>
                <TextField
                  fullWidth
                  type="date"
                  label="End Date"
                  InputLabelProps={{ shrink: true }}
                  value={reportRange.end}
                  onChange={(e) => setReportRange({ ...reportRange, end: e.target.value })}
                />
              </Grid>
              <Grid item xs={2}>
                <Button variant="contained" onClick={handleGetReport} fullWidth>
                  Get Report
                </Button>
              </Grid>
            </Grid>
            <List sx={{ mt: 2 }}>
              {report.map((r, i) => (
                <ListItem key={i}>
                  <ListItemText primary={`${r.beverage}: ${r.count}`} />
                </ListItem>
              ))}
            </List>
          </Paper>
  
          {/* Token Requests Section */}
          <Paper sx={{ p: 3, mb: 4 }}>
            <Typography variant="h6" gutterBottom>View Token Requests</Typography>
            <Box display="flex" gap={2} alignItems="center" mb={2}>
              <TextField
                type="date"
                label="Filter by Date"
                InputLabelProps={{ shrink: true }}
                value={tokenDate}
                onChange={(e) => setTokenDate(e.target.value)}
              />
              <Button variant="contained" onClick={handleGetTokens}>Get Tokens</Button>
            </Box>
            <Divider />
            <List>
              {tokens.map((token) => (
                <ListItem key={token.id}>
                  <ListItemText
                    primary={`${token.userEmail} requested ${token.beverageType}`}
                    secondary={`${token.requestTime} - ${token.isClaimed ? 'Claimed' : 'Not Claimed'}`}
                  />
                </ListItem>
              ))}
            </List>
          </Paper>
        </Container>
      </>
    );
  };
  
  export default AdminDashboard;
  