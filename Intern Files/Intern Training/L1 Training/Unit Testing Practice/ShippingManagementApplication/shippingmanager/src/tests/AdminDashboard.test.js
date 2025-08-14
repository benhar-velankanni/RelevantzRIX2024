//Admin Test
import React from 'react';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import { AuthContext } from '../context/AuthContext';
import { MemoryRouter } from 'react-router-dom';
import AdminDashboard from '../components/AdminDashboard';
import API from '../services/api';

jest.mock('../services/api');

const mockUser = { role: 'admin' };
const mockSetUser = jest.fn();

const mockShipments = [
  { id: 1, name: 'Box A', type: 'Electronics', address: '123 Street' },
  { id: 2, name: 'Box B', type: 'Clothing', address: '456 Avenue' },
];

describe('AdminDashboard', () => {
  beforeEach(() => {
    API.get.mockResolvedValue({ data: mockShipments });
  });

  it('renders dashboard and fetches shipments', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    expect(screen.getByText(/Admin Dashboard/i)).toBeInTheDocument();

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
            <AdminDashboard />
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
              <AdminDashboard />
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
            <AdminDashboard />
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
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    act(() => {
      fireEvent.click(screen.getByText(/Logout/i));
    });

    expect(mockSetUser).toHaveBeenCalledWith(null);
  });

  it('updates form fields correctly', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });
  
    fireEvent.change(screen.getByPlaceholderText('Name'), {
      target: { value: 'New Shipment' },
    });
    fireEvent.change(screen.getByPlaceholderText('Type'), {
      target: { value: 'Books' },
    });
    fireEvent.change(screen.getByPlaceholderText('Address'), {
      target: { value: '789 Boulevard' },
    });
  
    expect(screen.getByPlaceholderText('Name').value).toBe('New Shipment');
    expect(screen.getByPlaceholderText('Type').value).toBe('Books');
    expect(screen.getByPlaceholderText('Address').value).toBe('789 Boulevard');
  });

  it('adds a shipment when form is complete', async () => {
    const newShipment = { id: 3, name: 'Box C', type: 'Books', address: '789 Boulevard' };
  
    // Initial fetch: Box A and Box B
    API.get.mockResolvedValueOnce({ data: mockShipments });
  
    // Mock POST response
    API.post.mockResolvedValue({ data: newShipment });
  
    // After adding: Box A, Box B, and Box C
    API.get.mockResolvedValueOnce({ data: [...mockShipments, newShipment] });
  
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });
  
    // Fill form
    fireEvent.change(screen.getByPlaceholderText('Name'), {
      target: { value: 'Box C' },
    });
    fireEvent.change(screen.getByPlaceholderText('Type'), {
      target: { value: 'Books' },
    });
    fireEvent.change(screen.getByPlaceholderText('Address'), {
      target: { value: '789 Boulevard' },
    });
  
    // Submit form
    await act(async () => {
      fireEvent.click(screen.getByText(/Add Shipment/i));
    });
  
    // Wait for re-render with new shipment
    await waitFor(() => {
      expect(screen.getByText(/Box C/i)).toBeInTheDocument();
    });
  });

  it('populates form when editing a shipment', async () => {
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });
  
    await waitFor(() => screen.getByText(/Box A/i));
  
    fireEvent.click(screen.getAllByText(/Edit/i)[0]);
  
    expect(screen.getByPlaceholderText('Name').value).toBe('Box A');
    expect(screen.getByPlaceholderText('Type').value).toBe('Electronics');
    expect(screen.getByPlaceholderText('Address').value).toBe('123 Street');
  });

  it('deletes a shipment', async () => {
    // Initial mock: both shipments
    API.get.mockResolvedValueOnce({ data: mockShipments });
  
    // Mock delete response
    API.delete.mockResolvedValue({});
  
    // After deletion: only Box B remains
    API.get.mockResolvedValueOnce({ data: [mockShipments[1]] });
  
    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });
  
    // Wait for initial render
    await waitFor(() => {
      expect(screen.getByText(/Box A/i)).toBeInTheDocument();
    });
  
    // Trigger delete
    await act(async () => {
      fireEvent.click(screen.getAllByText(/Delete/i)[0]);
    });
  
    // Wait for re-render after deletion
    await waitFor(() => {
      expect(screen.queryByText(/Box A/i)).not.toBeInTheDocument();
      expect(screen.getByText(/Box B/i)).toBeInTheDocument();
    });
  });
  

  it('shows alert when form is incomplete', async () => {
    window.alert = jest.fn();

    await act(async () => {
      render(
        <MemoryRouter>
          <AuthContext.Provider value={{ user: mockUser, setUser: mockSetUser }}>
            <AdminDashboard />
          </AuthContext.Provider>
        </MemoryRouter>
      );
    });

    act(() => {
      fireEvent.click(screen.getByText(/Add Shipment/i));
    });

    expect(window.alert).toHaveBeenCalledWith('All fields Needed!');
  });
});