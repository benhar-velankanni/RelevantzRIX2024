import React, { useState } from "react";
import axios from "axios";

const ClaimInsurance = () => {
  const [form, setForm] = useState({
    policyNumber: "",
    scheme: "",
    cause: "",
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
    setErrors((prevErrors) => ({
      ...prevErrors,
      [e.target.name]: e.target.value ? "" : "This field is required",
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const newErrors = {};
    for (const key in form) {
      if (!form[key]) {
        newErrors[key] = "This field is required";
      }
    }
    setErrors(newErrors);
    if (Object.keys(newErrors).length) return;

    axios
      .post("http://localhost:3000/claimData", form)
      .then((res) => {
        alert(
          "Claim submitted! wainting for the admin to confirm the claim status."
        );
      })
      .catch((err) => {
        console.log(err);
      });
  };

  return (
    <div
      style={{ textAlign: "center", marginTop: "60px", fontFamily: "Segoe UI" }}
    >
      <h2 style={{ color: "#007bff", marginBottom: "30px" }}>
        Claim Insurance
      </h2>
      <form onSubmit={handleSubmit}>
        {["policyNumber", "scheme", "cause"].map((field) => (
          <div key={field}>
            <input
              name={field}
              placeholder={field}
              onChange={handleChange}
              style={{
                ...inputStyle,
                borderColor: errors[field] ? "red" : "",
              }}
            />
            <div style={{ color: "red" }}>{errors[field]}</div>
            <br />
          </div>
        ))}
        <button type="submit" style={buttonStyle}>
          Submit
        </button>
      </form>
    </div>
  );
};

const inputStyle = {
  width: "300px",
  padding: "10px",
  marginBottom: "15px",
  borderRadius: "5px",
  border: "1px solid #ccc",
  fontSize: "1rem",
};

const buttonStyle = {
  background: "linear-gradient(to right, #007bff, #00c6ff)",
  color: "white",
  border: "none",
  borderRadius: "8px",
  padding: "12px 25px",
  cursor: "pointer",
  fontWeight: "bold",
  fontSize: "1rem",
  boxShadow: "0 4px 12px rgba(0, 123, 255, 0.3)",
  transition: "transform 0.2s ease",
};

export default ClaimInsurance;
