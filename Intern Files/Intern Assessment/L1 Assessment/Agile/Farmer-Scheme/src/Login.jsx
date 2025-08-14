import React, { useState } from "react";
import { Link } from "react-router-dom";

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!email || !password) {
      setError("Please fill in all fields");
    } else if (!/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/.test(email)) {
      setError("Please enter a valid email address");
    } else if (password.length < 6) {
      setError("Password must be at least 6 characters");
    } else {
      setError(null);
      // submit the form
    }
  };

  const handleForgetPassword = () => {
    alert("Password reset link has been sent to your email address.");
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-5">
          <div className="card">
            <div className="card-body p-4">
              <h1 className="card-title text-center mb-4">Login</h1>
              <form onSubmit={handleSubmit}>
                <div className="form-group mb-3 d-flex align-items-center">
                  <label htmlFor="email" className="form-label me-2">
                    Email
                  </label>
                  <input
                    type="email"
                    className="form-control"
                    id="email"
                    placeholder="Enter email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </div>
                <div className="form-group mb-3 d-flex align-items-center">
                  <label htmlFor="password" className="form-label me-2">
                    Password
                  </label>
                  <input
                    type="password"
                    className="form-control"
                    id="password"
                    placeholder="Enter password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </div>
                {error && (
                  <div className="alert alert-danger mt-3" role="alert">
                    {error}
                  </div>
                )}
                <button type="submit" className="btn btn-primary btn-block mt-3">
                  Login
                </button>
                <p className="mt-4 text-center">
                  <Link to="#" onClick={handleForgetPassword}>
                    Forgot Password?
                  </Link>
                </p>
                <p className="mt-4 text-center">
                  Don't have an account? <Link to="/register">Register</Link>
                </p>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

