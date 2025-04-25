import React, { useState, useEffect } from "react";
import SyncUserList from "./components/SyncUserList";
import SyncUserForm from "./components/SyncUserForm";
import { fetchUsers, deleteUser, updateUser, createUser } from "./services/api";

const SyncApp = () => {
    const [users, setUsers] = useState<any[]>([]);
    const [editingUser, setEditingUser] = useState<any | null>(null);

    useEffect(() => {
        const fetchData = () => {
            fetchUsers().then(usersData => setUsers(usersData));
        };
        fetchData();
    }, []);

    const handleDelete = (id: number) => {
        deleteUser(id).then(() => {
            fetchUsers().then(usersData => setUsers(usersData));
        });
    };

    const handleEdit = (user: any) => {
        setEditingUser(user);
    };

    const handleUpdate = (id: number, userData: any) => {
        updateUser(id, userData).then(() => {
            fetchUsers().then(usersData => setUsers(usersData));
            setEditingUser(null);
        });
    };

    const handleCreate = (userData: any) => {
        createUser(userData).then(() => {
            fetchUsers().then(usersData => setUsers(usersData));
        });
    };

    return (
        <div>
            <h1>CRUD App with Rich Sync UI</h1>
            <SyncUserForm
                fetchUsers={() => fetchUsers().then(usersData => setUsers(usersData))}
                isEditing={editingUser !== null}
                editId={editingUser?.id || null}
                initialData={editingUser || { name: '', email: '' }}
                handleUpdate={handleUpdate}
                handleCreate={handleCreate}
            />
            <SyncUserList
                users={users}
                fetchUsers={() => fetchUsers().then(usersData => setUsers(usersData))}
                deleteUser={handleDelete}
                updateUser={handleUpdate}
                handleEdit={handleEdit}
            />
        </div>
    );
};

export default SyncApp;
