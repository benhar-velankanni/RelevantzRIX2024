import React, { useState, useEffect } from "react";
import axios from "axios";

const ExpensePage = () => {
  const [expenses, setExpenses] = useState([]);
  const [search, setSearch] = useState("");
  const [editingExpense, setEditingExpense] = useState(null);

  const fetchexpenses = async () => {
    const response = await axios.get("http://localhost:5001/api/expenses");
    setExpenses(response.data);
  };

  useEffect(() => {
    document.title = "Dash - Expense Manager";

    fetchexpenses();
  }, [expenses]);

  const handleAddOrUpdateExpense = async (e) => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const expenseData = Object.fromEntries(formData.entries());

    if (editingExpense) {
      const response = await axios.put(
        `http://localhost:5001/api/expenses/${editingExpense.id}`,
        expenseData
      );
      setExpenses(
        expenses.map((e) => (e.id === editingExpense.id ? response.data : e))
      );
      setEditingExpense(null);
    } else {
      if (expenseData.description == null || expenseData.description === "") {
        expenseData.description = "No Description.";
      }

      const response = await axios.post(
        "http://localhost:5001/api/expenses",
        expenseData
      );
      setExpenses([...expenses, response.data]);
    }

    e.target.reset();
  };

  const handleEdit = (expense) => {
    setEditingExpense(expense);
  };

  const handleDelete = async (id) => {
    await axios.delete(`http://localhost:5001/api/expenses/${id}`);
    setExpenses(expenses.filter((e) => e.id !== id));
  };

  const filteredexpenses = expenses.filter(
    (e) =>
      e.name?.toLowerCase().includes(search.toLowerCase()) ||
      e.type?.toLowerCase().includes(search.toLowerCase()) ||
      e.description?.toLowerCase().includes(search.toLowerCase())  
  );

  return (
    <>
      <div class="container wrapper">
        <h1 style={{ marginBottom: "3rem" }}>Expense Manager Dashboard</h1>
        <form
          onSubmit={handleAddOrUpdateExpense}
          style={{ marginBottom: "3rem" }}
        >
          <div class="mb-3">
            <label for="name" class="form-label">
              Enter the name of the expense:
            </label>
            <input
              name="name"
              placeholder="Name"
              defaultValue={editingExpense?.name || ""}
              required
              class="form-control"
            />
          </div>
          <div class="mb-3">
            <label for="type" class="form-label">
              Enter the type of the expense:
            </label>
            <input
              name="type"
              placeholder="Type"
              defaultValue={editingExpense?.type || ""}
              required
              class="form-control"
            />
          </div>
          <div class="mb-3">
            <label for="description" class="form-label">
              Enter the description of the expense:
            </label>
            <input
              name="description"
              placeholder="Description"
              defaultValue={editingExpense?.description || ""}
              class="form-control"
            />
          </div>
          <div class="mb-3">
            <label for="price" class="form-label">
              Enter the amount of the expense:
            </label>
            <input
              name="price"
              placeholder="Amount"
              defaultValue={editingExpense?.price || ""}
              required
              class="form-control"
            />
          </div>
          <button type="submit" class="btn btn-primary">
            {editingExpense ? "Update" : "Add"} Expense
          </button>
          {editingExpense && (
            <button
              type="button"
              class="btn btn-danger"
              onClick={() => setEditingExpense(null)}
            >
              Cancel
            </button>
          )}
        </form>

        {/* Expense List */}
        <h2 style={{ marginBottom: "3rem" }}>Expense List</h2>
        {/* Search */}
        <div class="mb-3" style={{ marginBottom: "3rem" }}>
          <label for="search" class="form-label">
            Search by Expense name or type or description:
          </label>
          <input
            type="text"
            placeholder="Search..."
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            class="form-control"
          />
        </div>
        <table class="table table-hover">
          <thead>
            <tr>
              <th scope="col">Name</th>
              <th scope="col">Type</th>
              <th scope="col">Description</th>
              <th scope="col">Amount</th>
              <th scope="col">Edit?</th>
              <th scope="col">Delete?</th>
            </tr>
          </thead>
          <tbody>
            {filteredexpenses.map((e) => (
              <tr key={e.id}>
                <td>{e.name}</td>
                <td>{e.type}</td>
                <td>{e.description}</td>
                <td>Rs.{e.price}</td>
                <td>
                  <button onClick={() => handleEdit(e)} class="btn btn-primary">
                    Edit
                  </button>
                </td>
                <td>
                  <button
                    onClick={() => handleDelete(e.id)}
                    class="btn btn-danger"
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </>
  );
};

export default ExpensePage;
