import React, { useState, useEffect } from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";

interface TransactionFormProps {
  fetchTransactions: () => void;
  isEditing: boolean;
  editId: number | null;
  initialData: { description: string; amount: number };
  handleUpdate: (id: number, transactionData: any) => Promise<void>;
  handleCreate: (transactionData: any) => Promise<void>;
}

const TransactionForm: React.FC<TransactionFormProps> = ({
  fetchTransactions,
  isEditing,
  editId,
  initialData = { description: "", amount: 0 },
  handleUpdate,
  handleCreate,
}) => {
  const [description, setDescription] = useState(initialData.description);
  const [amount, setAmount] = useState(initialData.amount);

  useEffect(() => {
    setDescription(initialData.description || "");
    setAmount(initialData.amount || 0);
  }, [initialData]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    if (isEditing && editId !== null) {
      await handleUpdate(editId, { description, amount });
    } else {
      await handleCreate({ description, amount });
    }
    fetchTransactions();
    setDescription("");
    setAmount(0);
  };
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
      <h2>{isEditing ? "Edit Transaction" : "Add Transaction"}</h2>
      <form onSubmit={handleSubmit}>
        <TextField
          label="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
        <TextField
          label="Amount"
          type="number"
          value={amount}
          onChange={(e) => setAmount(Number(e.target.value))}
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

export default TransactionForm;

