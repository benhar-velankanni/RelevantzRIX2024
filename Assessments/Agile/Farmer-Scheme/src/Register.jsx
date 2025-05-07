import React, { useState } from "react";
import { Link } from "react-router-dom";

export default function Register() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [age, setAge] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [error, setError] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name || !email || !password || !age || !phoneNumber) {
      setError("Please fill in all fields");
    } else if (password.length < 6) {
      setError("Password must be at least 6 characters");
    } else if (isNaN(age) || age < 18) {
      setError("Age must be a number and at least 18 years old");
    } else if (phoneNumber.length !== 10) {
      setError("Phone number must be 10 digits");
    } else {
      setError(null);
      // submit the form
    }
  };

  return (
    <div className="d-flex justify-content-center align-items-center h-100">
      <div className="card w-50">
        <div className="card-body">
          <h1 className="card-title text-center">Register</h1>
          <form onSubmit={handleSubmit}>
            <div className="mb-3 d-flex align-items-center">
              <label htmlFor="name" className="form-label me-2">
                Name
              </label>
              <input
                type="text"
                className="form-control"
                id="name"
                placeholder="John Doe"
                value={name}
                onChange={(e) => setName(e.target.value)}
              />
            </div>
            <div className="mb-3 d-flex align-items-center">
              <label htmlFor="email" className="form-label me-2">
                Email
              </label>
              <input
                type="email"
                className="form-control"
                id="email"
                placeholder="john@example.com"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <div className="mb-3 d-flex align-items-center">
              <label htmlFor="password" className="form-label me-2">
                Password
              </label>
              <input
                type="password"
                className="form-control"
                id="password"
                placeholder="******"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
              />
            </div>
            <div className="mb-3 d-flex align-items-center">
              <label htmlFor="age" className="form-label me-2">
                Age
              </label>
              <input
                type="number"
                className="form-control"
                id="age"
                placeholder="18"
                value={age}
                onChange={(e) => setAge(e.target.value)}
              />
            </div>
            <div className="mb-3 d-flex align-items-center">
              <label htmlFor="phoneNumber" className="form-label me-2">
                Contact
              </label>
              <input
                type="tel"
                className="form-control"
                id="phoneNumber"
                placeholder="(123) 456-7890"
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)}
              />
            </div>
            {error && <div className="alert alert-danger">{error}</div>}
            <button type="submit" className="btn btn-primary w-100">
              Register
            </button>
          </form>
          <p className="mt-3 text-center">
            Already have an account? <Link to="/login">Log in</Link>
          </p>
        </div>
      </div>
    </div>
  );
}


