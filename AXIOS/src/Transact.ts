import axios from "axios";
 
const API_URL = "http://localhost:3001/Transactions";
 

const createTransaction = async () => {
  const user = {
    TransactId: "44",
    TransactionName: "Money Transfer",
    description: "high amount transfer",
    TransactionMode: "Online",
  };
  const response = await axios.post(API_URL, user);
  console.log("Created:", response.data);
};
 

const getTransaction = async () => {
  const response = await axios.get(API_URL);
  console.log("All Transactions:", response.data);
};
 
// UPDATE
const updateTransaction = async (id: number) => {
  const user = {
    TransactId: "45",
    TransactionName: "Money Transfer",
    description: "low amount transfer",
    TransactionMode: "Offline",
  };
  const response = await axios.put(`${API_URL}/${id}`, user);
  console.log("Updated:", response.data);
};
 
const deleteTransaction = async (id: number) => {
  const response = await axios.delete(`${API_URL}/${id}`);
  console.log("Deleted:", response.data);
};
 

(async () => {
  await createTransaction();
  await getTransaction();
  await updateTransaction(6);
  await deleteTransaction(4); 
})();
 
