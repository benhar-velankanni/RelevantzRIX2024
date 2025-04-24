import { StrictMode } from "react"
import { createRoot } from "react-dom/client"
import ContactManagement from "./Contact"
import TransactionManagement from "./Transaction"
import "./index.css"

createRoot(document.getElementById("root")!).render(
  <StrictMode>
  
    <ContactManagement />
    <TransactionManagement />
  </StrictMode>
)
