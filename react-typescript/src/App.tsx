import React, { useState, useEffect } from 'react';
import axios from 'axios';

const DisplayContacts: React.FC<{
  contacts: any[];
  onEdit: (contact: any) => void;
  onDelete: (id: string) => void;
  searchedContact: any | null;
}> = ({ contacts, onEdit, onDelete, searchedContact }) => {
  if (contacts.length === 0 && !searchedContact) {
    return (
      <div className="no-contacts">
        <h2>No contacts to display</h2>
      </div>
    );
  }

  return (
    <div>
      <h2 className="heading">Display Contacts</h2>
      <table className="tabledisplay">
        <thead>
          <tr>
            <th>Contact Id</th>
            <th>Name</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedContact ? (
            <tr key={searchedContact.contactId}>
              <td>{searchedContact.contactId}</td>
              <td>{searchedContact.name}</td>
              <td>{searchedContact.phone}</td>
              <td>{searchedContact.email}</td>
              <td>
                <button className="save-button" onClick={() => onEdit(searchedContact)}>
                  Edit
                </button>
                <button className="delete-button" onClick={() => onDelete(searchedContact.id)}>
                  Delete
                </button>
              </td>
            </tr>
          ) : (
            contacts.map(contact => (
              <tr key={contact.contactId}>
                <td>{contact.contactId}</td>
                <td>{contact.name}</td>
                <td>{contact.phone}</td>
                <td>{contact.email}</td>
                <td>
                  <button className="save-button" onClick={() => onEdit(contact)}>
                    Edit
                  </button>
                  <button className="delete-button" onClick={() => onDelete(contact.id)}>
                    Delete
                  </button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};

const ContactManagement: React.FC = () => {
  const [contact, setContact] = useState<any>({ contactId: 0, name: '', phone: '', email: '' });
  const [contacts, setContacts] = useState<any[]>([]);
  const [searchId, setSearchId] = useState<string>('');
  const [searchedContact, setSearchedContact] = useState<any | null>(null);

  useEffect(() => {
    axios.get<any[]>('http://localhost:3000/Contact')
      .then(response => setContacts(response.data))
      .catch(error => console.log(error));
  }, []);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setContact({ ...contact, [name]: value });
  };

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const existingContact = contacts.find(c => c.contactId === Number(contact.contactId));
    if (existingContact) {
      alert('Contact with same id already exists');
    } else {
      axios.post<any>('http://localhost:3000/Contact', contact)
        .then(response => {
          setContacts([...contacts, response.data]);
          setContact({ contactId: 0, name: '', phone: '', email: '' });
        })
        .catch(error => console.log(error));
    }
  };

  const handleEdit = (contact: any) => {
    setContact(contact);
  };

  const handleDelete = (id: string) => {
    axios.delete(`http://localhost:3000/Contact/${id}`)
      .then(() => setContacts(contacts.filter(contact => contact.id !== id)))
      .catch(error => console.log(error));
  };

  const handleSearch = () => {
    const foundContact = contacts.find(contact => contact.contactId.toString() === searchId);
    if (foundContact) {
      setSearchedContact(foundContact);
    } else {
      alert('Contact not found');
    }
  };

  const checkContactId = (contactId: number) => {
    const existingContact = contacts.find(c => contact.contactId === contactId);
    if (existingContact) {
      alert('Contact with same id already exists');
      return false;
    }
    return true;
  };

  return (
    <div className="App">
      <h1 className="heading">Contact Management</h1>
      <form onSubmit={handleSubmit}>
        <table className="form-table">
          <tbody>
            <tr>
              <td><label>Contact Id: </label></td>
              <td><input type="number" name="contactId" value={contact.contactId || ''} onChange={handleChange} placeholder="Enter Id" required onBlur={(e) => checkContactId(Number(e.target.value))} /></td>
            </tr>
            <tr>
              <td><label>Name: </label></td>
              <td><input type="text" name="name" value={contact.name} onChange={handleChange} placeholder="Enter Name" required /></td>
            </tr>
            <tr>
              <td><label>Phone: </label></td>
              <td><input type="text" name="phone" value={contact.phone} onChange={handleChange} placeholder="Enter Phone" required /></td>
            </tr>
            <tr>
              <td><label>Email: </label></td>
              <td><input type="email" name="email" value={contact.email} onChange={handleChange} placeholder="Enter Email" required /></td>
            </tr>
            <tr>
              <td></td>
              <td><button type="submit" id="add">{contact.id ? 'Update' : 'Add'} </button></td>
            </tr>
          </tbody>
        </table>
      </form>
      <div className="search-bar">
        <input type="text" value={searchId} onChange={(e) => setSearchId(e.target.value)} placeholder="Search by Contact Id" />
        <button onClick={handleSearch}>Search</button>
      </div>
      <DisplayContacts contacts={contacts} onEdit={handleEdit} onDelete={handleDelete} searchedContact={searchedContact} />
    </div>
  );
};

export default ContactManagement;

