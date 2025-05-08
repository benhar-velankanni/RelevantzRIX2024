
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './WasteManagement.css';
 
interface User {
  id: string;
  name: string;
  Location: string;
  capacity: string;
  Type : string;
}
 
const Forms: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [formData, setFormData] = useState<User>({ id: '', name: '', Location: '', capacity: '', Type: '' });
  const [editingId, setEditingId] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchedUser, setSearchedUser] = useState<User | null>(null);
 
  useEffect(() => {
    fetchUsers();
  }, []);
 
  const fetchUsers = () => {
    axios.get('http://localhost:3000/users')
      .then(res => setUsers(res.data))
      .catch(err => console.log(err));
  };
 
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };
 
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (editingId === null) {
      axios.post('http://localhost:3000/users', formData)
        .then(() => {
          fetchUsers();
          setFormData({ id: '', name: '', Location: '', capacity: '', Type: '' });
        });
        alert("User added successfully")
    } else {
      axios.put(`http://localhost:3000/users/${editingId}`, formData)
        .then(() => {
          fetchUsers();
          setFormData({ id: '', name: '', Location: '', capacity: '', Type: '' });
          setEditingId(null);
        });
    }
  };
 
  const handleEdit = (user: User) => {
    setFormData({ id: user.id, name: user.name, Location: user.Location, capacity: user.capacity, Type: user.Type });
    setEditingId(user.id);
  };
  
 
  const handleDelete = (id?: string) => {
    if (id !== undefined) {
      axios.delete(`http://localhost:3000/users/${id}`)
        .then(() => fetchUsers());
    }
  };
  
 
  const handleSearch = () => {
    const user = users.find(u => u.id === searchTerm);
    setSearchedUser(user ?? null);
  };
 
  return (
    <div className="container">
      <h1>WASTE  MANAGEMENT  SYSTEM </h1>
      <form onSubmit={handleSubmit} className="user-form">
        <input
        
          type="text"
          name="id"
          placeholder="Enter ID"
          value={formData.id}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="name"
          placeholder="Enter Name of the customer"
          value={formData.name}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="Location"
          placeholder="Enter Location of the waste"
          value={formData.Location}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="capacity"
          placeholder="Enter Capacity"
          value={formData.capacity}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="Type"
          placeholder="Enter the Type of Waste"
          value={formData.Type}
          onChange={handleChange}
          required
        />
        <button type="submit">{editingId ? 'Update' : 'Submit'}</button>
      </form>
      <div>
        <input

          type="text"
          placeholder="Search by ID"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Location</th>
            <th>Capacity</th>
            <th>Type</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedUser ? (
            <tr key={searchedUser.id}>
              <td>{searchedUser.id}</td>
              <td>{searchedUser.name}</td>
              <td>{searchedUser.Location}</td>
              <td>{searchedUser.capacity}</td>
              <td>{searchedUser.Type}</td>
              <td>
                <button className="edit" onClick={() => handleEdit(searchedUser)}>Edit</button>
                <button className="delete" onClick={() => handleDelete(searchedUser.id)}>Delete</button>
              </td>
            </tr>
          ) : (
            users.map((user, index) => (
              <tr key={user.id}>
                <td>{user.id}</td>
                <td>{user.name}</td>
                <td>{user.Location }</td>
                <td>{user.capacity}</td>
                <td>{user.Type}</td>
                <td>
                  <button className="edit" onClick={() => handleEdit(user)}>Edit</button>
                  <button className="delete" onClick={() => handleDelete(user.id)}>Delete</button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};
 
export default Forms;
 
 
