import React from 'react';
import { Link } from 'react-router-dom';
import UserCropView from './UserCropView';
import './User.css';

function User() {
  const getGreeting = () => {
    const currentHour = new Date().getHours();
    if (currentHour < 12) {
      return 'Good morning';
    } else if (currentHour < 18) {
      return 'Good afternoon';
    } else {
      return 'Good evening';
    }
  };

  return (
    <div>
      <nav className="user-nav">
        <ul className="user-nav-list">
          <li className="user-nav-item">
            <Link to="/insurance">Insurance</Link>
          </li>
          <li className="user-nav-item">
            <Link to="/Bid">Bidding</Link>
          </li>
          <li className="user-nav-item">
            <Link to="/UserForm">Add Crop</Link>
          </li>
        </ul>
      </nav>
      <h1>{getGreeting()}, User!</h1>
      <UserCropView />
    </div>
  );
}

export default User;

