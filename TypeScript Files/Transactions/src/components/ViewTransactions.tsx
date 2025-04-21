import { useState, useEffect } from "react";
import axios from "axios";
import "./ViewTransactions.css";

const API_URL = "http://localhost:5000/transactions";

function ViewTransactions() {
  useEffect(() => {
    document.title = "Z Transactions - View Transactions";
  });

  const [transactions, setTransactions] = useState([]);

  useEffect(() => {
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
    const TransName = prompt("Enter new transaction name");
    if (!TransName) {
      alert("Please enter a transaction name");
      return;
    }

    const TransDescription = prompt("Enter new transaction description");
    if (!TransDescription) {
      alert("Please enter a transaction description");
      return;
    }

    const TransMode = prompt("Enter new transaction mode");
    if (!TransMode) {
      alert("Please enter a transaction mode");
      return;
    }

    try {
      const response = await axios.put(`${API_URL}/${id}`, {
        TransName,
        TransDescription,
        TransMode,
      });
      console.log(response.data);
      setTransactions((prevTransactions: any) =>
        prevTransactions.map((transaction: any) => {
          if (transaction.id === id) {
            return { ...transaction, TransName, TransDescription, TransMode };
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

  if (transactions.length === 0) {
    return (
      <div className="form-container">
        <h3>Transaction Details</h3>
        <p>
          <i>No Transaction Details Available!</i>
        </p>
      </div>
    );
  } else {
    return (
      <div className="form-container">
        <h3>Transaction Details</h3>
        <table className="dataTable">
          <thead>
            <tr>
              <th className="var">Name</th>
              <th className="var">Description</th>
              <th className="var">Mode</th>
              <th className="var">Actions</th>
            </tr>
          </thead>
          <tbody>
            {transactions.map((transaction: any) => (
              <tr key={transaction.id}>
                <td style={{ textAlign: "left" }}>{transaction.TransName}</td>
                <td style={{ textAlign: "left" }}>{transaction.TransDescription}</td>
                <td style={{ textAlign: "left" }}>{transaction.TransMode}</td>
                <td style={{ textAlign: "center" }}>
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
    );
  }
}

export default ViewTransactions;

