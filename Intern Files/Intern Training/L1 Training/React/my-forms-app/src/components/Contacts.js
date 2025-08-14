import React, { useState, useEffect } from "react";
import axios from "axios";
import BackgroundVideo from "../media/BackgroundVideo.mp4";
import "../App.css";

const API_URL = "http://localhost:5000/contacts";

function Contacts() {
  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    document.title = "Z Contacts";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setContacts(response.data);
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
      Name: formData.get("name"),
      Email: formData.get("email"),
      Number: formData.get("number"),
      Address: formData.get("address"),
    };
    try {
      const response = await axios.post(API_URL, data);
      setContacts([...contacts, response.data]);
    } catch (error) {
      console.log(error);
    }
    event.target.reset();
  };

  const handleDelete = async (id) => {
    try {
      await axios.delete(`${API_URL}/${id}`);
      setContacts(contacts.filter((contact) => contact.id !== id));
    } catch (error) {
      console.log(error);
    }
  };

  const handleUpdate = async (id) => {
    const Name = prompt("Enter new name");
    const Email = prompt("Enter new email");
    const Number = prompt("Enter new phone number");
    const Address = prompt("Enter new address");
    if (Name && Email && Number && Address) {
      try {
        const response = await axios.put(`${API_URL}/${id}`, {
          Name,
          Email,
          Number,
          Address,
        });
        setContacts(
          contacts.map((contact) =>
            contact.id === id ? response.data : contact
          )
        );
      } catch (error) {
        console.log(error);
      }
    }
  };

  const DisplayDetails = () => {
    if (contacts.length === 0) {
      return (
        <div className="App">
          <header className="App-header">
            <div className="form-container">
              <h3>Contact Details</h3>
              <p>
                <i>No Contact Details Available!</i>
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
              <h3>Contact Details</h3>
                <table className={"dataTable"}>
                  <thead>
                    <tr>
                      <th className="var">Name</th>
                      <th className="var">Email</th>
                      <th className="var">Number</th>
                      <th className="var">Address</th>
                      <th className="var">Actions</th>
                    </tr>
                  </thead>
                  <tbody>
                    {contacts.map((contact) => (
                      <tr key={contact.id}>
                        <td>{contact.Name}</td>
                        <td>{contact.Email}</td>
                        <td>{contact.Number}</td>
                        <td>{contact.Address}</td>
                        <td>
                          <button className="update-button" onClick={() => handleUpdate(contact.id)}>
                            Update
                          </button>
                          <button className="delete-button" onClick={() => handleDelete(contact.id)}>
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
  };

  return (
    <div className="App">
      <video
        autoPlay
        loop
        muted
        className={"background-video"}
        src={BackgroundVideo}
      ></video>
      <header className="App-header">
        <div className="form-container">
          <h3>Contacts Form</h3>
          <form onSubmit={handleSubmit} noValidate>
            <table>
              <tbody>
                <tr>
                  <td className="var">
                    <label>Name: </label>
                  </td>
                  <td>
                    <input
                      type="text"
                      name="name"
                      placeholder="Enter your Name"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Email: </label>
                  </td>
                  <td>
                    <input
                      type="email"
                      name="email"
                      placeholder="Enter your Email"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Number: </label>
                  </td>
                  <td>
                    <input
                      type="number"
                      name="number"
                      maxLength={10}
                      placeholder="Enter your Number"
                    />
                  </td>
                </tr>
                <tr>
                  <td className="var">
                    <label>Address: </label>
                  </td>
                  <td>
                    <input
                      type="email"
                      name="address"
                      placeholder="Enter your Address"
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

export default Contacts;
