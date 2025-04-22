import { useState, useEffect } from "react";
import axios from "axios";
import "./AddContact.css";

const API_URL = "http://localhost:5000/contacts";

function AddContact() {
  const [contacts, setContacts]: any = useState([]);

  useEffect(() => {
    document.title = "Z Contacts - Add Contacts";
    const fetchData = async () => {
      try {
        const response = await axios.get(API_URL);
        setContacts(response.data);
      } catch (error) {
        console.error("Error fetching transactions:", error);
      }
    };
    fetchData();
  });

  const handleSubmit = async (event: any) => {
    event.preventDefault();
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const formdata = new FormData(event.target);
    const data: any = {
      ContactId: formdata.get("contactId"),
      Name: formdata.get("name"),
      Email: formdata.get("email"),
      Number: formdata.get("number"),
      Address: formdata.get("address"),
    };

    if (
      !data.ContactId ||
      !data.Name ||
      !data.Email ||
      !data.Number ||
      !data.Address
    ) {
      alert("Please fill in all the fields!");
      return;
    } else if (
      contacts.filter((contact: any) => contact.ContactId === data.ContactId)
        .length > 0
    ) {
      alert("Contact ID already exists!");
      return;
    } else if (emailRegex.test(data.Email) === false) {
      alert("Please enter a valid email address.");
      return;
    } else if (data.Number.length !== 10) {
      alert("Please enter a valid phone number.");
      return;
    } else {
      try {
        const response = await axios.post(API_URL, data);
        setContacts([...contacts, response.data]);
        alert("Contact added successfully!");
        event.target.reset();
      } catch (error) {
        console.error("Error adding contact:", error);
      }
    }
  };

  return (
    <div className="form-container">
      <h3>Add Contact Details</h3>
      <form onSubmit={handleSubmit} noValidate>
        <table>
          <tbody>
            <tr>
              <td className="var">
                <label>Contact ID:</label>
              </td>
              <td>
                <input type="number" name="contactId" />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Name:</label>
              </td>
              <td>
                <input type="text" name="name" />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Email:</label>
              </td>
              <td>
                <input type="email" name="email" />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Number:</label>
              </td>
              <td>
                <input type="number" name="number" />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Address:</label>
              </td>
              <td>
                <input type="text" name="address" />
              </td>
            </tr>
          </tbody>
        </table>
        <br />
        <button type="submit">Add</button>
      </form>
    </div>
  );
}

export default AddContact;
