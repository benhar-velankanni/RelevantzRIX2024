import React, { useState } from 'react';
import './App.css';

const App = () => {
  const [products, setProducts] = useState([]);
  const [bids, setBids] = useState({});
  const [approvedBids, setApprovedBids] = useState({});
  const [searchTerm, setSearchTerm] = useState('');

  const addProduct = (product) => {
    setProducts([...products, product]);
  };

  const removeProduct = (productId) => {
    setProducts(products.filter(product => product.id !== productId));
  };

  const placeBid = (productId, bidderName, bidAmount, contactNumber) => {
    setBids({
      ...bids,
      [productId]: [...(bids[productId] || []), { bidderName, bidAmount, contactNumber }]
    });
  };

  const approveBid = (productId, bidderName) => {
    const product = products.find(p => p.id === productId);
    setApprovedBids({
      ...approvedBids,
      [productId]: { ...product, approvedBidder: bidderName }
    });
    removeProduct(productId);
    alert(`Approved Bidder: ${bidderName} for Product: ${product.name}`);
  };

  const clearEndedAuctions = () => {
    setApprovedBids({});
  };

  const updateProduct = (productId, updatedProduct) => {
    setProducts(
      products.map(product =>
        product.id === productId ? { ...product, ...updatedProduct } : product
      )
    );
  };

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
  };

  const filteredProducts = products.filter(product =>
    product.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="app">
      <header className="header">
        <h1>Farming Auction Platform</h1>
      </header>
      <main className="main">
        <section className="seller-section">
          <Seller addProduct={addProduct} />
        </section>
        <section className="product-list-section">
          <div className="search-bar">
            <input
              type="search"
              value={searchTerm}
              onChange={handleSearch}
              placeholder="Search products by name"
            />
          </div>
          <ProductList products={filteredProducts} removeProduct={removeProduct} />
        </section>
        <section className="bidder-section">
          <Bidder products={products} placeBid={placeBid} />
        </section>
        <section className="admin-section">
          <Admin
            products={products}
            bids={bids}
            approveBid={approveBid}
            updateProduct={updateProduct}
          />
        </section>
        <section className="ended-auctions-section">
          <EndedAuctions approvedBids={approvedBids} clearEndedAuctions={clearEndedAuctions} />
        </section>
      </main>
    </div>
  );
};

const Seller = ({ addProduct }) => {
  const [productDetails, setProductDetails] = useState({ name: '', basePrice: '', quantity: '', image: null });

  const handleSubmit = (e) => {
    e.preventDefault();
    const newProduct = {
      id: Date.now(),
      name: productDetails.name,
      basePrice: parseFloat(productDetails.basePrice),
      quantity: parseInt(productDetails.quantity, 10) || 0,
      image: URL.createObjectURL(productDetails.image)
    };
    addProduct(newProduct);
    setProductDetails({ name: '', basePrice: '', quantity: '', image: null });
  };

  return (
    <div className="seller">
      <h2>Post a Product</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Product Name:
          <input
            type="text"
            value={productDetails.name}
            onChange={(e) => setProductDetails({ ...productDetails, name: e.target.value })}
            placeholder="Enter product name"
          />
        </label>
        <label>
          Base Price:
          <input
            type="number"
            value={productDetails.basePrice}
            onChange={(e) => setProductDetails({ ...productDetails, basePrice: e.target.value })}
            placeholder="Enter base price"
          />
        </label>
        <label>
          Quantity(Kg):
          <input
            type="number"
            value={productDetails.quantity}
            onChange={(e) => setProductDetails({ ...productDetails, quantity: e.target.value })}
            placeholder="Enter quantity"
          />
        </label>
        <label>
          Product Image:
          <input
            type="file"
            onChange={(e) => setProductDetails({ ...productDetails, image: e.target.files[0] })}
          />
        </label>
        <button type="submit">Add Product</button>
      </form>
    </div>
  );
};

const ProductList = ({ products, removeProduct }) => {
  return (
    <div className="product-list">
      <h2>Available Products</h2>
      <ul>
        {products.map((product) => (
          <li key={product.id}>
            <img src={product.image} alt={product.name} width="100" />
            <span>{product.name} (Base Price: {product.basePrice}, Quantity: {product.quantity} Kg)</span>
            <button onClick={() => removeProduct(product.id)}>Remove</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

const Bidder = ({ products, placeBid }) => {
  const [bidDetails, setBidDetails] = useState({ productId: '', bidderName: '', bidAmount: '', contactNumber: '' });

  const handleSubmit = (e) => {
    e.preventDefault();
    placeBid(bidDetails.productId, bidDetails.bidderName, parseFloat(bidDetails.bidAmount), bidDetails.contactNumber);
    setBidDetails({ productId: '', bidderName: '', bidAmount: '', contactNumber: '' });
  };

  return (
    <div className="bidder">
      <h2>Place a Bid</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Select Product:
          <select
            value={bidDetails.productId}
            onChange={(e) => setBidDetails({ ...bidDetails, productId: e.target.value })}
          >
            <option value="">Select Product</option>
            {products.map((product) => (
              <option key={product.id} value={product.id}>
                {product.name} (Base Price: {product.basePrice})
              </option>
            ))}
          </select>
        </label>
        <label>
          Your Name:
          <input
            type="text"
            value={bidDetails.bidderName}
            onChange={(e) => setBidDetails({ ...bidDetails, bidderName: e.target.value })}
            placeholder="Enter your name"
          />
        </label>
        <label>
          Bid Amount:
          <input
            type="number"
            value={bidDetails.bidAmount}
            onChange={(e) => setBidDetails({ ...bidDetails, bidAmount: e.target.value })}
            placeholder="Enter bid amount"
          />
        </label>
        <label>
          Contact Number:
          <input
            type="text"
            value={bidDetails.contactNumber}
            onChange={(e) => setBidDetails({ ...bidDetails, contactNumber: e.target.value })}
            placeholder="Enter your contact number"
          />
        </label>
        <button type="submit">Place Bid</button>
      </form>
    </div>
  );
};

const Admin = ({ products, bids, approveBid, updateProduct }) => {
  return (
    <div className="admin">
      <h2>Admin Panel</h2>
      {products.map((product) => (
        <div key={product.id} className="admin-product">
          <h3>
            {product.name}
            <button
              onClick={() => {
                const newName = prompt('Enter new name');
                const newBasePrice = parseFloat(prompt('Enter new base price'));
                const newQuantity = parseInt(prompt('Enter new quantity'), 10) || 0;
                updateProduct(product.id, { name: newName, basePrice: newBasePrice, quantity: newQuantity });
              }}
            >
              Update
            </button>
          </h3>
          <ul>
            {bids[product.id] &&
              bids[product.id].map((bid, index) => (
                <li key={index}>
                  {bid.bidderName}: {bid.bidAmount}, Contact: {bid.contactNumber}
                  <button onClick={() => approveBid(product.id, bid.bidderName)}>Approve</button>
                </li>
              ))}
          </ul>
        </div>
      ))}
    </div>
  );
};

const EndedAuctions = ({ approvedBids, clearEndedAuctions }) => {
  return (
    <div className="ended-auctions">
      <h2>Ended Auctions</h2>
      <button onClick={clearEndedAuctions}>Clear All</button>
      <ul>
        {Object.values(approvedBids).map((product) => (
          <li key={product.id}>
            <img src={product.image} alt={product.name} width="100" />
            <span>{product.name} (Approved Bidder: {product.approvedBidder} - ₹{product.basePrice} - Quantity: {product.quantity})</span>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default App;

