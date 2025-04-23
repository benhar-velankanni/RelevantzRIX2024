import { useState, useEffect } from "react";
import axios from "axios";
import "./AddTranaction.css";

const API_URL = "http://localhost:5000/transactions";

function AddTranaction() {
  const [transactions, setTransactions]: any = useState([]);

  useEffect(() => {
    document.title = "Z Transactions - Add Transaction";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setTransactions(response.data);
      } catch (error) {
        console.error("Error fetching transactions:", error);
      }
    };
    fetchData();
  });

  const handleSubmit = async (event: any) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const data: any = {
      TransId: formData.get("transId"),
      TransName: formData.get("transName"),
      TransDescription: formData.get("transDescription"),
      TransAmount: formData.get("transAmount"),
      TransMode: formData.get("transMode"),
    };

    if (
      !data.TransId ||
      !data.TransName ||
      !data.TransDescription ||
      !data.TransAmount
    ) {
      alert("Please fill in all the fields!");
      return;
    } else if (data.TransId < 100) {
      alert("Transaction ID must be greater than 100!");
      return;
    } else if (
      transactions.filter(
        (transaction: any) => transaction.TransId === data.TransId
      ).length > 0
    ) {
      alert("Transaction ID already exists!");
      return;
    } else if (data.TransMode === "") {
      alert("Please select a transaction mode!");
      return;
    } else {
      try {
        const response = await axios.post(API_URL, data);
        setTransactions([...transactions, response.data]);
        alert("Transaction added successfully!");
        event.target.reset();
      } catch (error) {
        console.error("Error adding contact:", error);
      }
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <div className="form-container">
          <h3>Add Transaction Details</h3>
          <form onSubmit={handleSubmit} noValidate>
            <table>
              <tbody>
                <tr>
                  <td className="var">
                    <label>Transaction ID (IDs starts from 100):</label>
                  </td>
                  <td>
                    <input type="text" name="transId" />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Name:</label>
                  </td>
                  <td>
                    <input type="text" name="transName" />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Description:</label>
                  </td>
                  <td>
                    <input type="text" name="transDescription" />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Amount (in INR):</label>
                  </td>
                  <td>
                    <input type="text" name="transAmount" />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Mode:</label>
                  </td>
                  <td>
                    <select name="transMode">
                      <option value="">Select Mode</option>
                      <option value="Online">Online</option>
                      <option value="Offline">Offline</option>
                    </select>
                  </td>
                </tr>
              </tbody>
            </table>
            <br />
            <button type="submit">Add Transaction</button>
          </form>
        </div>
        <br />
        <br />
      </header>
    </div>
  );
}

export default AddTranaction;
