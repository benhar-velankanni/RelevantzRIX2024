import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './BiddingPage.css';
const BiddingPage = () => {
 const [crops, setCrops] = useState([]);
 const [selectedCrop, setSelectedCrop] = useState(null);
 const [bidder, setBidder] = useState('');
 const [amount, setAmount] = useState('');
 const [bids, setBids] = useState([]);
 const [editingBid, setEditingBid] = useState(null);
 const [newStatus, setNewStatus] = useState('');
 const [reason, setReason] = useState('');
 useEffect(() => {
   axios.get('http://localhost:8000/crops').then(res => {
     const approved = res.data.filter(crop => crop.status === 'approved');
     setCrops(approved);
   });
 }, []);
 const fetchBids = async () => {
   const res = await axios.get('http://localhost:8000/bids');
   setBids(res.data);
 };
 useEffect(() => {
   fetchBids();
 }, []);
 const handleBidSubmit = async (e) => {
   e.preventDefault();
   const bid = {
     cropId: selectedCrop.id,
     bidder,
     amount,
     status: 'Pending',
     timestamp: new Date().toISOString(),
     notes: ''
   };
   await axios.post('http://localhost:8000/bids', bid);
   setBidder('');
   setAmount('');
   setSelectedCrop(null);
   fetchBids();
 };
 const handleStatusUpdate = async (id) => {
   await axios.patch(`http://localhost:8000/bids/${id}`, {
     status: newStatus,
     notes: reason
   });
   setEditingBid(null);
   fetchBids();
 };
 return (
<div className="bidding-page">
<h2>Approved Crops for Bidding</h2>
<div className="crop-list">
       {crops.map(crop => (
<div key={crop.id} className="crop-card">
<h3>{crop.cropName}</h3>
<p>{crop.cropType} - {crop.variety}</p>
<p>Qty: {crop.quantity} | Price: {crop.price}</p>
<button onClick={() => setSelectedCrop(crop)}>Place Bid</button>
</div>
       ))}
</div>
     {selectedCrop && (
<form className="bid-form" onSubmit={handleBidSubmit}>
<h3>Place Bid for: {selectedCrop.cropName}</h3>
<input type="text" placeholder="Your Name/ID" value={bidder} onChange={e => setBidder(e.target.value)} required />
<input type="number" placeholder="Bid Amount" value={amount} onChange={e => setAmount(e.target.value)} required />
<button type="submit">Submit Bid</button>
</form>
     )}
<h2>Bid Details</h2>
<table className="bid-table">
<thead>
<tr>
<th>Bid ID</th>
<th>Crop ID</th>
<th>Bidder</th>
<th>Amount</th>
<th>Timestamp</th>
<th>Status</th>
<th>Notes</th>
<th>Actions</th>
</tr>
</thead>
<tbody>
         {bids.map(bid => (
<tr key={bid.id}>
<td>{bid.id}</td>
<td>{bid.cropId}</td>
<td>{bid.bidder}</td>
<td>{bid.amount}</td>
<td>{new Date(bid.timestamp).toLocaleString()}</td>
<td>{bid.status}</td>
<td>{bid.notes}</td>
<td>
<button onClick={() => setEditingBid(bid.id)}>Update</button>
</td>
</tr>
         ))}
</tbody>
</table>
     {editingBid && (
<div className="status-update">
<h3>Update Status for Bid ID: {editingBid}</h3>
<select onChange={e => setNewStatus(e.target.value)} defaultValue="">
<option value="">Select Status</option>
<option value="Accepted">Accepted</option>
<option value="Rejected">Rejected</option>
<option value="Withdrawn">Withdrawn</option>
</select>
<textarea placeholder="Reason for change" onChange={e => setReason(e.target.value)} />
<button onClick={() => handleStatusUpdate(editingBid)}>Update Status</button>
</div>
     )}
</div>
 );
};
export default BiddingPage;