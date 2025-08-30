import React, { useState } from "react";
import axios from "axios";

const ApplyInsurance = () => {
  const [form, setForm] = useState({
    name: "",
    cropType: "",
    season: "",
    area: "",
    bankDetails: "",
    amount: "",
  });
  const [submittedData, setSubmittedData] = useState(null);
  const [premium, setPremium] = useState(null);
  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const validateForm = () => {
    let formErrors = {};
    if (!form.name) formErrors.name = "Name is required";
    if (!form.cropType) formErrors.cropType = "Crop type is required";
    if (!form.season) formErrors.season = "Season is required";
    if (!form.area || isNaN(form.area) || form.area <= 0)
      formErrors.area = "Valid area is required";
    if (!form.bankDetails) formErrors.bankDetails = "Bank details are required";
    if (!form.amount || isNaN(form.amount) || form.amount <= 0)
      formErrors.amount = "Valid amount is required";
    setErrors(formErrors);
    return Object.keys(formErrors).length === 0;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!validateForm()) return;

    let rate;
    switch (form.season) {
      case "Kharif":
        rate = 0.02;
        break;
      case "Rabi":
        rate = 0.015;
        break;
      case "Commercial":
        rate = 0.05;
        break;
      default:
        rate = 0;
    }

    const calculatedPremium = rate * parseFloat(form.amount);
    setPremium(calculatedPremium.toFixed(2));

    axios
      .post("http://localhost:3000/applyData", form)
      .then((res) => {
        setSubmittedData(form);
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
        Apply for Insurance
      </h2>
      <form
        onSubmit={handleSubmit}
        style={{ display: "inline-block", textAlign: "left" }}
      >
        {["name", "cropType", "season", "area", "bankDetails", "amount"].map(
          (field) => (
            <div key={field}>
              <input
                name={field}
                placeholder={field}
                onChange={handleChange}
                style={inputStyle}
              />
              {errors[field] && (
                <p style={{ color: "red", fontSize: "0.8rem" }}>
                  {errors[field]}
                </p>
              )}
              <br />
            </div>
          )
        )}
        <div style={{ textAlign: "center" }}>
          <button type="submit" style={buttonStyle}>
            Submit
          </button>
        </div>
      </form>

      {submittedData && (
        <div
          style={{ marginTop: "30px", textAlign: "left", display: "inline-block" }}
        >
          <h3 style={{ color: "#28a745" }}>
            Application Submitted Successfully!
          </h3>
          <p>
            <strong>Name:</strong> {submittedData.name}
          </p>
          <p>
            <strong>Crop:</strong> {submittedData.cropType}
          </p>
          <p>
            <strong>Season:</strong> {submittedData.season}
          </p>
          <p>
            <strong>Area:</strong> {submittedData.area} acres
          </p>
          <p>
            <strong>Amount:</strong> ₹{submittedData.amount}
          </p>
          <p>
            <strong>Bank:</strong> {submittedData.bankDetails}
          </p>
          <p>
            <strong>Calculated Premium:</strong> ₹{premium}
          </p>
        </div>
      )}
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
};

export default ApplyInsurance;

