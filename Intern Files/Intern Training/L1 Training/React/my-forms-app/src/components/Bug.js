import React, { useState, useEffect } from "react";
import axios from "axios";
import BackgroundVideo from "../media/BackgroundVideo.mp4";
import "../App.css";

const API_URL = "http://localhost:5000/bugs";

function BugManagement() {
  const [bugs, setBugs] = useState([]);

  useEffect(() => {
    document.title = "Z Bug Report";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setBugs(response.data);
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
      BugID: formData.get("bugId"),
      BugName: formData.get("bugName"),
      BugDescription: formData.get("bugDescription"),
      BugIdentifiedBy: formData.get("bugIdentifiedBy"),
      BugResolvedBy: formData.get("bugResolvedBy"),
    };
    try {
      const response = await axios.post(API_URL, data);
      setBugs([...bugs, response.data]);
    } catch (error) {
      console.log(error);
    }
    event.target.reset();
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${API_URL}/${id}`);
      setBugs(bugs.filter((bug) => bug.id !== id));
    } catch (error) {
      console.log(error);
    }
  };

  const handleUpdate = async (id) => {
    const BugName = prompt("Enter new bug name");
    const BugDescription = prompt("Enter new bug description");
    const BugIdentifiedBy = prompt("Enter new identifier's name");
    const BugResolvedBy = prompt("Enter new resolver's name");
    if (BugName && BugDescription && BugIdentifiedBy && BugResolvedBy) {
      try {
        const response = await axios.put(`${API_URL}/${id}`, {
          BugName,
          BugDescription,
          BugIdentifiedBy,
          BugResolvedBy,
        });
        setBugs(bugs.map((bug) => (bug.id === id ? response.data : bug)));
      } catch (error) {
        console.log(error);
      }
    }
  };

  const DisplayDetails = () => {
    if (bugs.length === 0) {
      return (
        <div className="App">
          <header className="App-header">
            <div className="form-container">
              <h3>Bug Details</h3>
              <p>
                <i>No Bug Details Available!</i>
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
              <h3>Bug Details</h3>
              <div className="dataTable-container">
                <table className="dataTable">
                  <thead>
                    <tr>
                      <th className="var">Bug ID</th>
                      <th className="var">Bug Name</th>
                      <th className="var">Bug Description</th>
                      <th className="var">Identified By</th>
                      <th className="var">Resolved By</th>
                      <th className="var">Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {bugs.map((bug) => (
                      <tr key={bug.id}>
                        <td className="varValue">{bug.BugID}</td>
                        <td className="varValue">{bug.BugName}</td>
                        <td className="varValue">{bug.BugDescription}</td>
                        <td className="varValue">{bug.BugIdentifiedBy}</td>
                        <td className="varValue">{bug.BugResolvedBy}</td>
                        <td>
                          <button className="update-button" onClick={() => handleUpdate(bug.id)}>
                            Update
                          </button>
                          <button className="delete-button" onClick={() => handleDelete(bug.id)}>
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
          <h3>Bug Management Form</h3>
          <form onSubmit={handleSubmit} noValidate>
            <table>
              <tbody>
                <tr>
                  <td className="var">
                    <label>Bug ID:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="bugId"
                      placeholder="Enter Bug ID"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Bug Name:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="bugName"
                      placeholder="Enter Bug Name"
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
                      name="bugDescription"
                      placeholder="Enter Bug Description"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Identified By:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="bugIdentifiedBy"
                      placeholder="Enter Identifier's Name"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Resolved By:</label>
                  </td>
                  <td>
                    <input
                      className="varValue"
                      type="text"
                      name="bugResolvedBy"
                      placeholder="Enter Resolver's Name"
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

export default BugManagement;
