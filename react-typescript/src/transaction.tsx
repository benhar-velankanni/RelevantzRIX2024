import React, { useState, useEffect } from 'react';
import axios from 'axios';

const DisplayTransactions: React.FC<{
  transactions: any[];
  onEdit: (transaction: any) => void;
  onDelete: (id: string) => void;
  searchedTransaction: any | null;
}> = ({ transactions, onEdit, onDelete, searchedTransaction }) => {
  if (transactions.length === 0 && !searchedTransaction) {
    return (
      <div className="ui negative message">
        <div className="header">No transactions to display</div>
      </div>
    );
  }

  return (
    <div>
      <h2 className="ui colorful header">Display Transactions</h2>
      <table className="ui colorful celled table">
        <thead>
          <tr>
            <th className="three wide">Transaction Id</th>
            <th className="three wide">Description</th>
            <th className="three wide">Amount</th>
            <th className="three wide">Date</th>
            <th className="three wide">Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedTransaction ? (
            <tr key={searchedTransaction.transactionId}>
              <td className="three wide">{searchedTransaction.transactionId}</td>
              <td className="three wide">{searchedTransaction.description}</td>
              <td className="three wide">{searchedTransaction.amount}</td>
              <td className="three wide">{searchedTransaction.date}</td>
              <td className="three wide">
                <div className="ui colorful buttons">
                  <button className="ui primary button" onClick={() => onEdit(searchedTransaction)}>
                    Edit
                  </button>
                  <div className="or"></div>
                  <button className="ui red button" onClick={() => onDelete(searchedTransaction.id)}>
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          ) : (
            transactions.map(transaction => (
              <tr key={transaction.transactionId}>
                <td className="three wide">{transaction.transactionId}</td>
                <td className="three wide">{transaction.description}</td>
                <td className="three wide">{transaction.amount}</td>
                <td className="three wide">{transaction.date}</td>
                <td className="three wide">
                  <div className="ui colorful buttons">
                    <button className="ui primary button" onClick={() => onEdit(transaction)}>
                      Edit
                    </button>
                    <div className="or"></div>
                    <button className="ui red button" onClick={() => onDelete(transaction.id)}>
                      Delete
                    </button>
                  </div>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};

const TransactionManagement: React.FC = () => {
  const [transaction, setTransaction] = useState<any>({ transactionId: 0, description: '', amount: 0, date: '' });
  const [transactions, setTransactions] = useState<any[]>([]);
  const [searchId, setSearchId] = useState<string>('');
  const [searchedTransaction, setSearchedTransaction] = useState<any | null>(null);

  useEffect(() => {
    axios.get<any[]>('http://localhost:3000/transaction')
      .then(response => setTransactions(response.data))
      .catch(error => console.log(error));
  }, []);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setTransaction({ ...transaction, [name]: value });
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const existingTransaction = transactions.find(t => t.transactionId === Number(transaction.transactionId));
    if (existingTransaction) {
      alert('Transaction with same id already exists');
    } else {
      axios.post<any>('http://localhost:3000/transaction', transaction)
        .then(response => {
          setTransactions([...transactions, response.data]);
          setTransaction({ transactionId: 0, description: '', amount: 0, date: '' });
        })
        .catch(error => console.log(error));
    }
  };

  const handleEdit = (transaction: any) => {
    setTransaction(transaction);
  };

  const handleDelete = (id: string) => {
    axios.delete(`http://localhost:3000/transaction/${id}`)
      .then(() => setTransactions(transactions.filter(transaction => transaction.id !== id)))
      .catch(error => console.log(error));
  };

  const handleSearch = () => {
    const foundTransaction = transactions.find(transaction => transaction.transactionId.toString() === searchId);
    if (foundTransaction) {
      setSearchedTransaction(foundTransaction);
    } else {
      alert('Transaction not found');
    }
  };

  const checkTransactionId = (transactionId: number) => {
    const existingTransaction = transactions.find(transaction => transaction.transactionId === transactionId);
    if (existingTransaction) {
      alert('Transaction with same id already exists');
      return false;
    }
    return true;
  };

  return (
    <div className="ui container">
      <h1 className="ui colorful dividing header">Transaction Management</h1>
      <form onSubmit={handleSubmit} className="ui colorful form">
        <table className="ui colorful table">
          <tbody>
            <tr>
              <td><label>Transaction Id: </label></td>
              <td><div className="ui input"><input type="number" name="transactionId" value={transaction.transactionId || ''} onChange={handleChange} placeholder="Enter Id" required onBlur={(e) => checkTransactionId(Number(e.target.value))} /></div></td>
            </tr>
            <tr>
              <td><label>Description: </label></td>
              <td><div className="ui input"><input type="text" name="description" value={transaction.description} onChange={handleChange} placeholder="Enter Description" required /></div></td>
            </tr>
            <tr>
              <td><label>Amount: </label></td>
              <td><div className="ui input"><input type="number" name="amount" value={transaction.amount} onChange={handleChange} placeholder="Enter Amount" required /></div></td>
            </tr>
            <tr>
              <td><label>Date: </label></td>
              <td><div className="ui input"><input type="date" name="date" value={transaction.date} onChange={handleChange} placeholder="Enter Date" required /></div></td>
            </tr>
            <tr>
              <td></td>
              <td><button type="submit" id="add" className="ui colorful button primary">{transaction.id ? 'Update' : 'Add'}</button></td>
            </tr>
          </tbody>
        </table>
      </form>
      <div className="ui colorful action input">
        <input type="text" value={searchId} onChange={(e) => setSearchId(e.target.value)} placeholder="Search by Transaction Id" />
        <button className="ui colorful button" onClick={handleSearch} > <i className="search icon"></i>  Search</button>
      </div>
      <DisplayTransactions transactions={transactions} onEdit={handleEdit} onDelete={handleDelete} searchedTransaction={searchedTransaction} />
    </div>
  );
};

export default TransactionManagement;

