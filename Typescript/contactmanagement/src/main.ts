import axios, { AxiosError } from "axios";
 
const API_URL = "http://localhost:5000/users";
 
// Helper function to get input value by id
const getInputValue = (id: string): string => (document.getElementById(id) as HTMLInputElement).value;
 
 
 
// Create a new user
document.getElementById("create")?.addEventListener("click", async () => {
    const id = getInputValue("c_id");
    const name = getInputValue("name");
    const email = getInputValue("email");
    try {
        const response = await axios.post(API_URL, { id,name, email });
        console.log("User created", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error creating user", error.response?.data);
        } else {
            console.error("Error creating user", error);
        }
    }
});
 
// Read users
document.getElementById("read")?.addEventListener("click", async () => {
    try {
        const response = await axios.get(API_URL);
        console.log("Users fetched", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error fetching users", error.response?.data);
        } else {
            console.error("Error fetching users", error);
        }
    }
});
 
// Update a user
document.getElementById("update")?.addEventListener("click", async () => {
    const id = getInputValue("update-id");
    const name = getInputValue("update-name");
    const email = getInputValue("update-email");
    try {
        const response = await axios.put(`${API_URL}/${id}`, { id,name, email });
        console.log("User updated", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error updating user", error.response?.data);
        } else {
            console.error("Error updating user", error);
        }
    }
});
 
 
// Delete a user
document.getElementById("delete")?.addEventListener("click", async () => {
    const id = getInputValue("delete-id");
    try {
        const response = await axios.delete(`${API_URL}/${id}`);
        console.log("User deleted", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error deleting user", error.response?.data);
        } else {
            console.error("Error deleting user", error);
        }
    }
});
 