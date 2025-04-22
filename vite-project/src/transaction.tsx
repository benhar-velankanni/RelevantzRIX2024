import React from "react";
import { useState, useEffect } from "react";
import axios from 'axios';
import '../style.css'

const API_URL= 'http://localhost:3005/transactions';

const Transaction = () => {
    
    const [transactions, setTransactions] = useState([]);
    const [transaction, setTransaction] = useState({
      transactionname: '',
      transactionamount: 0,
      transactiondate: '',
      transactioncategory: '',
      transactiontype: '',
    });
    
    const [isEdit, setIsEdit] = useState<boolean>(false);
    const [editId, setEditId] = useState<number | null>(null);
    useEffect(()=>
    {
        fetchTransactions();
        
    }, []);

    const fetchTransactions = async () => {
    const response =await axios.get(API_URL); 
    setTransactions(response.data);  
    }
    const handleSubmit =async(e:React.FormEvent<HTMLFormElement>)=>
    {
        e.preventDefault();
        if(isEdit && editId!==null)
        {
            const response = await axios.put(`${API_URL}/${editId}`,{id:editId,...transaction});
            setTransactions(response.data);
            fetchTransactions();

        }
        else
        {
            const response=await axios.post(API_URL,transaction);
            setTransactions(response.data);
            fetchTransactions();
        }
        resetForm();
        fetchTransactions();
    }
    const handleDelete=async(id:number)=>
    {
        await axios.delete(`${API_URL}/${id}`);
        fetchTransactions();
    }
    
    const resetForm=()=>
    {
        setTransaction({
            transactionname: '',
            transactionamount: 0,
            transactiondate: '',
            transactioncategory: '',
            transactiontype: '',
        });
        setIsEdit(false);
        setEditId(null);
    }

    return (
        <>
        <div>
            <h1>Transaction</h1>
           
            <form onSubmit={handleSubmit} id="box">
            <table>
                <tr>
                    <td>
                        <label htmlFor="transactionname">Transaction Name</label></td>
                       
                        <td>
                       <input type="text" id="transactionname" value={transaction.transactionname} onChange={(e) => setTransaction({ ...transaction, transactionname: e.target.value })} />
                       </td>

                 
                    
                </tr>
                <tr>
                    <td>
                        <label htmlFor="transactionamount">TransactionAmount:</label>
                    </td>
                    <td>
                        <input type="number" id="transactionamount" value={transaction.transactionamount} onChange={(e)=> setTransaction({ ...transaction, transactionamount: Number(e.target.value) })} />

                    </td>
                </tr>
                <tr>
                    <td>
                        <label htmlFor="transactiondate">TransactionDate:</label>
                    </td>
                    <td>
                        <input type="date" id="transactiondate" value={transaction.transactiondate} onChange={(e) => setTransaction({ ...transaction, transactiondate: e.target.value })} />

                    </td>
                </tr>
                <tr>
                    <td>
                        <label htmlFor="transactioncategory">TransactionCategory:</label>
                    </td>
                    <td>
                        <input type="text" id="transactioncategory" value={transaction.transactioncategory} onChange={(e) => setTransaction({ ...transaction, transactioncategory: e.target.value })} />

                    </td>
                    </tr>
                    <tr>
                    <button type="submit">{isEdit ? 'Update' : 'Save'}</button>
                    <button type="button" onClick={resetForm}>Cancel</button>
                    </tr>


            </table>
               
            </form>
            
        </div>

        <div className="result">
            <table>
                <thead>
                    <tr>
                        <th>TransactionName</th>
                        <th>TransactionAmount</th>
                        <th>TransactionDate</th>
                        <th>TransactionCategory</th>
                        <th>TransactionType</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {transactions.map((transaction: any) => (
                        <tr key={transaction.id}>
                            <td>{transaction.transactionname}</td>
                            <td>{transaction.transactionamount}</td>
                            <td>{transaction.transactiondate}</td>  
                            <td>{transaction.transactioncategory}</td>
                            <td>{transaction.transactiontype}</td>
                            <td>
                                <button onClick={() => { setIsEdit(true); setEditId(transaction.id); setTransaction(transaction); }}>Edit</button> 
                            </td>
                            <td>
                                <button onClick={() => handleDelete(transaction.id)}>Delete</button>
                            </td>   
                        </tr>
                    ))}
                </tbody>
            </table>

        </div>
        </>
    )
            
    

    
   
}
export default Transaction;
