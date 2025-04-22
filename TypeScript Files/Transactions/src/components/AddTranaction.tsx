import { useState, useEffect } from "react";
import axios from "axios";
import "./AddTranaction.css";

const API_URL = "http://localhost:5000/transactions";

function AddTranaction() {
  useEffect(() => {
    document.title = "Z Transactions - Add Transaction";
  });

  const [transId, setTransId] = useState("");
  const [transName, setTransName] = useState("");
  const [transDescription, setTransDescription] = useState("");
  const [transMode, setTransMode] = useState("");

  const handleSubmit = async (event: any) => {
    event.preventDefault();
    const data = {
      TransId: transId,
      TransName: transName,
      TransDescription: transDescription,
      TransMode: transMode,
    };

    if (!transId || !transName || !transDescription || !transMode) {
      alert("Please fill in all fields.");
      return;
    } else {
      try {
        const response = await axios.post(API_URL, data);
        console.log(response.data);
        setTransId("");
        setTransName("");
        setTransDescription("");
        setTransMode("");
        alert("Transaction added successfully!");
      } catch (error) {
        alert("An error occurred while adding the transaction.");
        console.log(error);
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
                    <label>Transaction ID:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      value={transId}
                      onChange={(e) => setTransId(e.target.value)}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Name:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      value={transName}
                      onChange={(e) => setTransName(e.target.value)}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Description:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      value={transDescription}
                      onChange={(e) => setTransDescription(e.target.value)}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Transaction Mode:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      value={transMode}
                      onChange={(e) => setTransMode(e.target.value)}
                    />
                  </td>
                </tr>
              </tbody>
            </table>
            <br />
            <button type="submit">Add</button>
          </form>
        </div>
        <br />
        <br />
      </header>
    </div>
  );
}

export default AddTranaction;
