import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import Home from '../Home';
import ApplyInsurance from './components/ApplyInsurance';
import CalculateInsurance from './components/CalculateInsurance';
import ClaimInsurance from './components/ClaimInsurance';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/apply" element={<ApplyInsurance />} />
        <Route path="/calculate" element={<CalculateInsurance />} />
        <Route path="/claim" element={<ClaimInsurance />} />
      </Routes>
    </Router>
  );
}

export default App;

