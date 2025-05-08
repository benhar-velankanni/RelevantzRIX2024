import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './UserCropView.css';
const UserCropView = () => {
 const [crops, setCrops] = useState([]);
 useEffect(() => {
   const fetchCrops = async () => {
     try {
       const response = await axios.get('http://localhost:8000/crops');
       setCrops(response.data);
     } catch (error) {
       console.error('Error fetching crops:', error);
     }
   };
   fetchCrops();
 }, []);
 return (
<div className="crop-view-container">
     {crops.map((crop) => (
<div key={crop.id} className="crop-view-card">
<img
           src={`/images/${crop.image}`}
           alt={crop.cropName}
           className="crop-view-image"
         />
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
<a
             href={`/documents/${crop.document}`}
             target="_blank"
             rel="noopener noreferrer"
>
             View Document
</a>
         )}
</div>
     ))}
</div>
 );
};
export default UserCropView;