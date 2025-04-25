import React, { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";

interface UserFormProps {
  fetchUsers: () => void;
  isEditing: boolean;
  editId: number | null;
  initialData: { name: string; email: string };
  handleUpdate: (id: number, userData: any) => Promise<void>;
  handleCreate: (userData: any) => Promise<void>;
}

const UserForm: React.FC<UserFormProps> = ({
  fetchUsers,
  isEditing,
  editId,
  initialData = { name: "", email: "" },
  handleUpdate,
  handleCreate,
}) => {
  const [name, setName] = useState(initialData.name);
  const [email, setEmail] = useState(initialData.email);

  useEffect(() => {
    setName(initialData.name || "");
    setEmail(initialData.email || "");
  }, [initialData]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (isEditing && editId !== null) {
      await handleUpdate(editId, { name, email });
    } else {
      await handleCreate({ name, email });
    }
    fetchUsers();
    setName("");
    setEmail("");
  };

  return (
    <div>
      <h2>{isEditing ? "Edit User" : "Add User"}</h2>
      <form onSubmit={handleSubmit}>
        <TextField
          label="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
        <TextField
          label="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <Button
          type="submit"
          variant="contained"
          color="primary"
          sx={{ margin: 2, padding: 1 }}
        >
          {isEditing ? "Update" : "Add"}
        </Button>
      </form>
    </div>
  );
};

export default UserForm;
