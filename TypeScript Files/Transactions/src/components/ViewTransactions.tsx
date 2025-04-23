import { useState, useEffect } from "react";
import axios from "axios";
import "./ViewTransactions.css";

const API_URL = "http://localhost:5000/transactions";

function ViewTransactions() {
  const [transactions, setTransactions] = useState([]);

  useEffect(() => {
    document.title = "Z Transactions - View Transactions";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setTransactions(response.data);
      } catch (error) {
        console.error("Error fetching transactions:", error);
      }
    };
    fetchData();
  }, []);

  const handleUpdate = async (id: string) => {
    const TransId = prompt("Enter new transaction ID:");
    if (!TransId) {
      alert("Please enter a transaction ID!");
      return;
    } else if (
      transactions.filter((transaction: any) => transaction.TransId === TransId)
        .length > 0
    ) {
      alert("Transaction ID already exists!");
      return;
    }

    const TransName = prompt("Enter new transaction name:");
    if (!TransName) {
      alert("Please enter a transaction name!");
      return;
    }

    const TransDescription = prompt("Enter new transaction description:");
    if (!TransDescription) {
      alert("Please enter a transaction description!");
      return;
    }

    const TransAmount = prompt("Enter new transaction amount:");
    if (!TransAmount) {
      alert("Please enter a transaction amount!");
      return;
    }

    const TransMode = prompt("Enter new transaction mode:");
    if (!TransMode) {
      alert("Please enter a transaction mode!");
      return;
    }

    try {
      const response = await axios.put(`${API_URL}/${id}`, {
        TransId,
        TransName,
        TransDescription,
        TransAmount,
        TransMode,
      });
      console.log(response.data);
      setTransactions((prevTransactions: any) =>
        prevTransactions.map((transaction: any) => {
          if (transaction.id === id) {
            return {
              ...transaction,
              TransId,
              TransName,
              TransDescription,
              TransAmount,
              TransMode,
            };
          }
          return transaction;
        })
      );
    } catch (error) {
      console.error("Error updating transaction:", error);
    }
  };

  const handleDelete = async (id: string) => {
    try {
      await axios.delete(`${API_URL}/${id}`);
      setTransactions((prevTransactions) =>
        prevTransactions.filter((transaction: any) => transaction.id !== id)
      );
    } catch (error) {
      console.error("Error deleting transaction:", error);
    }
  };

  const handleSearch = async () => {
    const searchValue = prompt(
      "Enter the transaction ID to search, IDs start from the 100s:"
    );
    if (!searchValue) {
      alert("Search Cancelled!");
      return;
    } else if (Number(searchValue) < 100) {
      alert("Transaction ID must be greater than 100!");
      return;
    }

    const results = transactions.filter(
      (transaction: any) => transaction.TransId === searchValue
    );

    if (results.length === 0) {
      alert("No transaction found with the given ID!");
    } else {
      results.forEach((transaction: any) => {
        alert(
          `Transaction found: \n===================\nName: ${transaction.TransName} \nAmount: ${transaction.TransAmount} INR \nDescription: ${transaction.TransDescription} \nMode: ${transaction.TransMode}`
        );
      });
    }
  };

  if (transactions.length === 0) {
    return (
      <div className="App">
        <header className="App-header">
          <div className="form-container">
            <h3>Transaction Details</h3>
            <p>
              <i>No Transaction Details Available!</i>
            </p>
          </div>
        </header>
      </div>
    );
  } else {
    return (
      <div className="App">
        <header className="App-header">
          <div className="form-container">
            <h3>Transaction Details</h3>
            <br />
            <button className="search-button" onClick={handleSearch}>
              Search
            </button>
            <br />
            <table className="dataTable">
              <thead>
                <tr>
                  <th className="var">ID</th>
                  <th className="var">Name</th>
                  <th className="var">Description</th>
                  <th className="var">Amount</th>
                  <th className="var">Mode</th>
                  <th className="var">Actions</th>
                </tr>
              </thead>
              <tbody>
                {transactions.map((transaction: any) => (
                  <tr key={transaction.id}>
                    <td>{transaction.TransId}</td>
                    <td>{transaction.TransName}</td>
                    <td>{transaction.TransDescription}</td>
                    <td>{transaction.TransAmount} INR</td>
                    <td>{transaction.TransMode}</td>
                    <td>
                      <button
                        className="update-button"
                        onClick={() => handleUpdate(transaction.id)}
                      >
                        Update
                      </button>
                      <button
                        className="delete-button"
                        onClick={() => handleDelete(transaction.id)}
                      >
                        Delete
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </header>
      </div>
    );
  }
}

export default ViewTransactions;
