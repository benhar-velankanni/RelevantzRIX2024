import axios, { AxiosError } from "axios";
import "./style.css";
 
const API_URL= "http://localhost:3000/users";
 
// Helper function to get input value by id
const getInputValue1 = (id: string): string => (document.getElementById(id) as HTMLInputElement).value;
const getInputValue = (id: string): string => (document.getElementById(id) as HTMLInputElement).value;
 
 
 
// Create a new user
document.getElementById("create")?.addEventListener("click", async () => {
    const id = getInputValue1("id");
    const name = getInputValue1("name");
    const email = getInputValue1("email");
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
    const id = getInputValue1("update-id");
    const name = getInputValue1("update-name");
    const email = getInputValue1("update-email");
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
    const id = getInputValue1("delete-id");
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
 
const API_URL1= "http://localhost:3001/transactions";
 
// Create transaction
document.getElementById("create-trans")?.addEventListener("click", async () => {
    const id = getInputValue("trans-id");
    const transName = getInputValue("trans-name");
    const transDescription = getInputValue("trans-description");
    const transMode = getInputValue("trans-mode");
    try {
        const response = await axios.post(API_URL1, { id,transName, transDescription, transMode });
        console.log("Transaction created", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error creating transaction", error.response?.data);
        } else {
            console.error("Error creating transaction", error);
        }
    }
});
 
// Read transactions
document.getElementById("read-trans")?.addEventListener("click", async () => {
    try {
        const response = await axios.get(API_URL1);
        console.log("Transactions fetched", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error fetching transactions", error.response?.data);
        } else {
            console.error("Error fetching transactions", error);
        }
    }
});
// Update transaction
document.getElementById("update-trans")?.addEventListener("click", async () => {
    const id = getInputValue("update-trans-id");
    const transName = getInputValue("update-trans-name");
    const transDescription = getInputValue("update-trans-description");
    const transMode = getInputValue("update-trans-mode");
    try {
        const response = await axios.put(`${API_URL1}/${id}`, { id,transName, transDescription, transMode });
        console.log("Transaction updated", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error updating transaction", error.response?.data);
        } else {
            console.error("Error updating transaction", error);
        }
    }
});
 
 
// Delete transaction
document.getElementById("delete-trans")?.addEventListener("click", async () => {
    const id = getInputValue("delete-trans-id");
    try {
        const response = await axios.delete(`${API_URL1}/${id}`);
        console.log("Transaction deleted", response.data);
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error("Error deleting transaction", error.response?.data);
        } else {
            console.error("Error deleting transaction", error);
        }
    }
});
 