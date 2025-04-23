import React from "react";
import { useState, useEffect } from "react";
import "./UserForm.css";

interface UserFormProps {
  fetchUsers: () => void;
  isEditing: boolean;
  editId: number | null;
  initialData: { name: string; age: number };
  name: string;
  age: number;
  handleUpdate: (id: number, userData: any) => Promise<void>;
  handleCreate: (userData: any) => Promise<void>;
}

const UserForm: React.FC<UserFormProps> = ({
  fetchUsers,
  isEditing,
  editId,
  initialData = { name: "", age: 0 },
  handleUpdate,
  handleCreate,
}) => {
  const [name, setName] = useState(initialData.name);
  const [age, setAge] = useState(initialData.age);

  useEffect(() => {
    setName(initialData.name || "");
    setAge(initialData.age || 0);
  }, [initialData]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (isEditing && editId !== null) {
      await handleUpdate(editId, { name, age });
    } else {
      await handleCreate({ name, age });
    }
    fetchUsers();
    setName("");
    setAge(0);
  };

  return (
    <div>
      <h2>{isEditing ? "Edit User" : "Add User"}</h2>
      <form
        onSubmit={handleSubmit}
        style={{ display: "flex", flexDirection: "column" }}
      >
        <table>
          <tr>
            <td>
              <label>Name:</label>
            </td>
            <td>
              <input
                type="text"
                value={name}
                onChange={(e) => setName(e.target.value)}
              />
            </td>
          </tr>
          <tr>
            <td>
              <label>Age:</label>
            </td>
            <td>
              <input
                type="number"
                value={age}
                onChange={(e) => setAge(parseInt(e.target.value))}
              />
            </td>
          </tr>
        </table>
        <br />
        <button className="submit-button" type="submit">
          {isEditing ? "Update" : "Add"}
        </button>
      </form>
    </div>
  );
};

export default UserForm;
