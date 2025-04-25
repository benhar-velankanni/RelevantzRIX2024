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
      <div className="ui negative message">
        <div className="header">No contacts to display</div>
      </div>
    );
  }

  return (
    <div>
      <h2 className="ui colorful header">Display Contacts</h2>
      <table className="ui colorful celled table">
        <thead>
          <tr>
            <th className="three wide">Contact Id</th>
            <th className="three wide">Name</th>
            <th className="three wide">Phone</th>
            <th className="three wide">Email</th>
            <th className="three wide">Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedContact ? (
            <tr key={searchedContact.contactId}>
              <td className="three wide">{searchedContact.contactId}</td>
              <td className="three wide">{searchedContact.name}</td>
              <td className="three wide">{searchedContact.phone}</td>
              <td className="three wide">{searchedContact.email}</td>
              <td className="three wide">
                <div className="ui colorful buttons">
                  <button className="ui primary button" onClick={() => onEdit(searchedContact)}>
                    Edit
                  </button>
                  <div className="or"></div>
                  <button className="ui red button" onClick={() => onDelete(searchedContact.id)}>
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          ) : (
            contacts.map(contact => (
              <tr key={contact.contactId}>
                <td className="three wide">{contact.contactId}</td>
                <td className="three wide">{contact.name}</td>
                <td className="three wide">{contact.phone}</td>
                <td className="three wide">{contact.email}</td>
                <td className="three wide">
                  <div className="ui colorful buttons">
                    <button className="ui primary button" onClick={() => onEdit(contact)}>
                      Edit
                    </button>
                    <div className="or"></div>
                    <button className="ui red button" onClick={() => onDelete(contact.id)}>
                      Delete
                    </button>
                  </div>
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
    if (contact.id) {
      axios.put<any>(`http://localhost:3000/Contact/${contact.id}`, contact)
        .then(response => {
          setContacts(contacts.map(item => item.id === contact.id ? response.data : item));
          setContact({contactId: 0, name: '', phone: '', email: '' });
        })
        .catch(error => console.log(error));
    } else {
      axios.post<any>('http://localhost:3000/Contact', contact)
        .then(response => {
          setContacts([...contacts, response.data]);
          setContact({contactId: 0, name: '', phone: '', email: '' });
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

  return (
    <div className="ui container">
      <h1 className="ui colorful dividing header">Contact Management</h1>
      <form onSubmit={handleSubmit} className="ui colorful form">
        <table className="ui colorful table">
          <tbody>
            <tr>
              <td><label>Contact Id: </label></td>
              <td><div className="ui input"><input type="number" name="contactId" value={contact.contactId || ''} onChange={handleChange} placeholder="Enter Id" required /></div></td>
            </tr>
            <tr>
              <td><label>Name: </label></td>
              <td><div className="ui input"><input type="text" name="name" value={contact.name} onChange={handleChange} placeholder="Enter Name" required /></div></td>
            </tr>
            <tr>
              <td><label>Phone: </label></td>
              <td><div className="ui input"><input type="text" name="phone" value={contact.phone} onChange={handleChange} placeholder="Enter Phone" required /></div></td>
            </tr>
            <tr>
              <td><label>Email: </label></td>
              <td><div className="ui input"><input type="email" name="email" value={contact.email} onChange={handleChange} placeholder="Enter Email" required /></div></td>
            </tr>
            <tr>
              <td></td>
              <td><button type="submit" id="add" className="ui colorful button primary">{contact.id ? 'Update' : 'Add'}</button></td>
            </tr>
          </tbody>
        </table>
      </form>
      <div className="ui colorful action input">
        <input type="number" value={searchId} onChange={(e) => setSearchId(e.target.value)} placeholder="Search by Contact Id" />
        <button className="ui colorful button" onClick={handleSearch} > <i className="search icon"></i>  Search</button>
      </div>
      <DisplayContacts contacts={contacts} onEdit={handleEdit} onDelete={handleDelete} searchedContact={searchedContact} />
    </div>
  );
};

export default ContactManagement;



