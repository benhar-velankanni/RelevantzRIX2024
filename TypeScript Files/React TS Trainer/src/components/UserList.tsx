import React, { useState, useEffect } from "react";
import {
  fetchUsers,
  deleteUser,
  updateUser,
  createUser,
} from "../services/api";
import UserForm from "./UserForm";
import "./UserList.css";

const UserList: React.FC = () => {
  const [users, setUsers] = useState<any[]>([]);
  const [editingUser, setEditingUser] = useState<any | null>(null);

  useEffect(() => {
    fetchUsers().then(setUsers);
  }, []);

  const handleDelete = async (id: number) => {
    await deleteUser(id);
    fetchUsers().then(setUsers);
  };

  const handleEdit = (user: any) => {
    setEditingUser(user);
  };

  const handleUpdate = async (id: number, userData: any) => {
    if (!userData.name || !userData.age) {
      alert("Please fill in name and age.");
      return;
    } else {
      await updateUser(id, userData);
      fetchUsers().then(setUsers);
      setEditingUser(null);
    }
  };

  const handleCreate = async (userData: any) => {
    if (!userData.name || !userData.age) {
      alert("Please fill in name and age.");
      return;
    } else {
      await createUser(userData);
      fetchUsers().then(setUsers);
    }
  };

  if (users.length !== 0) {
    return (
      <div>
        <h2>User Form</h2>
        <UserForm
          fetchUsers={() => fetchUsers().then(setUsers)}
          isEditing={!!editingUser}
          editId={editingUser ? editingUser.id : null}
          initialData={editingUser || { name: "", age: 0 }}
          name=""
          age={0}
          handleUpdate={handleUpdate}
          handleCreate={handleCreate}
        />
        <br />
        <br />
        <h2>User List</h2>
        <table className="user-table">
          <thead>
            <tr>
              <th>Name</th>
              <th>Age</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr key={user.id}>
                <td>{user.name}</td>
                <td>{user.age}</td>
                <td
                  style={{
                    display: "flex",
                    gap: "10px",
                  }}
                >
                  <button
                    className="edit-button"
                    onClick={() => handleEdit(user)}
                  >
                    Edit
                  </button>
                  <button
                    className="delete-button"
                    onClick={() => handleDelete(user.id)}
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
  } else {
    return (
      <div>
        <h2>User Form</h2>
        <UserForm
          fetchUsers={() => fetchUsers().then(setUsers)}
          isEditing={!!editingUser}
          editId={editingUser ? editingUser.id : null}
          initialData={editingUser || { name: "", age: 0 }}
          name=""
          age={0}
          handleUpdate={handleUpdate}
          handleCreate={handleCreate}
        />
        <br />
        <br />
        <h2>User List</h2>
        <p>No users found.</p>
      </div>
    );
  }
};

export default UserList;
