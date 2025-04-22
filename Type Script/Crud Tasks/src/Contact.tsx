
import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_URL = 'http://localhost:3000/contacts';

type ContactType = {
  id: number;
  contactname: string;
  contactemail: string;
  contactnumber: string;
  contactaddress: string;
};

const Contact = () => {
  const [contacts, setContacts] = useState<ContactType[]>([]);
  const [contact, setContact] = useState<Omit<ContactType, 'id'>>({
    contactname: '',
    contactemail: '',
    contactnumber: '',
    contactaddress: '',
  });

  const [isEdit, setIsEdit] = useState<boolean>(false);
  const [editId, setEditId] = useState<number | null>(null);

  const fetchContacts = async () => {
    const response = await axios.get(API_URL);
    setContacts(response.data);
  };

  useEffect(() => {
    fetchContacts();
  }, []);

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (isEdit && editId !== null) {
      await axios.put(`${API_URL}/${editId}`, { id: editId, ...contact });
    } else {
      await axios.post(API_URL, contact);
    }
    resetForm();
    fetchContacts();
  };

  const handleDelete = async (id: number) => {
    await axios.delete(`${API_URL}/${id}`);
    fetchContacts();
  };

  const resetForm = () => {
    setContact({
      contactname: '',
      contactemail: '',
      contactnumber: '',
      contactaddress: '',
    });
    setIsEdit(false);
    setEditId(null);
  };

  return (
    <div className="ui container" style={{ marginTop: '2em' }}>
      <h2 className="ui header">{isEdit ? 'Update Contact' : 'Add Contact'}</h2>
      <form className="ui form" onSubmit={handleSubmit}>
        <div className="field">
          <label>Name</label>
          <input
            type="text"
            value={contact.contactname}
            onChange={(e) => setContact({ ...contact, contactname: e.target.value })}
            required
          />
        </div>
        <div className="field">
          <label>Email</label>
          <input
            type="email"
            value={contact.contactemail}
            onChange={(e) => setContact({ ...contact, contactemail: e.target.value })}
            required
          />
        </div>
        <div className="field">
          <label>Number</label>
          <input
            type="text"
            value={contact.contactnumber}
            onChange={(e) => setContact({ ...contact, contactnumber: e.target.value })}
            required
          />
        </div>
        <div className="field">
          <label>Address</label>
          <input
            type="text"
            value={contact.contactaddress}
            onChange={(e) => setContact({ ...contact, contactaddress: e.target.value })}
            required
          />
        </div>
        <div className="ui buttons">
        <button className="ui positive button" type="submit">
          {isEdit ? 'Update' : 'Submit'}
        </button>
        <div className="or"></div>
        <button className="ui button" type="button" onClick={resetForm}>
          Cancel
        </button>
        </div>
      </form>

      <h3 className="ui dividing header" style={{ marginTop: '3em' }}>Contact List</h3>
      <table className="ui celled table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Number</th>
            <th>Address</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {contacts.map((item) => (
            <tr key={item.id}>
              <td>{item.contactname}</td>
              <td>{item.contactemail}</td>
              <td>{item.contactnumber}</td>
              <td>{item.contactaddress}</td>
              <td>
                <button
                  className="ui blue mini button"
                  onClick={() => {
                    const { id, ...rest } = item;
                    setContact(rest);
                    setIsEdit(true);
                    setEditId(id);
                  }}
                >
                  Edit
                </button>
                <button
                  className="ui red mini button"
                  onClick={() => handleDelete(item.id)}
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
};

export default Contact;
