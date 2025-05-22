import React, { useState, useEffect } from "react";
import axios from "axios";
import "./style.css";

interface Transaction {
  id: number;
  tname: string;
  amount: string;
  description: string;
  mode: string;
}

const App = () => {
  const [transactions, setTransactions] = useState<Transaction[]>([]);
  const [tname, setTname] = useState("");
  const [amount, setAmount] = useState("");
  const [description, setDescription] = useState("");
  const [mode, setMode] = useState("online"); // default mode is online
  const [search, setSearch] = useState("");
  const [updateId, setUpdateId] = useState<number | null>(null);

  useEffect(() => {
    const fetchTransactions = async () => {
      try {
        const response = await axios.get("http://localhost:5000/transactions");
        setTransactions(response.data);
      } catch (error) {
        console.log("Error fetching transactions:", error);
      }
    };
    fetchTransactions();
  }, []);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (updateId === null) {
      try {
        const response = await axios.post("http://localhost:5000/transactions", {
          tname,
          amount,
          description,
          mode
        });
        setTransactions([...transactions, response.data]);
        setTname("");
        setAmount("");
        setDescription("");
        setMode("online"); // reset mode to online after creating a new transaction
      } catch (error) {
        console.log("Error creating transaction:", error);
      }
    } else {
      try {
        const response = await axios.put(`http://localhost:5000/transactions/${updateId}`, {
          tname,
          amount,
          description,
          mode
        });
        setTransactions(transactions.map(transaction => transaction.id === updateId ? response.data : transaction));
        setUpdateId(null);
        setTname("");
        setAmount("");
        setDescription("");
        setMode("online"); // reset mode to online after updating a transaction
      } catch (error) {
        console.log("Error updating transaction:", error);
      }
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await axios.delete(`http://localhost:5000/transactions/${id}`);
      setTransactions(transactions.filter(transaction => transaction.id !== id));
    } catch (error) {
      console.log("Error deleting transaction:", error);
    }
  };

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
  };

  const handleModeChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setMode(e.target.value);
  };

  const filteredTransactions = transactions.filter(transaction => transaction.tname.toLowerCase().includes(search.toLowerCase()));

  return (
    <div>
      <h1>Transactions</h1>
      <form onSubmit={handleSubmit}>
        <label>Tname</label>
        <input type="text" value={tname} onChange={(e) => setTname(e.target.value)} />
        <label>Amount</label>
        <input type="text" value={amount} onChange={(e) => setAmount(e.target.value)} />
        <label>Description</label>
        <input type="text" value={description} onChange={(e) => setDescription(e.target.value)} />
        <label>Mode</label>
        <select value={mode} onChange={handleModeChange}>
          <option value="online">Online</option>
          <option value="offline">Offline</option>
        </select>
        <br></br>
        <button type="submit">{updateId === null ? "Create" : "Update"}</button>
      </form>
      <div>
        <input type="text" value={search} onChange={handleSearch} placeholder="Search by tname" />
      </div>
      <h3>Transaction list</h3>
      {filteredTransactions.length === 0 ? (
        <p>No transactions yet</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Tname</th>
              <th>Amount</th>
              <th>Description</th>
              <th>Mode</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {filteredTransactions.map((transaction) => (
              <tr key={transaction.id}>
                <td>{transaction.tname}</td>
                <td>{transaction.amount}</td>
                <td>{transaction.description}</td>
                <td>{transaction.mode}</td>
                <td>
                <button onClick={() => {
                    setUpdateId(transaction.id);
                    setTname(transaction.tname);
                    setAmount(transaction.amount);
                    setDescription(transaction.description);
                    setMode(transaction.mode);
                  }}>Update</button>
                  <br></br>
                  <br></br>
                  <button onClick={() => handleDelete(transaction.id)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default App;