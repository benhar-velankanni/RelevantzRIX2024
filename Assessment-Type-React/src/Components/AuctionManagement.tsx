import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface AuctionItem {
  id: string;
  Name: string;
  Category: string;
  StartingBid: number;
  HighestBidder: string;
}

const AuctionManagement: React.FC = () => {
  const [items, setItems] = useState<AuctionItem[]>([]);
  const [formData, setFormData] = useState<AuctionItem>({
    id: '',
    Name: '',
    Category: '',
    StartingBid: 0,
    HighestBidder: '',
  });
  const [editingId, setEditingId] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchedItem, setSearchedItem] = useState<AuctionItem | null>(null);
  const [errors, setErrors] = useState<{ [key: string]: string }>({});

  useEffect(() => {
    fetchItems();
  }, []);

  const fetchItems = () => {
    axios.get('http://localhost:3000/item')
      .then(res => setItems(res.data))
      .catch(err => console.log(err));
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
    setErrors({ ...errors, [name]: '' });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const { id, Name, Category, StartingBid, HighestBidder } = formData;
    const newErrors: { [key: string]: string } = {};
    if (!id) newErrors.id = 'Item ID is required';
    if (!Name) newErrors.Name = 'Item Name is required';
    if (!Category) newErrors.Category = 'Item Category is required';
    if (StartingBid <= 0) newErrors.StartingBid = 'Item Starting Bid must be greater than 0';
    if (!HighestBidder) newErrors.HighestBidder = 'Highest Bidder is required';

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      return;
    }

    if (editingId === null) {
      axios.post('http://localhost:3000/item', formData)
        .then(() => {
          fetchItems();
          setFormData({
            id: '',
            Name: '',
            Category: '',
            StartingBid: 0,
            HighestBidder: '',
          });
        });
    } else {
      axios.put(`http://localhost:3000/item/${editingId}`, formData)
        .then(() => {
          fetchItems();
          setFormData({
            id: '',
            Name: '',
            Category: '',
            StartingBid: 0,
            HighestBidder: '',
          });
          setEditingId(null);
        });
    }
  };

  const handleEdit = (item: AuctionItem) => {
    setFormData({
      id: item.id,
      Name: item.Name,
      Category: item.Category,
      StartingBid: item.StartingBid,
      HighestBidder: item.HighestBidder,
    });
    setEditingId(item.id);
  };

  const handleDelete = (id?: string) => {
    if (id !== undefined) {
      axios.delete(`http://localhost:3000/item/${id}`)
        .then(() => fetchItems());
    }
  };

  const handleSearch = () => {
    const item = items.find(i => i.id === searchTerm);
    setSearchedItem(item ?? null);
  };

  return (
    <div className="container mt-5">
      <h1 className="display-4 text-center mb-4">Auction Management</h1>
      <form onSubmit={handleSubmit} className="form mb-4">
        <div className="row">
          <div className="col-md-6 mb-3">
            <label>Item ID:</label>
            <input
              type="text"
              name="id"
              placeholder="Enter Item ID"
              value={formData.id}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.id && <div className="text-danger">{errors.id}</div>}
          </div>
          <div className="col-md-6 mb-3">
            <label>Item Name:</label>
            <input
              type="text"
              name="Name"
              placeholder="Enter Item Name"
              value={formData.Name}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.Name && <div className="text-danger">{errors.Name}</div>}
          </div>
        </div>
        <div className="row">
          <div className="col-md-6 mb-3">
            <label>Item Category:</label>
            <input
              type="text"
              name="Category"
              placeholder="Enter Item Category"
              value={formData.Category}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.Category && <div className="text-danger">{errors.Category}</div>}
          </div>
          <div className="col-md-6 mb-3">
            <label>Item Starting Bid:</label>
            <input
              type="number"
              name="StartingBid"
              placeholder="Enter Item Starting Bid"
              value={formData.StartingBid}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.StartingBid && <div className="text-danger">{errors.StartingBid}</div>}
          </div>
        </div>
        <div className="mb-3">
          <label>Highest Bidder:</label>
          <input
            type="text"
            name="HighestBidder"
            placeholder="Enter Highest Bidder"
            value={formData.HighestBidder}
            onChange={handleChange}
            required
            className="form-control"
          />
          {errors.HighestBidder && <div className="text-danger">{errors.HighestBidder}</div>}
        </div>
        <button type="submit" className="btn btn-primary btn-block">{editingId ? 'Update' : 'Submit'}</button>
      </form>
      <div className="input-group mb-4">
        <input
          type="text"
          placeholder="Search by ID"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="form-control"
        />
        <div className="input-group-append">
          <button className="btn btn-secondary" onClick={handleSearch}>Search</button>
        </div>
      </div>
      <table className="table table-striped table-responsive-md">
        <thead className="thead-dark">
          <tr>
            <th>Item ID</th>
            <th>Name</th>
            <th>Category</th>
            <th>Starting Bid</th>
            <th>Highest Bidder</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedItem ? (
            <tr key={searchedItem.id}>
              <td>{searchedItem.id}</td>
              <td>{searchedItem.Name}</td>
              <td>{searchedItem.Category}</td>
              <td>{searchedItem.StartingBid}</td>
              <td>{searchedItem.HighestBidder}</td>
              <td>
                <button className="btn btn-primary mr-2" onClick={() => handleEdit(searchedItem)}>Edit</button>
                <button className="btn btn-danger" onClick={() => handleDelete(searchedItem.id)}>Delete</button>
              </td>
            </tr>
          ) : items.length === 0 ? (
            <tr>
              <td colSpan={6} className="text-center text-danger">
                <strong>No records found</strong>
              </td>
            </tr>
          ) : (
            items.map((item) => (
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.Name}</td>
                <td>{item.Category}</td>
                <td>{item.StartingBid}</td>
                <td>{item.HighestBidder}</td>
                <td>
                  <button className="btn btn-primary mr-2" onClick={() => handleEdit(item)}>Edit</button>
                  <button className="btn btn-danger" onClick={() => handleDelete(item.id)}>Delete</button>
                </td>
              </tr>
            ))
          )}
        </tbody>
      </table>
    </div>
  );
};

export default AuctionManagement;

