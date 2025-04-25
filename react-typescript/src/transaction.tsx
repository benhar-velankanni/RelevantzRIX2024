import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface User {
  id: string;
  name: string;
  email: string;
  age: string;
  dateOfBirth: string;
}

const Forms: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [formData, setFormData] = useState<User>({ id: '', name: '', email: '', age: '', dateOfBirth: '' });
  const [editingId, setEditingId] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchedUser, setSearchedUser] = useState<User | null>(null);

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = () => {
    axios.get('http://localhost:3000/user')
      .then(res => setUsers(res.data))
      .catch(err => console.log(err));
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (editingId === null) {
      axios.post('http://localhost:3000/user', formData)
        .then(() => {
          fetchUsers();
          setFormData({ id: '', name: '', email: '', age: '', dateOfBirth: '' });
        });
    } else {
      axios.put(`http://localhost:3000/user/${editingId}`, formData)
        .then(() => {
          fetchUsers();
          setFormData({ id: '', name: '', email: '', age: '', dateOfBirth: '' });
          setEditingId(null);
        });
    }
  };

  const handleEdit = (user: User) => {
    setFormData({ id: user.id, name: user.name, email: user.email, age: user.age, dateOfBirth: user.dateOfBirth });
    setEditingId(user.id);
  };

  const handleDelete = (id?: string) => {
    if (id !== undefined) {
      axios.delete(`http://localhost:3000/user/${id}`)
        .then(() => fetchUsers());
    }
  };

  const handleSearch = () => {
    const user = users.find(u => u.id === searchTerm);
    setSearchedUser(user ?? null);
  };

  return (
    <div className="container">
      <h1>User Form</h1>
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
          placeholder="Enter Name"
          value={formData.name}
          onChange={handleChange}
          required
        />
        <input
          type="email"
          name="email"
          placeholder="Enter Email"
          value={formData.email}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="age"
          placeholder="Enter Age"
          value={formData.age}
          onChange={handleChange}
          required
        />
        <input
          type="date"
          name="dateOfBirth"
          placeholder="Enter Date of Birth"
          value={formData.dateOfBirth}
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
            <th>Email</th>
            <th>Age</th>
            <th>Date of Birth</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedUser ? (
            <tr key={searchedUser.id}>
              <td>{searchedUser.id}</td>
              <td>{searchedUser.name}</td>
              <td>{searchedUser.email}</td>
              <td>{searchedUser.age}</td>
              <td>{searchedUser.dateOfBirth}</td>
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
                <td>{user.email}</td>
                <td>{user.age}</td>
                <td>{user.dateOfBirth}</td>
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

