import React, { useState, useEffect } from "react";
import axios from "axios";
import BackgroundVideo from "../media/BackgroundVideo.mp4";
import "../App.css";

const API_URL = "http://localhost:5000/tickets";

function TicketManagement() {
  const [tickets, setTickets] = useState([]);

  useEffect(() => {
    document.title = "Z Tickets";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setTickets(response.data);
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
      TicketID: formData.get("ticketId"),
      Category: formData.get("category"),
      TicketDescription: formData.get("ticketDescription"),
      Priority: formData.get("priority"),
      Status: formData.get("status"),
    };
    try {
      const response = await axios.post(API_URL, data);
      setTickets([...tickets, response.data]);
    } catch (error) {
      console.log(error);
    }
    event.target.reset();
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${API_URL}/${id}`);
      setTickets(tickets.filter((ticket) => ticket.id !== id));
    } catch (error) {
      console.log(error);
    }
  };

  const handleUpdate = async (id) => {
    const TicketID = prompt("Enter new ticket ID");
    const Category = prompt("Enter new category");
    const TicketDescription = prompt("Enter new ticket description");
    const Priority = prompt("Enter new priority");
    const Status = prompt("Enter new status");
    if (TicketID && Category && TicketDescription && Priority && Status) {
      try {
        const response = await axios.put(`${API_URL}/${id}`, {
          TicketID,
          Category,
          TicketDescription,
          Priority,
          Status,
        });
        setTickets(
          tickets.map((ticket) => (ticket.id === id ? response.data : ticket))
        );
      } catch (error) {
        console.log(error);
      }
    }
  };

  const DisplayDetails = () => {
    if (tickets.length === 0) {
      return (
        <div className="App">
          <header className="App-header">
            <div className="form-container">
              <h3>Ticket Details</h3>
              <p>
                <i>No Ticket Details Available!</i>
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
              <h3>Ticket Details</h3>
              <div className="dataTable-container">
                <table className="dataTable">
                  <thead>
                    <tr>
                      <th className="var">Ticket ID</th>
                      <th className="var">Category</th>
                      <th className="var">Description</th>
                      <th className="var">Priority</th>
                      <th className="var">Status</th>
                      <th className="var">Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {tickets.map((ticket) => (
                      <tr key={ticket.id}>
                        <td className="varValue">{ticket.TicketID}</td>
                        <td className="varValue">{ticket.Category}</td>
                        <td className="varValue">{ticket.TicketDescription}</td>
                        <td className="varValue">{ticket.Priority}</td>
                        <td className="varValue">{ticket.Status}</td>
                        <td>
                          <button className="update-button" onClick={() => handleUpdate(ticket.id)}>
                            Update
                          </button>
                          <button className="delete-button" onClick={() => handleDelete(ticket.id)}>
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
          <h3>Ticket Management Form</h3>
          <form onSubmit={handleSubmit} noValidate>
            <table>
              <tbody>
                <tr>
                  <td className="var">
                    <label>Ticket ID:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="ticketId"
                      placeholder="Enter Ticket ID"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Category:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="category"
                      placeholder="Enter Category"
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
                      name="ticketDescription"
                      placeholder="Enter Ticket Description"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Priority:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="priority"
                      placeholder="Enter Priority"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Status:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="status"
                      placeholder="Enter Status"
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

export default TicketManagement;
