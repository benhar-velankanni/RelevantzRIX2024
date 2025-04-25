import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface User {
  id: string;
  name: string;
  position: string;
  resume: string;
  interviewStatus: string;
}

const Forms: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [formData, setFormData] = useState<User>({ id: '', name: '', position: '', resume: '', interviewStatus: '' });
  const [editingId, setEditingId] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchedUser, setSearchedUser] = useState<User | null>(null);

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = () => {
    axios.get('http://localhost:3000/candidates')
      .then(res => setUsers(res.data))
      .catch(err => console.log(err));
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (editingId === null) {
      axios.post('http://localhost:3000/candidates', formData)
        .then(() => {
          fetchUsers();
          setFormData({ id: '', name: '', position: '', resume: '', interviewStatus: '' });
        });
    } else {
      axios.put(`http://localhost:3000/candidates/${editingId}`, formData)
        .then(() => {
          fetchUsers();
          setFormData({ id: '', name: '', position: '', resume: '', interviewStatus: '' });
          setEditingId(null);
        });
    }
  };

  const handleEdit = (id: string) => {
    const user = users.find(u => u.id === id);
    if (user) {
      setFormData(user);
      setEditingId(id);
    }
  };

  const handleDelete = (id?: string) => {
    if (id !== undefined) {
      axios.delete(`http://localhost:3000/candidates/${id}`)
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
          type="text"
          name="position"
          placeholder="Enter Position"
          value={formData.position}
          onChange={handleChange}
          required
        />
        <input
          type="file"
          name="resume"
          onChange={(e) => setFormData({ ...formData, resume: e.target.files?.[0]?.name || '' })}
          required
        />
        <input
          type="text"
          name="interviewStatus"
          placeholder="Enter Interview Status"
          value={formData.interviewStatus}
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
            <th>Position</th>
            <th>Resume</th>
            <th>Interview Status</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedUser ? (
            <tr key={searchedUser.id}>
              <td>{searchedUser.id}</td>
              <td>{searchedUser.name}</td>
              <td>{searchedUser.position}</td>
              <td>{searchedUser.resume}</td>
              <td>{searchedUser.interviewStatus}</td>
              <td>
                <button className="edit" onClick={() => handleEdit(searchedUser.id)}>Edit</button>
                <button className="delete" onClick={() => handleDelete(searchedUser.id)}>Delete</button>
              </td>
            </tr>
          ) : (
            users.map((user) => (
              <tr key={user.id}>
                <td>{user.id}</td>
                <td>{user.name}</td>
                <td>{user.position}</td>
                <td>{user.resume}</td>
                <td>{user.interviewStatus}</td>
                <td>
                  <button className="edit" onClick={() => handleEdit(user.id)}>Edit</button>
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
