import React from "react";
import Button from '@mui/material/Button';

interface UserListProps {
    users: any[];
    fetchUsers: () => void;
    deleteUser: (id: number) => void;
    updateUser: (id: number, userData: any) => void;
    handleEdit: (user: any) => void;
}

const SyncUserList: React.FC<UserListProps> = ({ users, fetchUsers, deleteUser, updateUser, handleEdit }) => {
    const handleDelete = (id: number) => {
        deleteUser(id);
        fetchUsers();
        
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
                                <Button variant="contained" color="secondary" onClick={() => handleDelete(user.id)}>Delete</Button>
                                <Button variant="contained" color="primary" onClick={() => handleEdit(user)}>Edit</Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default SyncUserList;
