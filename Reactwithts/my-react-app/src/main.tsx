import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import TransactionManagement from './transaction.tsx'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <App />
    <TransactionManagement />
  </StrictMode>,
)
