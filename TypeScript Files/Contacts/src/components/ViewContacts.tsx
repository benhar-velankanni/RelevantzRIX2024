import { useState, useEffect } from "react";
import axios from "axios";
import "./ViewContacts.css";

const API_URL = "http://localhost:5000/contacts";

function ViewContacts() {
  const [contacts, setContacts] = useState([]);

  useEffect(() => {
    document.title = "Z Contacts - View Contacts";
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
    const ContactId = prompt("Enter new contact ID");
    if (!ContactId) {
      alert("Please enter a contact ID");
      return;
    } else if (
      contacts.filter((contact: any) => contact.ContactId === ContactId)
        .length > 0
    ) {
      alert("Contact ID already exists");
      return;
    }

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
          ContactId,
          Name,
          Email,
          Number,
          Address,
        });
        console.log(response.data);
        setContacts((prevContacts: any) =>
          prevContacts.map((contact: any) => {
            if (contact.id === id) {
              return { ...contact, ContactId, Name, Email, Number, Address };
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

  const handleSearch = async () => {
    const searchValue = prompt(
      "Enter the contact ID to search, IDs start from the 100s:"
    );
    if (!searchValue) {
      alert("Search Cancelled!");
      return;
    } else if (Number(searchValue) < 100) {
      alert("Contact ID must be greater than 100!");
      return;
    }

    const results = contacts.filter(
      (contact: any) => contact.ContactId === searchValue
    );

    if (results.length === 0) {
      alert("No contact found with the given ID!");
    } else {
      results.forEach((contact: any) => {
        alert(
          `Contact found: \n===================\nContact ID: ${contact.ContactId} \nName: ${contact.Name} \nEmail: ${contact.Email} \nNumber: ${contact.Number} \nAddress: ${contact.Address}`
        );
      });
    }
  };

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
            <br />
            <button className="search-button" onClick={handleSearch}>
              Search
            </button>
            <br />
            <table className="dataTable">
              <thead>
                <tr>
                  <th className="var">Contact ID</th>
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
                    <td>{contact.ContactId}</td>
                    <td>{contact.Name}</td>
                    <td>{contact.Email}</td>
                    <td>{contact.Number}</td>
                    <td>{contact.Address}</td>
                    <td>
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
        </header>
      </div>
    );
  }
}

export default ViewContacts;
