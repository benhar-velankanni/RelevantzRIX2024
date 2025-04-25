
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './App.css';

interface Inventory {
  id?: number;
  productName: string;
  quantity: number;
  supplier: string;
  location: string;
  restockThreshold: number;
}

const InventoryForm: React.FC = () => {
  const [inventory, setInventory] = useState<Inventory[]>([]);
  const [formData, setFormData] = useState<Inventory>({
    productName: '',
    quantity: 0,
    supplier: '',
    location: '',
    restockThreshold: 0,
  });
  const [editingId, setEditingId] = useState<number | null>(null);

  useEffect(() => {
    fetchInventory();
  }, []);

  const fetchInventory = () => {
    axios.get('http://localhost:3000/inventory')
      .then(res => setInventory(res.data))
      .catch(err => console.log(err));
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (editingId === null) {
      axios.post('http://localhost:3000/inventory', formData)
        .then(() => {
          fetchInventory();
          setFormData({
            productName: '',
            quantity: 0,
            supplier: '',
            location: '',
            restockThreshold: 0,
          });
        });
    } else {
      axios.put(`http://localhost:3000/inventory/${editingId}`, formData)
        .then(() => {
          fetchInventory();
          setFormData({
            productName: '',
            quantity: 0,
            supplier: '',
            location: '',
            restockThreshold: 0,
          });
          setEditingId(null);
        });
    }
  };

  const handleEdit = (inventory: Inventory) => {
    setFormData({ ...inventory });
    setEditingId(inventory.id ?? null);
  };

  const handleDelete = (id?: number) => {
    if (id !== undefined) {
      axios.delete(`http://localhost:3000/inventory/${id}`)
        .then(() => fetchInventory());
    }
  };

  return (
    <div className="container">
      <h1>Inventory Automation System</h1>
      <form onSubmit={handleSubmit} className="inventory-form">
        <input
          type="text"
          name="productName"
          placeholder="Enter Product Name"
          value={formData.productName}
          onChange={handleChange}
          required
        />
        <input
          type="number"
          name="quantity"
          placeholder="Enter Quantity"
          value={formData.quantity}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="supplier"
          placeholder="Enter Supplier"
          value={formData.supplier}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          name="location"
          placeholder="Enter Location"
          value={formData.location}
          onChange={handleChange}
          required
        />
        <input
          type="number"
          name="restockThreshold"
          placeholder="Enter Restock Threshold"
          value={formData.restockThreshold}
          onChange={handleChange}
          required
        />
        <button type="submit">{editingId ? 'Update' : 'Submit'}</button>
      </form>
      <table>
        <thead>
          <tr>
            <th>No</th>
            <th>Product Name</th>
            <th>Quantity</th>
            <th>Supplier</th>
            <th>Location</th>
            <th>Restock Threshold</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {inventory.map((inventory, index) => (
            <tr key={inventory.id}>
              <td>{index + 1}</td>
              <td>{inventory.productName}</td>
              <td>{inventory.quantity}</td>
              <td>{inventory.supplier}</td>
              <td>{inventory.location}</td>
              <td>{inventory.restockThreshold}</td>
              <td>
                <button className="edit" onClick={() => handleEdit(inventory)}>Edit</button>
                <button className="delete" onClick={() => handleDelete(inventory.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default InventoryForm;

