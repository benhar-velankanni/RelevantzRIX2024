import React, { useState, useEffect } from "react";
import axios from "axios";
import BackgroundVideo from "../media/BackgroundVideo.mp4";
import "../App.css";

const API_URL = "http://localhost:5000/transactions";

function Transactions() {
  const [transactions, setTransactions] = useState([]);

  useEffect(() => {
    document.title = "Z Transactions Report";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setTransactions(response.data);
      } catch (error) {
        console.log(error);
      }
    };
    fetchData();
  }, []);

  const handleSubmit = async (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const data = {
      TransId: formData.get("transId"),
      TransName: formData.get("transName"),
      TransDescription: formData.get("transDescription"),
      TransMode: formData.get("transMode"),
    };
    try {
      const response = await axios.post(API_URL, data);
      setTransactions([...transactions, response.data]);
    } catch (error) {
      console.log(error);
    }
    event.target.reset();
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${API_URL}/${id}`);
      setTransactions(
        transactions.filter((transaction) => transaction.id !== id)
      );
    } catch (error) {
      console.log(error);
    }
  };

  const handleUpdate = async (id) => {
    const TransId = prompt("Enter new transaction id");
    const TransName = prompt("Enter new transaction name");
    const TransDescription = prompt("Enter new transaction description");
    const TransMode = prompt("Enter new transaction mode");
    if (TransId && TransName && TransDescription && TransMode) {
      try {
        const response = await axios.put(`${API_URL}/${id}`, {
          TransId,
          TransName,
          TransDescription,
          TransMode,
        });
        setTransactions(
          transactions.map((transaction) =>
            transaction.id === id ? response.data : transaction
          )
        );
      } catch (error) {
        console.log(error);
      }
    }
  };

  const DisplayDetails = () => {
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
              <div className="dataTable-container">
                <table className="dataTable">
                  <thead>
                    <tr>
                      <th className="var">Transaction ID</th>
                      <th className="var">Transaction Name</th>
                      <th className="var">Description</th>
                      <th className="var">Mode</th>
                      <th className="var">Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {transactions.map((transaction) => (
                      <tr key={transaction.id}>
                        <td className="varValue">{transaction.TransId}</td>
                        <td className="varValue">{transaction.TransName}</td>
                        <td className="varValue">
                          {transaction.TransDescription}
                        </td>
                        <td className="varValue">{transaction.TransMode}</td>
                        <td>
                          <button className="update-button" onClick={() => handleUpdate(transaction.id)}>
                            Update
                          </button>
                          <button className="delete-button" onClick={() => handleDelete(transaction.id)}>
                            Delete
                          </button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            </div>
          </header>
        </div>
      );
    }
  };

  return (
    <div className="App">
      <video
        autoPlay
        loop
        muted
        className="background-video"
        src={BackgroundVideo}
      ></video>
      <header className="App-header">
        <div className="form-container">
          <h3>Transaction Form</h3>
          <form onSubmit={handleSubmit} noValidate>
            <table>
              <tbody>
                <tr>
                  <td className="var">
                    <label>Transaction ID:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="transId"
                      placeholder="Enter Transaction ID"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Name:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="transName"
                      placeholder="Enter Transaction Name"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Description:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="transDescription"
                      placeholder="Enter Description"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Mode:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="transMode"
                      placeholder="Enter Mode (e.g. Online, Cash)"
                    />
                  </td>
                </tr>
              </tbody>
            </table>
            <button className="submit-button" type="submit">Submit</button>
          </form>
        </div>
      </header>
      <DisplayDetails />
    </div>
  );
}

export default Transactions;
