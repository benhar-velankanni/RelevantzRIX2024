import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import SyncApp from './SyncApp.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
     <SyncApp/>
     <App />
  </StrictMode>,
)
