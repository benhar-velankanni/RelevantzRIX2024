
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './index.css'
const API_URL = 'http://localhost:5000/transactions';

type Transaction = {
  id: number;
  transName: string;
  transDescription: string;
  transMode: string;
};

const Transaction = () => {
  const [transactions, setTransactions] = useState<Transaction[]>([]);
  const [transaction, setTransaction] = useState<Omit<Transaction,"id">>({
    transName: '',
    transDescription: '',
    transMode: '',
  });
  const [isEdit, setIsEdit] = useState(false);
  const [editId, setEditId] = useState<number | null>(null);
  const [searchText, setSearchText] = useState<string>('');
 

  const fetchTransactions = async () => 
    {
    const response = await axios.get(API_URL);
    setTransactions(response.data);
  };

  useEffect(() => {
    fetchTransactions();
  }, []);
   
    
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (isEdit && editId !== null) {
      await axios.put(`${API_URL}/${editId}`, transaction);
    } else {
      await axios.post(API_URL, transaction);
    }
    resetForm();
    fetchTransactions();
  };
  const handleEdit = (tx: Transaction) => {
    setTransaction(tx);
    setIsEdit(true);
    setEditId(tx.id);
  };
 

  const handleDelete = async (id: number) => {
    await axios.delete(`${API_URL}/${id}`);
    fetchTransactions();
  };

  const resetForm = () => {
    setTransaction({
      transName: '',
      transDescription: '',
      transMode: '',
    });
    setIsEdit(false);
    setEditId(null);
  };

  return (
    <div className='container2'>
      <h1 style={{textAlign:'center'}}>Transaction Management System</h1>
    <div  className='Contact-container'>
      
      <h2 style={{textAlign:'center'}}>{isEdit ? 'Update Transaction' : 'Add Transaction'}</h2>
      <form  onSubmit={handleSubmit}>
        
          <label>Transaction Name</label>
          <input type="text" value={transaction.transName} onChange={(e) => setTransaction({ ...transaction, transName: e.target.value })} required />
        
       
          <label>Description</label>
          <input type="text" value={transaction.transDescription} onChange={(e) => setTransaction({ ...transaction, transDescription: e.target.value })} required />
      
       
          <label>Mode</label>
          <input type="text" value={transaction.transMode} onChange={(e) => setTransaction({ ...transaction, transMode: e.target.value })} required />
        <div className='btn'>
        <button  type="submit">
          {isEdit ? 'Update' : 'Submit'}
        </button>
        <button  type="button" onClick={resetForm}>
          Cancel
        </button>
        </div>
      </form>
      </div>
      <div>

      <h3 style={{textAlign:"center"}}>Transaction List</h3>
      <div className='search-container'>
        <input
          type="text"
          placeholder="Search by Name or Mode..."
          value={searchText}
          onChange={(e) => setSearchText(e.target.value)}
        />
        </div>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Mode</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {transactions.filter((tx) =>tx.transName.toLowerCase().includes(searchText.toLowerCase()) ||tx.transMode.toLowerCase().includes(searchText.toLowerCase())
            )
            .map((tx) => (
              <tr key={tx.id}>
                <td>{tx.transName}</td>
                <td>{tx.transDescription}</td>
                <td>{tx.transMode}</td>

                <td>
                <div className='btn1'>
                  <button  onClick={() => handleEdit(tx)}>
                    Edit
                  </button>
                  <button  onClick={() => handleDelete(tx.id)}>
                    Delete
                  </button>
                  </div>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
 
    </div>
    </div>
  );
};

export default Transaction;
