import React, { useEffect, useState } from "react";
import "../App.css";
import axios from "axios";
import BackgroundVideo from "../media/BackgroundVideo.mp4";

const API_URL = "http://localhost:5001/contacts";

function ContactServices() {
  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    axios
      .get(API_URL)
      .then((response) => {
        setContacts(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const handleSubmit = (event) => {
    event.preventDefault();
    const formData = new FormData(event.target);
    const data = {
      name: formData.get("name"),
      email: formData.get("email"),
      phone: formData.get("phone"),
    };
    axios
      .post(API_URL, data)
      .then((response) => {
        setContacts([...contacts, response.data]);
      })
      .catch((error) => {
        console.log(error);
      });
    event.target.reset();
  };

  const handleDelete = (id) => {
    axios
      .delete(`${API_URL}/${id}`)
      .then(() => {
        setContacts(contacts.filter((contact) => contact.id !== id));
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleUpdate = (id) => {
    let name, email, phone;

    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    while (!name || !email || !phone) {
      name = prompt("Enter new name");

      email = prompt("Enter new email");
      if (!re.test(String(email).toLowerCase())) {
        alert("Invalid email!");
        email = "";
        continue;
      }

      phone = prompt("Enter new phone number");
      if (phone.length !== 10) {
        alert("Invalid phone number!");
        phone = "";
        continue;
      }

      if (!name || !email || !phone) {
        alert("All fields are required!");
      } else {
        axios
          .put(`${API_URL}/${id}`, {
            name,
            email,
            phone,
          })
          .then(() => {
            setContacts(
              contacts.map((contact) =>
                contact.id === id ? { ...contact, name, email, phone } : contact
              )
            );
          })
          .catch((error) => {
            console.log(error);
          });
      }
    }
  };

  const DisplayContacts = () => {
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
                  </tr>
                </thead>
                <tbody>
                  {contacts.map((contact) => (
                    <tr key={contact.id}>
                      <td>{contact.name}</td>
                      <td>{contact.email}</td>
                      <td>{contact.phone}</td>
                      <td>
                        <button onClick={() => handleUpdate(contact.id)}>
                          Edit
                        </button>
                        <button onClick={() => handleDelete(contact.id)}>
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
        className="background-video"
        src={BackgroundVideo}
      ></video>
      <header className="App-header">
        <div className="form-container">
          <h1>Contacts</h1>
          <form onSubmit={handleSubmit}>
            <input type="text" name="name" placeholder="Name" />
            <input type="email" name="email" placeholder="Email" />
            <input type="text" name="phone" placeholder="Phone Number" />
            <button type="submit">Add Contact</button>
          </form>
          <DisplayContacts />
        </div>
      </header>
    </div>
  );
}

export default ContactServices;
