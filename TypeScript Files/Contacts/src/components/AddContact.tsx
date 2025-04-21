import {useState, useEffect} from "react";
import axios from "axios";
import "./AddContact.css";

const API_URL = "http://localhost:5000/contacts";

function AddContact() {

  useEffect(() => {
    document.title = "Z Contacts - Add Contacts";
  });
  

  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [number, setNumber] = useState(0);
  const [address, setAddress] = useState("");

  const handleSubmit = async (event: any) => {
    event.preventDefault();
    const data = {
      Name: name,
      Email: email,
      Number: number,
      Address: address,
    };

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!name || !email || !number || !address) {
      alert("Please fill in all fields.");
      return;
    } else if (emailRegex.test(email) === false) {
      alert("Please enter a valid email address.");
      return;
    } else if (number < 1000000000 || number > 9999999999) {
      alert("Please enter a valid phone number.");
      return;
    } else {
      try {
        const response = await axios.post(API_URL, data);
        console.log(response.data);
        setName("");
        setEmail("");
        setNumber(0);
        setAddress("");
        alert("Contact added successfully!");
      } catch (error) {
        alert("An error occurred while adding the contact.");
        console.log(error);
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
                <label>Name:</label>
              </td>
              <td>
                <input
                  type="text"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Email:</label>
              </td>
              <td>
                <input
                  type="email"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Number:</label>
              </td>
              <td>
                <input
                  type="number"
                  value={number}
                  onClick={(e) => ((e.target as HTMLInputElement).value = "")}
                  onChange={(e) => setNumber(parseInt(e.target.value))}
                />
              </td>
            </tr>
            <tr>
              <td className="var">
                <label>Address:</label>
              </td>
              <td>
                <input
                  type="text"
                  value={address}
                  onChange={(e) => setAddress(e.target.value)}
                />
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
