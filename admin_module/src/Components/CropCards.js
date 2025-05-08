import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './CropCards.css';
const CropCards = () => {
 const [crops, setCrops] = useState([]);
 const fetchCrops = async () => {
   try {
     const response = await axios.get('http://localhost:8000/crops');
     setCrops(response.data);
   } catch (error) {
     console.error('Error fetching crops:', error);
   }
 };
 useEffect(() => {
   fetchCrops();
 }, []);
 const updateStatus = async (id, newStatus) => {
   try {
     await axios.patch(`http://localhost:8000/crops/${id}`, {
       status: newStatus,
     });
     fetchCrops();
   } catch (error) {
     console.error('Error updating status:', error);
   }
 };
 return (
<div className="crop-cards-container">
     {crops.map((crop) => (
<div key={crop.id} className="crop-card">
<img src={`/images/${crop.image}`} alt={crop.cropName} className="crop-image" />
<h3>{crop.cropName}</h3>
<p><strong>Type:</strong> {crop.cropType}</p>
<p><strong>Variety:</strong> {crop.variety}</p>
<p><strong>Quantity:</strong> {crop.quantity}</p>
<p><strong>Price per Unit:</strong> {crop.price}</p>
<p><strong>Harvest Date:</strong> {crop.harvestDate}</p>
<p><strong>Sowing Date:</strong> {crop.sowingDate}</p>
<p><strong>Shelf Life:</strong> {crop.shelfLife}</p>
<p><strong>Status:</strong> {crop.status || 'Pending'}</p>
         {crop.document && (
<a href={`/documents/${crop.document}`} target="_blank" rel="noopener noreferrer">
             View Document
</a>
         )}
         {crop.status !== 'Approved' && crop.status !== 'Rejected' && (
<div className="action-buttons">
<button className="approve-btn" onClick={() => updateStatus(crop.id, 'Approved')}>
               Approve
</button>
<button className="reject-btn" onClick={() => updateStatus(crop.id, 'Rejected')}>
               Reject
</button>
</div>
         )}
</div>
     ))}
</div>
 );
};
export default CropCards;