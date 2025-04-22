import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './index.css';

const API_URL = 'http://localhost:5000/contacts';

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
  const [isEdit, setIsEdit] = useState(false);
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

  //reseting the form everything will be null

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
    <div className='container1' >
      <h1 style={{textAlign:"center"}}>Contact Management System</h1>
      <div className='form-container'>

      <h2 style={{color:"#074281"}}>{isEdit ? 'Update Contact' : 'Add Contact'}</h2>
      <form className="ui form" onSubmit={handleSubmit}>
       
          <label>Name</label>
          <input
            type="text"
            value={contact.contactname}
            onChange={(e) => setContact({ ...contact, contactname: e.target.value })}
            required
          />
       
        
          <label>Email</label>
          <input
            type="email"
            value={contact.contactemail}
            onChange={(e) => setContact({ ...contact, contactemail: e.target.value })}
            required></input>
          
       
          <label>Number</label>
          <input
            type="text"
            value={contact.contactnumber}
            onChange={(e) => setContact({ ...contact, contactnumber: e.target.value })}
            required></input>
          
       
          <label>Address</label>
          <input
            type="text"
            value={contact.contactaddress}
            onChange={(e) => setContact({ ...contact, contactaddress: e.target.value })}
            required></input>
          <div className="btn">
          <button  type="submit">
          {isEdit ? 'Update' : 'Submit'}
        </button>
        <button  type="button" onClick={resetForm}>
          Cancel
        </button>
          </div>
          
       
      </form>
      </div>
    

      
<div className='table-container'>
      <h1>Contact

      </h1>
      <table>
        <thead>
            <th>Name</th>
            <th>Email</th>
            <th>Number</th>
            <th>Address</th>
            <th>Actions</th>
        </thead>
        <tbody>
          {contacts.map((item) => (
            <tr key={item.id}>
              <td>{item.contactname}</td>
              <td>{item.contactemail}</td>
              <td>{item.contactnumber}</td>
              <td>{item.contactaddress}</td>
              <td>
               <div className='btn1'>
                <button
                 
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
                  
                  onClick={() => handleDelete(item.id)}
                >
                  Delete
                </button>
                </div>
                
              </td>

            </tr>
            
          ))}
        </tbody>
      </table>
      </div>
    </div>
  );
};

export default Contact;
