import axios from "axios";
 
const API_URL = "http://localhost:3001/contacts";
 

const createUser = async () => {
  const user = {
    name: "John Doe",
    email: "john@example.com",
    contactNumber: "1234567890",
    Address: "123 Street"
  };
  const response = await axios.post(API_URL, user);
  console.log("Created:", response.data);
};
 
// READ
const getUsers = async () => {
  const response = await axios.get(API_URL);
  console.log("All Users:", response.data);
};
 
// UPDATE
const updateUser = async (id: number) => {
  const user = {
    name: "Jane Smith",
    email: "jane@example.com",
    contactNumber: "0987654321",
    Address: "456 Avenue"
  };
  const response = await axios.put(`${API_URL}/${id}`, user);
  console.log("Updated:", response.data);
};
 
const deleteUser = async (id: number) => {
  const response = await axios.delete(`${API_URL}/${id}`);
  console.log("Deleted:", response.data);
};
 

(async () => {
  await createUser();
  await getUsers();
  await updateUser(1);
  await deleteUser(9); 
})();
 
