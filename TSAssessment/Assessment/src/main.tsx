import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Waste from './WasteManagement'


createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Waste />
  </StrictMode>,
)
