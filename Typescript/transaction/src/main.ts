import axios, { AxiosError } from "axios";

const API_URL = "http://localhost:5000/transactions";

// Helper function to get input value by id
const getInputValue = (id: string): string => (document.getElementById(id) as HTMLInputElement).value;

// Create a new transaction
document.getElementById("create")?.addEventListener("click", async () => {
  const transId = getInputValue("trans-id");
  const transName = getInputValue("trans-name");
  const transDescription = getInputValue("trans-description");
  const transMode = getInputValue("trans-mode");
  try {
    const response = await axios.post(API_URL, { transId, transName, transDescription, transMode });
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
document.getElementById("read")?.addEventListener("click", async () => {
  try {
    const response = await axios.get(API_URL);
    console.log("Transactions fetched", response.data);
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("Error fetching transactions", error.response?.data);
    } else {
      console.error("Error fetching transactions", error);
    }
  }
});

// Update a transaction
document.getElementById("update")?.addEventListener("click", async () => {
  const transId = getInputValue("update-trans-id");
  const transName = getInputValue("update-trans-name");
  const transDescription = getInputValue("update-trans-description");
  const transMode = getInputValue("update-trans-mode");
  try {
    const response = await axios.put(`${API_URL}/${transId}`, { transId, transName, transDescription, transMode });
    console.log("Transaction updated", response.data);
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("Error updating transaction", error.response?.data);
    } else {
      console.error("Error updating transaction", error);
    }
  }
});

// Delete a transaction
document.getElementById("delete")?.addEventListener("click", async () => {
  const transId = getInputValue("delete-trans-id");
  try {
    const response = await axios.delete(`${API_URL}/${transId}`);
    console.log("Transaction deleted", response.data);
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.error("Error deleting transaction", error.response?.data);
    } else {
      console.error("Error deleting transaction", error);
    }
  }
});