import React from "react";
import { useState, useEffect } from "react";
import axios from "axios";
import vid from "../media/BackgroundVideo.mp4";
import "../App.css";

const API_URL = "http://localhost:5000/bookings";

function Bookings() {
  const [bookings, setBookings] = useState([]);

  useEffect(() => {
    document.title = "Z Bookings";
    axios
      .get(API_URL)
      .then((response) => setBookings(response.data))
      .catch((error) => console.log(error));
  }, []);

  const handleAdd = (e) => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const data = {
      bookingid: formData.get("bookingid"),
      name: formData.get("name"),
      destination: formData.get("destination"),
      status: formData.get("status"),
      date: formData.get("date"),
    };
    if (
      !data.bookingid ||
      !data.name ||
      !data.destination ||
      !data.status ||
      !data.date
    ) {
      alert("Please fill in all fields");
    } else if (
      bookings.some((booking) => booking.bookingid === data.bookingid)
    ) {
      alert("Booking ID already exists");
    } else if (data.date < toString(new Date())) {
      alert("Date cannot be in the past");
    } else {
      axios
        .post(API_URL, data)
        .then((response) => setBookings([...bookings, response.data]))
        .catch((error) => console.log(error));
      alert("Booking added successfully");
      e.target.reset();
    }
  };

  const handleDelete = (id) => {
    axios
      .delete(`${API_URL}/${id}`)
      .then(() => setBookings(bookings.filter((booking) => booking.id !== id)))
      .catch((error) => console.log(error));
  };

  const handleUpdate = (id) => {
    let bookingid, name, destination, status, date;

    const dateRegex = /^\d{4}-\d{2}-\d{2}$/;

    while (!bookingid || !name || !destination || !status) {
      bookingid = prompt("Enter new booking ID:");
      if (bookings.some((booking) => booking.bookingid === bookingid)) {
        alert("Update: Booking ID already exists");
        continue;
      }

      name = prompt("Enter new traveller name:");
      destination = prompt("Enter new destination:");

      status = prompt(
        "Enter new booking status: (Pending, Confirmed, Cancelled)"
      );
      status = status.toLowerCase();
      if (
        status !== "pending" &&
        status !== "confirmed" &&
        status !== "cancelled"
      ) {
        alert("Update: Please enter a valid booking status");
        continue;
      }

      date = prompt("Enter new date: YYYY-MM-DD");
      if (!dateRegex.test(date)) {
        alert("Update: Please enter a valid date in the format YYYY-MM-DD");
        continue;
      }
      if (date < toString(new Date())) {
        alert("Update: Date cannot be in the past");
        continue;
      }

      date = new Date(date);

      if (!bookingid || !name || !destination || !status || !date) {
        alert("Update: Please fill in all fields");
      } else {
        name = name.charAt(0).toUpperCase() + name.slice(1);
        status = status.charAt(0).toUpperCase() + status.slice(1);
        destination =
          destination.charAt(0).toUpperCase() + destination.slice(1);
        axios
          .put(`${API_URL}/${id}`, {
            bookingid: bookingid,
            name: name,
            destination: destination,
            status: status,
            date: date,
          })
          .then(() =>
            setBookings(
              bookings.map((booking) =>
                booking.id === id
                  ? {
                      ...booking,
                      bookingid: bookingid,
                      name: name,
                      destination: destination,
                      status: status,
                      date: date,
                    }
                  : booking
              )
            )
          )
          .catch((error) => console.log(error));
      }
    }
  };

  const toString = (date) => {
    date = new Date(date);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const day = date.getDate().toString().padStart(2, "0");
    return `${year}-${month}-${day}`;
  };

  const handleSearch = () => {
    const id = prompt("Enter booking ID:");
    const booking = bookings.find((booking) => booking.bookingid === id);
    if (booking) {
      alert(
        `Booking ID: ${booking.bookingid}\nTraveller Name: ${booking.name}\nDestination: ${booking.destination}\nBooking Status: ${booking.status}\nDate: ${booking.date}`
      );
    } else {
      alert("Booking not found");
    }
  };

  function DisplayData() {
    if (bookings.length === 0) {
      return (
        <div className="App" style={{ marginTop: "100px" }}>
          <header className="App-header">
            <div className="form-container">
              <h1>No Bookings Found</h1>
            </div>
          </header>
        </div>
      );
    } else {
      return (
        <div className="App" style={{ marginTop: "100px" }}>
          <header className="App-header">
            <div className="form-container">
              <div
                style={{ display: "flex", flexDirection: "row", gap: "10px" }}
              >
                <h3>Bookings</h3>{" "}
                <button className="search-button" onClick={handleSearch}>
                  Search Booking
                </button>
              </div>
              <table className="dataTable" style={{ marginTop: "25px" }}>
                <tr>
                  <th>Booking ID</th>
                  <th>Traveller Name</th>
                  <th>Destination</th>
                  <th>Booking Status</th>
                  <th>Date</th>
                  <th>Update</th>
                  <th>Delete</th>
                </tr>
                {bookings.map((booking) => (
                  <tr key={booking.id}>
                    <td>{booking.bookingid}</td>
                    <td>{booking.name}</td>
                    <td>{booking.destination}</td>
                    <td>{booking.status}</td>
                    <td>{toString(booking.date)}</td>
                    <td>
                      <button
                        className="update-button"
                        onClick={() => handleUpdate(booking.id)}
                      >
                        Update
                      </button>
                    </td>
                    <td>
                      <button
                        className="delete-button"
                        onClick={() => handleDelete(booking.id)}
                      >
                        Delete
                      </button>
                    </td>
                  </tr>
                ))}
              </table>
            </div>
          </header>
        </div>
      );
    }
  }

  return (
    <>
      <div className="App">
        <video autoPlay muted loop className="background" src={vid} />
        <header className="App-header">
          <div className="form-container">
            <h3>Bookings Form</h3>
            <form onSubmit={handleAdd} noValidate>
              <table className="formTable">
                <tr>
                  <td>
                    <label>Booking ID:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      name="bookingid"
                      placeholder="Booking ID"
                    />
                  </td>
                </tr>
                <tr>
                  <td>
                    <label>Traveller Name:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      name="name"
                      placeholder="Traveller Name"
                    />
                  </td>
                </tr>
                <tr>
                  <td>
                    <label>Destination:</label>
                  </td>
                  <td>
                    <input
                      type="text"
                      name="destination"
                      placeholder="Destination"
                    />
                  </td>
                </tr>
                <tr>
                  <td>
                    <label>Booking Status:</label>
                  </td>
                  <td>
                    <select
                      name="status"
                      placeholder="Booking Status"
                      defaultChecked
                    >
                      <option value="pending">Pending</option>
                      <option value="Confirmed">Confirmed</option>
                      <option value="Cancelled">Cancelled</option>
                    </select>
                  </td>
                </tr>
                <tr>
                  <td>
                    <label>Travel Date:</label>
                  </td>
                  <td>
                    <input type="date" name="date" />
                  </td>
                </tr>
                <tr>
                  <td></td>
                  <td>
                    <button type="submit" className="submit-button">
                      Submit
                    </button>
                  </td>
                </tr>
              </table>
            </form>
          </div>
        </header>
      </div>

      <DisplayData />
    </>
  );
}

export default Bookings;
