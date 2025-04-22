import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_URL = 'http://localhost:3000/transactions';

type TransactionType = {
  id: number;
  transName: string;
  transDescription: string;
  transMode: string;
};

const Transaction = () => {
  const [transactions, setTransactions] = useState<TransactionType[]>([]);
  const [transaction, setTransaction] = useState<TransactionType>({
    id: 0,
    transName: '',
    transDescription: '',
    transMode: '',
  });
  const [isEdit, setIsEdit] = useState(false);
  const [editId, setEditId] = useState<number | null>(null);
  const [searchText, setSearchText] = useState<string>('');

  const fetchTransactions = async () => {
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

  const handleDelete = async (id: number) => {
    await axios.delete(`${API_URL}/${id}`);
    fetchTransactions();
  };

  const handleEdit = (tx: TransactionType) => {
    setTransaction(tx);
    setIsEdit(true);
    setEditId(tx.id);
  };

  const resetForm = () => {
    setTransaction({ id: 0, transName: '', transDescription: '', transMode: '' });
    setIsEdit(false);
    setEditId(null);
  };

  return (
    <div className="ui container" style={{ marginTop: '2em' }}>
      <h2 className="ui header">{isEdit ? 'Update Transaction' : 'Add Transaction'}</h2>
      <form className="ui form" onSubmit={handleSubmit}>
        <div className="field">
          <label>Name</label>
          <input
            type="text"
            value={transaction.transName}
            onChange={(e) => setTransaction({ ...transaction, transName: e.target.value })}
            required
          />
        </div>
        <div className="field">
          <label>Description</label>
          <input
            type="text"
            value={transaction.transDescription}
            onChange={(e) => setTransaction({ ...transaction, transDescription: e.target.value })}
            required
          />
        </div>
        <div className="field">
          <label>Mode</label>
          <input
            type="text"
            value={transaction.transMode}
            onChange={(e) => setTransaction({ ...transaction, transMode: e.target.value })}
            required
          />
        </div>
        <button className="ui primary button" type="submit">
          {isEdit ? 'Update' : 'Submit'}
        </button>
        <button className="ui button" type="button" onClick={resetForm}>
          Cancel
        </button>
      </form>

      <h3 className="ui dividing header" style={{ marginTop: '3em' }}>Transaction List</h3>
      <div className="ui icon input" style={{ marginBottom: '1em' }}>
        <input
          type="text"
          placeholder="Search by Name or Mode..."
          value={searchText}
          onChange={(e) => setSearchText(e.target.value)}
        />
        <i className="search icon"></i>
      </div>
      <table className="ui celled table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Mode</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {transactions
            .filter((tx) =>
              tx.transName.toLowerCase().includes(searchText.toLowerCase()) ||
              tx.transMode.toLowerCase().includes(searchText.toLowerCase())
            )
            .map((tx) => (
              <tr key={tx.id}>
                <td>{tx.transName}</td>
                <td>{tx.transDescription}</td>
                <td>{tx.transMode}</td>
                <td>
                  <button className="ui blue mini button" onClick={() => handleEdit(tx)}>
                    Edit
                  </button>
                  <button className="ui red mini button" onClick={() => handleDelete(tx.id)}>
                    Delete
                  </button>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default Transaction;