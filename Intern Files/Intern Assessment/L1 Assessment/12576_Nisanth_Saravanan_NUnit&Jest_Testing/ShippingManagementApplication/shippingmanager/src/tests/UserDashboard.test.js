//User test
import React from 'react';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import { AuthContext } from '../context/AuthContext';
import { MemoryRouter } from 'react-router-dom';
import UserDashboard from '../components/UserDashboard';
import API from '../services/api';

jest.mock('../services/api');

const mockUser = { role: 'user' };
const mockSetUser = jest.fn();

const mockShipments = [
  { id: 1, name: 'Box A', type: 'Electronics', address: '123 Street' },
  { id: 2, name: 'Box B', type: 'Clothing', address: '456 Avenue' },
];

describe('UserDashboard', () => {
  beforeEach(() => {
    API.get.mockResolvedValue({ data: mockShipments });
  });

  it('renders dashboard and fetches shipments', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <UserDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    expect(screen.getByText(/User Dashboard/i)).toBeInTheDocument();

    await waitFor(() => {
      expect(screen.getByText(/Box A/i)).toBeInTheDocument();
      expect(screen.getByText(/Box B/i)).toBeInTheDocument();
    });
  });

  it('filters shipments based on name', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <UserDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    await waitFor(() => screen.getByText(/Box A/i));

    act(() => {
      fireEvent.change(screen.getByPlaceholderText(/Search by name/i), {
        target: { value: 'Box A' },
      });
    });

    expect(screen.queryByText(/Box B/i)).not.toBeInTheDocument();
    expect(screen.getByText(/Box A/i)).toBeInTheDocument();
  });

  it('filters shipments based on type', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <UserDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    await waitFor(() => screen.getByText(/Box A/i));

    act(() => {
      fireEvent.change(screen.getByPlaceholderText(/Search by name/i), {
        target: { value: 'Electronics' },
      });
    });

    expect(screen.queryByText(/Box B/i)).not.toBeInTheDocument();
    expect(screen.getByText(/Box A/i)).toBeInTheDocument();
  });

  it('filters shipments based on address', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <UserDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    await waitFor(() => screen.getByText(/Box A/i));

    act(() => {
      fireEvent.change(screen.getByPlaceholderText(/Search by name/i), {
        target: { value: '123 Street' },
      });
    });

    expect(screen.queryByText(/Box B/i)).not.toBeInTheDocument();
    expect(screen.getByText(/Box A/i)).toBeInTheDocument();
  });

  it('calls logout and clears user', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <UserDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    act(() => {
      fireEvent.click(screen.getByText(/Logout/i));
    });

    expect(mockSetUser).toHaveBeenCalledWith(null);
  });
});