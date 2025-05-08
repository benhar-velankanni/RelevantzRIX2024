import React, { useState } from "react";

const CalculateInsurance = () => {
  const [form, setForm] = useState({
    season: "",
    zoneType: "",
    cropType: "",
    area: "",
    amount: "",
  });
  const [premium, setPremium] = useState(null);
  const [submitted, setSubmitted] = useState(false);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleCalculate = () => {
    if (Object.values(form).some((field) => !field)) {
      alert("Please fill all fields");
      return;
    }

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
    setSubmitted(true);
  };

  return (
    <div
      style={{ textAlign: "center", marginTop: "60px", fontFamily: "Segoe UI" }}
    >
      <h2 style={{ color: "#007bff", marginBottom: "30px" }}>
        Calculate Insurance Premium
      </h2>
      {["season", "zoneType", "cropType", "area", "amount"].map((field) => (
        <div key={field}>
          <input
            name={field}
            placeholder={field}
            value={form[field]}
            onChange={handleChange}
            style={inputStyle}
          />
          <br />
        </div>
      ))}
      <button onClick={handleCalculate} style={buttonStyle}>
        Calculate
      </button>

      {submitted && (
        <div style={{ marginTop: "30px" }}>
          <h3 style={{ color: "#28a745" }}>Calculation Submitted</h3>
          <p>
            <strong>Season:</strong> {form.season}
          </p>
          <p>
            <strong>Zone Type:</strong> {form.zoneType}
          </p>
          <p>
            <strong>Crop Type:</strong> {form.cropType}
          </p>
          <p>
            <strong>Area:</strong> {form.area} acres
          </p>
          <p>
            <strong>Amount:</strong> ₹{form.amount}
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

export default CalculateInsurance;
