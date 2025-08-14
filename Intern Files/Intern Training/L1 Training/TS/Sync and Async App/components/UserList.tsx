import React, { useState, useEffect } from "react";
import {
  fetchUsers,
  deleteUser,
  updateUser,
  createUser,
} from "../services/api";
import UserForm from "./UserForm";
import Button from "@mui/material/Button";

const UserList = () => {
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
    await updateUser(id, userData);
    fetchUsers().then(setUsers);
    setEditingUser(null);
  };

  const handleCreate = async (userData: any) => {
    await createUser(userData);
    fetchUsers().then(setUsers);
  };

  return (
    <div>
      <h2>User List</h2>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user: any) => (
            <tr key={user.id}>
              <td>{user.name}</td>
              <td>{user.email}</td>
              <td>
                <Button
                  variant="contained"
                  color="secondary"
                  onClick={() => handleDelete(user.id)}
                >
                  Delete
                </Button>
                <Button
                  variant="contained"
                  color="primary"
                  onClick={() => handleEdit(user)}
                >
                  Edit
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <UserForm
        fetchUsers={() => fetchUsers().then(setUsers)}
        isEditing={!!editingUser}
        editId={editingUser?.id || null}
        initialData={editingUser || { name: "", email: "" }}
        handleUpdate={handleUpdate}
        handleCreate={handleCreate}
      />
    </div>
  );
};

export default UserList;
