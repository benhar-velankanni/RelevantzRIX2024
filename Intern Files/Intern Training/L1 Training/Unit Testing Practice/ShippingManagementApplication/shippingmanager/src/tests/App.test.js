//App.test.js
import React from 'react';
import { render, screen } from '@testing-library/react';
import App from '../App';
import { AuthContext } from '../context/AuthContext';

// Mock components
jest.mock('./components/Login', () => () => <div>Login</div>);
jest.mock('./components/Register', () => () => <div>Register</div>);
jest.mock('./components/AdminDashboard', () => () => <div>Admin Dashboard</div>);
jest.mock('./components/UserDashboard', () => () => <div>User Dashboard</div>);

describe('App Routing', () => {
  const renderWithRouter = (initialRoute, user) => {
    window.history.pushState({}, 'Test page', initialRoute);
  
    return render(
      <AuthContext.Provider value={{ user }}>
        <App />
      </AuthContext.Provider>
    );
  };
  
  it('renders Login page at root route', () => {
    renderWithRouter('/', null);
    expect(screen.getByText(/Login/i)).toBeInTheDocument();
  });

  it('renders Register page at /register', () => {
    renderWithRouter('/register', null);
    expect(screen.getByText(/Register/i)).toBeInTheDocument();
  });

  it('renders AdminDashboard for admin user', () => {
    renderWithRouter('/admin', { role: 'Admin' });
    expect(screen.getByText(/Admin Dashboard/i)).toBeInTheDocument();
  });

  it('redirects to Login if non-admin user accesses /admin', () => {
    renderWithRouter('/admin', { role: 'User' });
    expect(screen.getByText(/Login/i)).toBeInTheDocument();
  });

  it('renders UserDashboard for user role', () => {
    renderWithRouter('/user', { role: 'User' });
    expect(screen.getByText(/User Dashboard/i)).toBeInTheDocument();
  });

  it('redirects to Login if non-user accesses /user', () => {
    renderWithRouter('/user', { role: 'Admin' });
    expect(screen.getByText(/Login/i)).toBeInTheDocument();
  });
    
  it('matches snapshot for Login page', () => {
    const { asFragment } = renderWithRouter('/', null);
    expect(asFragment()).toMatchSnapshot();
  });

  it('matches snapshot for Register page', () => {
    const { asFragment } = renderWithRouter('/register', null);
    expect(asFragment()).toMatchSnapshot();
  });

  it('matches snapshot for AdminDashboard', () => {
    const { asFragment } = renderWithRouter('/admin', { role: 'Admin' });
    expect(asFragment()).toMatchSnapshot();
  });

  it('matches snapshot for UserDashboard', () => {
    const { asFragment } = renderWithRouter('/user', { role: 'User' });
    expect(asFragment()).toMatchSnapshot();
  });
});
