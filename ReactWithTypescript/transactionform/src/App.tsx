import React from "react";
import TransactionManagement from "./components/Transactionform";

import "./style.css";
 
const App: React.FC = () => {
  return (
    <div className='container'>
         <TransactionManagement />
          
    </div>
  );
};
 
export default App