import axios from 'axios';

const API_URL = 'http://localhost:5044';

export const register = (data) => axios.post(`${API_URL}/api/auth/register`, data);
export const login = (data) => axios.post(`${API_URL}/api/auth/login`, data);
export const requestToken = (beverage, token) =>
  axios.post(`${API_URL}/api/token/request?beverage=${beverage}`, {}, {
    headers: { Authorization: `Bearer ${token}` }
  });

// Admin APIs
export const addWorkingDays = (days, token) =>
  axios.post(`${API_URL}/api/admin/workingdays`, days, {
    headers: { Authorization: `Bearer ${token}` }
  });

export const getWorkingDays = (token) =>
  axios.get(`${API_URL}/api/admin/workingdays`, {
    headers: { Authorization: `Bearer ${token}` }
  });

export const deleteWorkingDay = (date, token) =>
  axios.delete(`${API_URL}/api/admin/workingdays?date=${date}`, {
    headers: { Authorization: `Bearer ${token}` }
  });

export const getReport = (start, end, token) =>
  axios.get(`${API_URL}/api/admin/report?startDate=${start}&endDate=${end}`, {
    headers: { Authorization: `Bearer ${token}` }
  });

export const getTokens = (date, token) =>
  axios.get(`${API_URL}/api/admin/tokens?date=${date}`, {
    headers: { Authorization: `Bearer ${token}` }
  });
