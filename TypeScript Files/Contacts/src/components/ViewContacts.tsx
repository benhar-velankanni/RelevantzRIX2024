import { useState, useEffect } from "react";
import axios from "axios";
import "./ViewContacts.css";

const API_URL = "http://localhost:5000/trancactions";

function ViewContacts() {
  useEffect(() => {
    document.title = "Z Contacts - View Contacts";
  });

  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setContacts(response.data);
      } catch (error) {
        console.error("Error fetching contacts:", error);
      }
    };
    fetchData();
  }, []);

  const handleUpdate = async (id: string) => {
    const Name = prompt("Enter new name");
    if (!Name) {
      alert("Please enter a name");
      return;
    }

    const Email = prompt("Enter new email");
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!Email) {
      alert("Please enter a valid email address.");
      return;
    } else if (regex.test(Email) === false) {
      alert("Please enter a valid email address.");
      return;
    }

    const Number = prompt("Enter new phone number");
    if (!Number) {
      alert("Please enter a valid phone number.");
      return;
    } else if (Number.length !== 10) {
      alert("Please enter a valid phone number.");
      return;
    }

    const Address = prompt("Enter new address");
    if (!Address) {
      alert("Please enter a valid phone number.");
      return;
    } else {
      try {
        const response = await axios.put(`${API_URL}/${id}`, {
          Name,
          Email,
          Number,
          Address,
        });
        console.log(response.data);
        setContacts((prevContacts: any) =>
          prevContacts.map((contact: any) => {
            if (contact.id === id) {
              return { ...contact, Name, Email, Number, Address };
            }
            return contact;
          })
        );
      } catch (error) {
        console.error("Error updating contact:", error);
      }
    }
  };

  const handleDelete = async (id: string) => {
    try {
      await axios.delete(`${API_URL}/${id}`);
      setContacts((prevContacts) =>
        prevContacts.filter((contact: any) => contact.id !== id)
      );
    } catch (error) {
      console.error("Error deleting contact:", error);
    }
  };

  if (contacts.length === 0) {
    return (
      <div className="form-container">
        <h3>Contact Details</h3>
        <p>
          <i>No Contact Details Available!</i>
        </p>
      </div>
    );
  } else {
    return (
      <div className="form-container">
        <h3>Contact Details</h3>
        <table className="dataTable">
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
            {contacts.map((contact: any) => (
              <tr key={contact.id}>
                <td style={{ textAlign: "left" }}>{contact.Name}</td>
                <td style={{ textAlign: "left" }}>{contact.Email}</td>
                <td style={{ textAlign: "left" }}>{contact.Number}</td>
                <td style={{ textAlign: "left" }}>{contact.Address}</td>
                <td style={{ textAlign: "center" }}>
                  <button
                    className="update-button"
                    onClick={() => handleUpdate(contact.id)}
                  >
                    Update
                  </button>
                  <button
                    className="delete-button"
                    onClick={() => handleDelete(contact.id)}
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

export default ViewContacts;
