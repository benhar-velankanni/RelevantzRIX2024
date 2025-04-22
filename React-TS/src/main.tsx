import React from 'react';
import ReactDom from 'react-dom/client';
import App1 from './App';
import Trans from './transaction';
import Emp from './employee';

ReactDom.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App1 />
    <Trans />
    <Emp />
  </React.StrictMode>,
);