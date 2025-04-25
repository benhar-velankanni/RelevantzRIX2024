import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface Bid {
  id: string;
  ItemId: string;
  Bidder: string;
  Amount: number;
}

const BidManagement: React.FC = () => {
  const [bids, setBids] = useState<Bid[]>([]);
  const [formData, setFormData] = useState<Bid>({
    id: '',
    ItemId: '',
    Bidder: '',
    Amount: 0,
  });
  const [errors, setErrors] = useState<{ [key: string]: string }>({});
  const [editingId, setEditingId] = useState<string | null>(null);
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [searchedBid, setSearchedBid] = useState<Bid | null>(null);

  useEffect(() => {
    fetchBids();
  }, []);

  const fetchBids = () => {
    axios.get('http://localhost:3000/bid')
      .then(res => setBids(res.data))
      .catch(err => console.log(err));
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
    setErrors({ ...errors, [e.target.name]: '' });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const { id, ItemId, Bidder, Amount } = formData;
    const newErrors: { [key: string]: string } = {};
    if (!id) newErrors.id = 'Bid ID is required';
    if (!ItemId) newErrors.ItemId = 'Item ID is required';
    if (!Bidder) newErrors.Bidder = 'Bidder is required';
    if (Amount <= 0) newErrors.Amount = 'Amount must be greater than 0';

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      return;
    }

    if (editingId === null) {
      axios.post('http://localhost:3000/bid', formData)
        .then(() => {
          fetchBids();
          setFormData({
            id: '',
            ItemId: '',
            Bidder: '',
            Amount: 0,
          });
        });
    } else {
      axios.put(`http://localhost:3000/bid/${editingId}`, formData)
        .then(() => {
          fetchBids();
          setFormData({
            id: '',
            ItemId: '',
            Bidder: '',
            Amount: 0,
          });
          setEditingId(null);
        });
    }
  };

  const handleEdit = (bid: Bid) => {
    setFormData({
      id: bid.id,
      ItemId: bid.ItemId,
      Bidder: bid.Bidder,
      Amount: bid.Amount,
    });
    setEditingId(bid.id);
  };

  const handleDelete = (id?: string) => {
    if (id !== undefined) {
      axios.delete(`http://localhost:3000/bid/${id}`)
        .then(() => fetchBids());
    }
  };

  const handleSearch = () => {
    const bid = bids.find(b => b.id === searchTerm);
    setSearchedBid(bid ?? null);
  };

  return (
    <div className="container mt-4">
      <h1 className="mb-4 text-center">Bid Management</h1>
      <form onSubmit={handleSubmit} className="mb-4">
        <div className="row g-3">
          <div className="col-md-6">
            <label className="form-label">Bid ID:</label>
            <input
              type="text"
              name="id"
              placeholder="Enter Bid ID"
              value={formData.id}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.id && <div className="text-danger">{errors.id}</div>}
          </div>
          <div className="col-md-6">
            <label className="form-label">Item ID:</label>
            <input
              type="text"
              name="ItemId"
              placeholder="Enter Item ID"
              value={formData.ItemId}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.ItemId && <div className="text-danger">{errors.ItemId}</div>}
          </div>
          <div className="col-md-6">
            <label className="form-label">Bidder:</label>
            <input
              type="text"
              name="Bidder"
              placeholder="Enter Bidder"
              value={formData.Bidder}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.Bidder && <div className="text-danger">{errors.Bidder}</div>}
          </div>
          <div className="col-md-6">
            <label className="form-label">Amount:</label>
            <input
              type="number"
              name="Amount"
              placeholder="Enter Amount"
              value={formData.Amount}
              onChange={handleChange}
              required
              className="form-control"
            />
            {errors.Amount && <div className="text-danger">{errors.Amount}</div>}
          </div>
        </div>
        <button type="submit" className="btn btn-primary mt-3">{editingId ? 'Update' : 'Submit'}</button>
      </form>
      <div className="input-group mb-4">
        <input
          type="text"
          placeholder="Search by ID"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="form-control"
        />
        <button className="btn btn-secondary" onClick={handleSearch}>Search</button>
      </div>
      <table className="table table-striped table-responsive-md">
        <thead className="table-dark">
          <tr>
            <th>Bid ID</th>
            <th>Item ID</th>
            <th>Bidder</th>
            <th>Amount</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {searchedBid ? (
            <tr key={searchedBid.id}>
              <td>{searchedBid.id}</td>
              <td>{searchedBid.ItemId}</td>
              <td>{searchedBid.Bidder}</td>
              <td>{searchedBid.Amount}</td>
              <td>
                <button className="btn btn-primary me-2" onClick={() => handleEdit(searchedBid)}>Edit</button>
                <button className="btn btn-danger" onClick={() => handleDelete(searchedBid.id)}>Delete</button>
              </td>
            </tr>
          ) : (
            bids.length === 0 ? (
              <tr>
                <td colSpan={5} className="text-center text-danger"><strong>No records found</strong></td>
              </tr>
            ) : (
              bids.map((bid) => (
                <tr key={bid.id}>
                  <td>{bid.id}</td>
                  <td>{bid.ItemId}</td>
                  <td>{bid.Bidder}</td>
                  <td>{bid.Amount}</td>
                  <td>
                    <button className="btn btn-primary me-2" onClick={() => handleEdit(bid)}>Edit</button>
                    <button className="btn btn-danger" onClick={() => handleDelete(bid.id)}>Delete</button>
                  </td>
                </tr>
              ))
            )
          )}
        </tbody>
      </table>
    </div>
  );
};

export default BidManagement;

