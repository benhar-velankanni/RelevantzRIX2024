import React from "react"; 
import UserList from "./components/UserList"; 
import TransactionList from "./components/TransactionForm";

 
const App = () => { 
    return ( 
        <div> 
            <h1>CRUD App with Rich Async UI</h1>            
            <UserList />
            <TransactionList />
            
            
    
        </div> 
    ); 
}; 
 
export default App;