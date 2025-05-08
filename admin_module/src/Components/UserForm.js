import React, { useState } from 'react';
import axios from 'axios';
import './UserForm.css';
const UserForm = () => {
 const [formData, setFormData] = useState({
   cropName: '',
   cropType: '',
   variety: '',
   quantity: '',
   price: '',
   harvestDate: '',
   sowingDate: '',
   shelfLife: '',
   image: '',
   document: '',
   status: 'pending'
 });
 const handleChange = (e) => {
   const { name, value } = e.target;
   setFormData({ ...formData, [name]: value });
 };
 const handleImageUpload = (e) => {
   const file = e.target.files[0];
   const fileName = file.name;
   // In a real application, you'd upload the file to the server here
   setFormData({ ...formData, image: fileName });
 };
 const handleDocumentUpload = (e) => {
   const file = e.target.files[0];
   const fileName = file.name;
   // In a real application, you'd upload the file to the server here
   setFormData({ ...formData, document: fileName });
 };
 const handleSubmit = async (e) => {
   e.preventDefault();
   try {
     await axios.post('http://localhost:8000/crops', formData);
     alert('Crop details submitted successfully!');
     setFormData({
       cropName: '',
       cropType: '',
       variety: '',
       quantity: '',
       price: '',
       harvestDate: '',
       sowingDate: '',
       shelfLife: '',
       image: '',
       document: '',
       status: 'pending'
     });
   } catch (error) {
     console.error('Error submitting crop details:', error);
   }
 };
 const today = new Date();
 const maxSowingDate = new Date(today.getFullYear(), today.getMonth(), today.getDate());
 return (
<div className="user-form-container">
<h2>Submit Crop Details</h2>
<form onSubmit={handleSubmit} className="user-form">
<label>
         Crop Name:
<input type="text" name="cropName" value={formData.cropName} onChange={handleChange} required />
</label>
<label>
         Crop Type/Category:
<input type="text" name="cropType" value={formData.cropType} onChange={handleChange} required />
</label>
<label>
         Variety:
<input type="text" name="variety" value={formData.variety} onChange={handleChange} required />
</label>
<label>
         Quantity Available:
<input type="text" name="quantity" value={formData.quantity} onChange={handleChange} required />
</label>
<label>
         Expected Price per Unit:
<input type="text" name="price" value={formData.price} onChange={handleChange} />
</label>
<label>
         Harvest Date:
<input type="date" name="harvestDate" value={formData.harvestDate} onChange={handleChange} required />
</label>
<label>
         Sowing Date:
<input type="date" name="sowingDate" value={formData.sowingDate} onChange={handleChange} max={maxSowingDate.toISOString().split('T')[0]} />
</label>
<label>
         Estimated Shelf Life:
<input type="text" name="shelfLife" value={formData.shelfLife} onChange={handleChange} />
</label>
<label>
         Upload Crop Images:
<input type="file" accept="image/*" onChange={handleImageUpload} />
</label>
<label>
         Upload Supporting Documents:
<input type="file" accept=".pdf,.doc,.docx" onChange={handleDocumentUpload} />
</label>
<button type="submit">Submit</button>
</form>
</div>
 );
};
export default UserForm;
