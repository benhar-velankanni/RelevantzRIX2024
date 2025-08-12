import React from 'react';
import CustomerManager from './CustomerManager';

function App() {
  return (
    <div style={{ padding: '20px' }}>
      <h1>Online Salon Booking</h1>
      <p>Welcome to your salon! Book appointments, view services, and manage your schedule.</p>
      <hr />
      <CustomerManager />
      <hr />
    </div>
  );
}

export default App;
