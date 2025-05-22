import React, { useState, useEffect } from "react";
import axios from "axios";
 import "./App.css";
interface Volunteer {
  id: number;
  name: string;
  skills: string;
  availability: boolean;
  AssignedProjects: number;
}
 
function App() {
  const [volunteer, setVolunteer] = useState<Volunteer[]>([]);
  const [allVolunteers, setAllVolunteers] = useState<Volunteer[]>([]);
 
  const [id, setId] = useState(0);
  const [name, setName] = useState("");
  const [skills, setSkills] = useState("");
  const [availability, setAvailability] = useState(true);
  const [AssignedProjects, setAssignedProjects] = useState(0);
 
  const [editMode, setEditMode] = useState(false);
  const [editingId, setEditingId] = useState<number | null>(null);
 
  useEffect(() => {
    const fetchVolunteer = async () => {
      try {
        const response = await axios.get("http://localhost:5010/volunteers");
        setVolunteer(response.data);
        setAllVolunteers(response.data);
      } catch (error) {
        console.error("Error fetching volunteers:", error);
      }
    };
    fetchVolunteer();
  }, []);
 
  const resetForm = () => {
    setId(0);
    setName("");
    setSkills("");
    setAvailability(true);
    setAssignedProjects(0);
    setEditMode(false);
    setEditingId(null);
  };
 
  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
 
    const newVolunteer: Volunteer = {
      id,
      name,
      skills,
      availability,
      AssignedProjects,
    };
 
    if (editMode && editingId !== null) {
      // Handle Update
      try {
        await axios.put(`http://localhost:5010/volunteers/${editingId}`, newVolunteer);
        setVolunteer((prev) =>
          prev.map((v) => (v.id === editingId ? newVolunteer : v))
        );
        setAllVolunteers((prev) =>
          prev.map((v) => (v.id === editingId ? newVolunteer : v))
        );
        alert("Volunteer updated successfully.");
      } catch (error) {
        console.error("Error updating volunteer:", error);
      }
    } else {
      // Handle Create
      try {
        const response = await axios.post("http://localhost:5010/volunteers", newVolunteer);
        setVolunteer((prev) => [...prev, response.data]);
        setAllVolunteers((prev) => [...prev, response.data]);
        alert("Volunteer created successfully.");
      } catch (error) {
        console.error("Error creating volunteer:", error);
      }
    }
 
    resetForm();
  };
 
  const handleDelete = async (id: number) => {
    setVolunteer((prev) => prev.filter((v) => v.id !== id));
    setAllVolunteers((prev) => prev.filter((v) => v.id !== id));
 
    try {
      await axios.delete(`http://localhost:5010/volunteers/${id}`);
      alert("Volunteer deleted successfully.");
    } catch (error) {
      console.error("Error deleting volunteer:", error);
    }
  };
 
  const handleEditClick = (v: Volunteer) => {
    setId(v.id);
    setName(v.name);
    setSkills(v.skills);
    setAvailability(v.availability);
    setAssignedProjects(v.AssignedProjects);
    setEditMode(true);
    setEditingId(v.id);
  };
 
  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    const searchId = parseInt(e.target.value);
    if (!e.target.value) {
      setVolunteer(allVolunteers);
      return;
    }
    const filtered = allVolunteers.filter((v) => v.id === searchId);
    setVolunteer(filtered);
  };
 
  return (
    <div>
      <h1>Volunteer Management</h1>
 
      <form onSubmit={handleSubmit}>
        <label htmlFor="id">ID:</label>
        <input type="number" id="id" value={id} onChange={(e) => setId(parseInt(e.target.value))} /><br />
 
        <label htmlFor="name">Name:</label>
        <input type="text" id="name" value={name} onChange={(e) => setName(e.target.value)} /><br />
 
        <label htmlFor="skills">Skills:</label>
        <input type="text" id="skills" value={skills} onChange={(e) => setSkills(e.target.value)} /><br />
 
        <label htmlFor="availability">Availability:</label>
        <input type="checkbox" id="availability" checked={availability} onChange={(e) => setAvailability(e.target.checked)} /><br />
 
        <label htmlFor="AssignedProjects">Assigned Projects:</label>
        <input type="number" id="AssignedProjects" value={AssignedProjects} onChange={(e) => setAssignedProjects(parseInt(e.target.value))} /><br />
 
        <button type="submit">{editMode ? "Update" : "Create"}</button>
      </form>
 
      <input type="number" placeholder="Search by ID" onChange={handleSearch} />
 
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Skills</th>
            <th>Availability</th>
            <th>Assigned Projects</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {volunteer.map((v) => (
            <tr key={v.id}>
            <td>{v.id}</td>
              <td>{v.name}</td>
              <td>{v.skills}</td>
              <td>{v.availability.toString()}</td>
              <td>{v.AssignedProjects}</td>
              <td>
                <button onClick={() => handleEditClick(v)}>Edit</button>
                <button onClick={() =>
                 handleDelete(v.id)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
 
export default App;
 