import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider } from './context/AuthContext';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import TokenRequestPage from './pages/TokenRequestPage';
import AdminDashboard from './pages/AdminDashboard';
import UserHistoryPage from './pages/UserHistoryPage';
import AdminUsersPage from './pages/AdminUsersPage'; // ✅ Import the new page
import ProtectedRoute from './components/ProtectedRoute';
import AdminDailyReportPage from './pages/AdminDailyReportPage';
const App = () => (
  <AuthProvider>
    <Router>
      <Routes>
        <Route path="/" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />

        <Route
          path="/request"
          element={
            <ProtectedRoute allowedRoles={['User']}>
              <TokenRequestPage />
            </ProtectedRoute>
          }
        />

        <Route
          path="/user-history"
          element={
            <ProtectedRoute allowedRoles={['User']}>
              <UserHistoryPage />
            </ProtectedRoute>
          }
        />

        <Route
          path="/admin"
          element={
            <ProtectedRoute allowedRoles={['admin']}>
              <AdminDashboard />
            </ProtectedRoute>
          }
        />
        <Route
  path="/admin/report"
  element={
    <ProtectedRoute allowedRoles={['admin']}>
      <AdminDailyReportPage />
    </ProtectedRoute>
  }
/>


        <Route
          path="/admin/users"
          element={
            <ProtectedRoute allowedRoles={['admin']}>
              <AdminUsersPage />
            </ProtectedRoute>
          }
        />
      </Routes>
    </Router>
  </AuthProvider>
);

export default App;
